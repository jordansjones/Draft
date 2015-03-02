using System;
using System.Linq;

namespace Draft.Responses
{
    internal class ResponseHeaders : IResponseHeaders
    {

        public string ClusterId { get; set; }

        public long? CurrentIndex { get; set; }

        public long? RaftIndex { get; set; }

        public long? RaftTerm { get; set; }

        public void DeepCopy(IResponseHeaders headers)
        {
            if (headers == null) { return; }

            ClusterId = headers.ClusterId;
            CurrentIndex = headers.CurrentIndex;
            RaftIndex = headers.RaftIndex;
            RaftTerm = headers.RaftTerm;
        }

    }
}
