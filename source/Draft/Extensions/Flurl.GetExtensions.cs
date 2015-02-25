using System;
using System.Collections.Generic;
using System.IO;

using Flurl.Http;

using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

using Flurl;

namespace Draft
{
    internal static class FlurlGetExtensions
    {

        public static Task<HttpResponseMessage> GetAsync(this FlurlClient This, CancellationToken? cancellationToken = null)
        {
            var url = This.Url;
            return This.DoCallAsync(http => cancellationToken.HasValue ? http.GetAsync(url, cancellationToken.Value) : http.GetAsync(url));
        }

        public static Task<HttpResponseMessage> GetAsync(this string This, CancellationToken? cancellationToken = null)
        {
            return new FlurlClient(This, true).GetAsync(cancellationToken);
        }

        public static Task<HttpResponseMessage> GetAsync(this Url This, CancellationToken? cancellationToken = null)
        {
            return new FlurlClient(This, true).GetAsync(cancellationToken);
        }

        #region BYTES

        public static Task<byte[]> GetBytesAsync(this FlurlClient This, CancellationToken? cancellationToken = null)
        {
            return This.GetAsync(cancellationToken).ReceiveBytes();
        }

        public static Task<byte[]> GetBytesAsync(this string This, CancellationToken? cancellationToken = null)
        {
            return new FlurlClient(This, true).GetBytesAsync(cancellationToken);
        }

        public static Task<byte[]> GetBytesAsync(this Url This, CancellationToken? cancellationToken = null)
        {
            return new FlurlClient(This, true).GetBytesAsync(cancellationToken);
        }

        #endregion


        #region JSON <T>

        public static Task<T> GetJsonAsync<T>(this FlurlClient This, CancellationToken? cancellationToken = null)
        {
            return This.GetAsync(cancellationToken).ReceiveJson<T>();
        }

        public static Task<T> GetJsonAsync<T>(this string This, CancellationToken? cancellationToken = null)
        {
            return new FlurlClient(This, true).GetJsonAsync<T>(cancellationToken);
        }

        public static Task<T> GetJsonAsync<T>(this Url This, CancellationToken? cancellationToken = null)
        {
            return new FlurlClient(This, true).GetJsonAsync<T>(cancellationToken);
        }

        #endregion


        #region JSON <dynamic>

        public static Task<dynamic> GetJsonAsync(this FlurlClient This, CancellationToken? cancellationToken = null)
        {
            return This.GetAsync(cancellationToken).ReceiveJson();
        }

        public static Task<dynamic> GetJsonAsync(this string This, CancellationToken? cancellationToken = null)
        {
            return new FlurlClient(This, true).GetJsonAsync(cancellationToken);
        }

        public static Task<dynamic> GetJsonAsync(this Url This, CancellationToken? cancellationToken = null)
        {
            return new FlurlClient(This, true).GetJsonAsync(cancellationToken);
        }

        #endregion


        #region JSON List

        public static Task<IList<dynamic>> GetJsonListAsync(this FlurlClient This, CancellationToken? cancellationToken = null)
        {
            return This.GetAsync(cancellationToken).ReceiveJsonList();
        }

        public static Task<IList<dynamic>> GetJsonListAsync(this string This, CancellationToken? cancellationToken = null)
        {
            return new FlurlClient(This, true).GetJsonListAsync(cancellationToken);
        }

        public static Task<IList<dynamic>> GetJsonListAsync(this Url This, CancellationToken? cancellationToken = null)
        {
            return new FlurlClient(This, true).GetJsonListAsync(cancellationToken);
        }

        #endregion


        #region STREAM

        public static Task<Stream> GetStreamAsync(this FlurlClient This, CancellationToken? cancellationToken = null)
        {
            return This.GetAsync(cancellationToken).ReceiveStream();
        }

        public static Task<Stream> GetStreamAsync(this string This, CancellationToken? cancellationToken = null)
        {
            return new FlurlClient(This, true).GetStreamAsync(cancellationToken);
        }

        public static Task<Stream> GetStreamAsync(this Url This, CancellationToken? cancellationToken = null)
        {
            return new FlurlClient(This, true).GetStreamAsync(cancellationToken);
        }

        #endregion


        #region STRING

        public static Task<string> GetStringAsync(this FlurlClient This, CancellationToken? cancellationToken = null)
        {
            return This.GetAsync(cancellationToken).ReceiveString();
        }

        public static Task<string> GetStringAsync(this string This, CancellationToken? cancellationToken = null)
        {
            return new FlurlClient(This, true).GetStringAsync(cancellationToken);
        }

        public static Task<string> GetStringAsync(this Url This, CancellationToken? cancellationToken = null)
        {
            return new FlurlClient(This, true).GetStringAsync(cancellationToken);
        }

        #endregion


    }
}
