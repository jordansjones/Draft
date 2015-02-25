﻿using System;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;

namespace Draft.Requests
{
    public interface IQueueRequest
    {

        Task<object> Execute();

        TaskAwaiter<object> GetAwaiter();

        IQueueRequest WithCancellationToken(CancellationToken token);

        IQueueRequest WithTimeToLive(long? seconds = 0);

        IQueueRequest WithValue(string value);

    }
}
