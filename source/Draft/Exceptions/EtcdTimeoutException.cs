using System;
using System.Linq;

namespace Draft.Exceptions
{
    /// <summary>
    /// Represents an error due to an HTTP request/response timeout.
    /// </summary>
    public class EtcdTimeoutException : EtcdException
    {
        
        /// <summary>
        ///     Indicates that this exception is due to an HTTP timeout error.
        /// </summary>
        public override bool IsTimeout
        {
            get { return true; }
        }


    }
}
