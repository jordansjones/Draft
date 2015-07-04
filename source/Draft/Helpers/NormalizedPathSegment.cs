using System;
using System.Linq;

using Flurl;

namespace Draft
{
    internal sealed class NormalizedPathSegment
    {

        public NormalizedPathSegment(params string[] pathParts)
        {
            pathParts = pathParts ?? new string[0];

            Value = string.Join("/", pathParts.Select(x => x.TrimStart('/').TrimEnd('/')));
        }

        public string Value { get; private set; }


        public Url ToUrl(Uri uri)
        {
            return uri.ToUrl().AppendPathSegment(Value);
        }
    }
}
