using System;
using System.Linq;

namespace Draft.Exceptions
{
    public class EtcdTimeoutException : EtcdException
    {

        public override bool IsTimeout
        {
            get { return true; }
        }


    }
}
