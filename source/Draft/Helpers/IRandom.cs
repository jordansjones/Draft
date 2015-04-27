using System;
using System.Linq;

namespace Draft
{
    internal interface IRandom
    {

        int Next();

        int Next(int minValue, int maxValue);

        int Next(int maxValue);

        void NextBytes(byte[] buffer);

        double NextDouble();

    }
}
