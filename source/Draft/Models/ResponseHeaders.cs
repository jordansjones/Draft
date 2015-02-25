using System;
using System.Linq;

namespace Draft.Models
{
    internal class ResponseHeaders
    {

        public string ClusterId { get; set; }

        public string EtcdIndex { get; set; }

        public string RaftIndex { get; set; }

        public string RaftTerm { get; set; }
    }
}
