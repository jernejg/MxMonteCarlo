using System;
using System.Threading;

namespace MonteCarlo
{
    /// <summary>
    /// Give each thread its own seed value
    /// </summary>
    public static class StaticRandom
    {
        private static int _seed = Environment.TickCount;

        private static readonly ThreadLocal<Random> Random =
            new ThreadLocal<Random>(() => new Random(Interlocked.Increment(ref _seed)));

        public static int Rand(int a, int b)
        {
            return Random.Value.Next(a, b);
        }
    }
}