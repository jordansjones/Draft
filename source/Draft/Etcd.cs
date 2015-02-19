using System;
using System.Linq;

using Flurl;

namespace Draft
{
    public static class Etcd
    {

        public static IEtcdClient ClientFor(Uri uri)
        {
            if (!uri.IsAbsoluteUri)
            {
                throw new ArgumentException("Uri must be absolute", "uri");
            }
            
            return new EtcdClient(new Url(uri.GetComponents(UriComponents.SchemeAndServer, UriFormat.SafeUnescaped)));
        }

    }
}
