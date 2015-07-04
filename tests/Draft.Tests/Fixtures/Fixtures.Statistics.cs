using System;
using System.Linq;

namespace Draft.Tests
{
    internal static partial class Fixtures
    {

        public static class Statistics
        {

            public static readonly string LeaderResponse = @"{
    ""followers"": {
        ""6e3bd23ae5f1eae0"": {
            ""counts"": {
                ""fail"": 0,
                ""success"": 745
            },
            ""latency"": {
                ""average"": 0.017039507382550306,
                ""current"": 0.000138,
                ""maximum"": 1.007649,
                ""minimum"": 0,
                ""standardDeviation"": 0.05289178277920594
            }
        },
        ""a8266ecf031671f3"": {
            ""counts"": {
                ""fail"": 0,
                ""success"": 735
            },
            ""latency"": {
                ""average"": 0.012124141496598642,
                ""current"": 0.000559,
                ""maximum"": 0.791547,
                ""minimum"": 0,
                ""standardDeviation"": 0.04187900156583733
            }
        }
    },
    ""leader"": ""924e2e83e93f2560""
}";

            public static readonly string SelfResponse = @"{
    ""id"": ""eca0338f4ea31566"",
    ""leaderInfo"": {
        ""leader"": ""8a69d5f6b7814500"",
        ""startTime"": ""2014-10-24T13:15:51.186620747-07:00"",
        ""uptime"": ""10m59.322358947s""
    },
    ""name"": ""node3"",
    ""recvAppendRequestCnt"": 5944,
    ""recvBandwidthRate"": 570.6254930219969,
    ""recvPkgRate"": 9.00892789741075,
    ""sendAppendRequestCnt"": 0,
    ""startTime"": ""2014-10-24T13:15:50.072007085-07:00"",
    ""state"": ""StateFollower""
}";

            public static readonly string StoreResponse = @"{
    ""compareAndSwapFail"": 0,
    ""compareAndSwapSuccess"": 0,
    ""createFail"": 0,
    ""createSuccess"": 2,
    ""deleteFail"": 0,
    ""deleteSuccess"": 0,
    ""expireCount"": 0,
    ""getsFail"": 4,
    ""getsSuccess"": 75,
    ""setsFail"": 2,
    ""setsSuccess"": 4,
    ""updateFail"": 0,
    ""updateSuccess"": 0,
    ""watchers"": 0
}";

        }

    }
}
