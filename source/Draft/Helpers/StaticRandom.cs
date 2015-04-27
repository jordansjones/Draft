using System;
using System.Linq;
using System.Threading;

namespace Draft
{
    /// <summary>
    ///     Derived from http://stackoverflow.com/a/1952556/27536
    /// </summary>
    internal static class StaticRandom
    {

        private static int _seed;

        private static readonly ThreadLocal<IRandom> ThreadLocalRandom = new ThreadLocal<IRandom>(() => new SystemRandom(Interlocked.Increment(ref _seed)));

        static StaticRandom()
        {
            _seed = Environment.TickCount;
        }

        public static IRandom Instance
        {
            get { return ThreadLocalRandom.Value; }
        }


        private sealed class SystemRandom : IRandom
        {

            private readonly Random _random;

            public SystemRandom(int seed)
            {
                _random = new Random(seed);
            }

            public int Next()
            {
                return _random.Next();
            }

            public int Next(int minValue, int maxValue)
            {
                return _random.Next(minValue, maxValue);
            }

            public int Next(int maxValue)
            {
                return _random.Next(maxValue);
            }

            public double NextDouble()
            {
                return _random.NextDouble();
            }

            public void NextBytes(byte[] buffer)
            {
                _random.NextBytes(buffer);
            }

        }
    }
}
