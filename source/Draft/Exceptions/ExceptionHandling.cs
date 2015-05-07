using System;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Sockets;

using Draft.Exceptions;
using Draft.Responses;

using Flurl.Http;

// ReSharper disable once CheckNamespace

namespace Draft
{
    internal static class ExceptionHandling
    {
        #region HttpStatusCode -> EtcdErrorCode conversion

        private static EtcdErrorCode? GetEtcdErrorCode(this FlurlHttpException This)
        {
            if (This == null || This.Call == null || This.Call.Response == null) { return null; }

            return This.Call.Response.StatusCode.Map();
        }

        #endregion

        public static EtcdException ProcessException(this Exception This)
        {
            var fhe = This as FlurlHttpException;
            if (fhe == null)
            {
                Debugger.Break();
                throw new NotImplementedException();
            }


            if (fhe.IsTimeoutException()) { return fhe.AsTimeoutException(); }
            if (fhe.IsInvalidHostException()) { return fhe.AsInvalidHostException(); }
            if (fhe.IsInvalidRequestException()) { return fhe.AsInvalidRequestException(); }
            if (fhe.IsHttpConnectionException()) { return fhe.AsHttpConnectionException(); }

            var etcdError = fhe.GetResponseJson<EtcdError>();

            var message = etcdError.Message;

            etcdError.ErrorCode = etcdError.ErrorCode
                                  ?? (fhe.GetEtcdErrorCode() ?? EtcdErrorCode.Unknown);

            EtcdException exception;
            // Ugh. The switch from hell.
            switch (etcdError.ErrorCode.Value)
            {
                case EtcdErrorCode.KeyNotFound:
                    exception = new KeyNotFoundException(message);
                    break;
                case EtcdErrorCode.TestFailed:
                    exception = new TestFailedException(message);
                    break;
                case EtcdErrorCode.NotFile:
                    exception = new NotAFileException(message);
                    break;
                case EtcdErrorCode.NoMorePeer:
                    exception = new NoMorePeerException(message);
                    break;
                case EtcdErrorCode.NotDirectory:
                    exception = new NotADirectoryException(message);
                    break;
                case EtcdErrorCode.NodeExists:
                    exception = new NodeExistsException(message);
                    break;
                case EtcdErrorCode.KeyIsPreserved:
                    exception = new KeyIsPreservedException(message);
                    break;
                case EtcdErrorCode.RootReadOnly:
                    exception = new RootIsReadOnlyException(message);
                    break;
                case EtcdErrorCode.DirectoryNotEmpty:
                    exception = new DirectoryNotEmptyException(message);
                    break;
                case EtcdErrorCode.ExistingPeerAddress:
                    exception = new ExistingPeerAddressException(message);
                    break;
                case EtcdErrorCode.ValueRequired:
                    exception = new ValueRequiredException(message);
                    break;
                case EtcdErrorCode.PreviousValueRequired:
                    exception = new PreviousValueRequiredException(message);
                    break;
                case EtcdErrorCode.TtlNotANumber:
                    exception = new TtlNotANumberException(message);
                    break;
                case EtcdErrorCode.IndexNotANumber:
                    exception = new IndexNotANumberException(message);
                    break;
                case EtcdErrorCode.ValueOrTtlRequired:
                    exception = new ValueOrTtlRequiredException(message);
                    break;
                case EtcdErrorCode.TimeoutNotANumber:
                    exception = new TimeoutNotANumberException(message);
                    break;
                case EtcdErrorCode.NameRequired:
                    exception = new NameRequiredException(message);
                    break;
                case EtcdErrorCode.IndexOrValueRequired:
                    exception = new IndexOrValueRequiredException(message);
                    break;
                case EtcdErrorCode.IndexValueMutex:
                    exception = new IndexValueMutexException(message);
                    break;
                case EtcdErrorCode.InvalidField:
                    exception = new InvalidFieldException(message);
                    break;
                case EtcdErrorCode.InvalidForm:
                    exception = new InvalidFormException(message);
                    break;
                case EtcdErrorCode.RaftInternal:
                    exception = new RaftInternalException(message);
                    break;
                case EtcdErrorCode.LeaderElect:
                    exception = new LeaderElectException(message);
                    break;
                case EtcdErrorCode.WatcherCleared:
                    exception = new WatcherClearedException(message);
                    break;
                case EtcdErrorCode.EventIndexCleared:
                    exception = new EventIndexClearedException(message);
                    break;
                case EtcdErrorCode.StandbyInternal:
                    exception = new StandbyInternalException(message);
                    break;
                case EtcdErrorCode.InvalidActiveSize:
                    exception = new InvalidActiveSizeException(message);
                    break;
                case EtcdErrorCode.InvalidRemoveDelay:
                    exception = new InvalidRemoveDelayException(message);
                    break;
                case EtcdErrorCode.ClientInternal:
                    exception = new ClientInternalException(message);
                    break;
                default:
                    exception = new UnknownErrorException(message);
                    break;
            }

            exception.EtcdError = etcdError;
            if (fhe.Call != null)
            {
                exception.HttpStatusCode = fhe.Call.HttpStatus;
                exception.RequestUrl = fhe.Call.Request.RequestUri.ToString();
                exception.RequestMethod = fhe.Call.Request.Method;
            }

            return exception;
        }

        #region Connection Closed Exception

        private static EtcdException AsHttpConnectionException(this FlurlHttpException This)
        {
            var webex = This.GetBaseException() as WebException;

            if (webex == null || string.IsNullOrWhiteSpace(webex.Message)) return new HttpConnectionException();
            return new HttpConnectionException(webex.Message);
        }

        private static bool IsHttpConnectionException(this FlurlHttpException This)
        {
            if (This == null) return false;

            var be = This.GetBaseException();
            var webex = be as WebException;

            return This.Call != null
                   && !This.Call.Completed
                   && !This.Call.HttpStatus.HasValue
                   && webex != null
                   && (
                       webex.Status == WebExceptionStatus.ConnectionClosed
                       || webex.Status == WebExceptionStatus.ConnectFailure
                       );
        }

        #endregion


        #region Invalid Host Exception

        private static EtcdException AsInvalidHostException(this FlurlHttpException This)
        {
            return new InvalidHostException();
        }

        private static bool IsInvalidHostException(this FlurlHttpException This)
        {
            var be = This.GetBaseException();

            return This.Call != null
                   && !This.Call.Completed
                   && This.Call.Response == null
                   && be is SocketException;
        }

        #endregion

        #region Invalid Request Exception

        public static EtcdException AsInvalidRequestException(this FlurlHttpException This)
        {
            return new InvalidRequestException();
        }

        private static bool IsInvalidRequestException(this FlurlHttpException This)
        {
            return This.Call.HttpStatus.HasValue
                   && This.Call.HttpStatus.Value == HttpStatusCode.NotFound
                   && !This.Call.Response.IsJsonContentType();
        }

        #endregion

        #region Timeout Exception

        private static EtcdException AsTimeoutException(this FlurlHttpException This)
        {
            return new EtcdTimeoutException();
        }

        private static bool IsTimeoutException(this FlurlHttpException This)
        {
            return This is FlurlHttpTimeoutException;
        }

        #endregion
    }
}
