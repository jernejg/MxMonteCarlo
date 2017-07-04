using System;
using System.Threading;
using System.Threading.Tasks;

namespace MonteCarlo
{
    public class Program
    {
        static void Main(string[] args)
        {
            const int numberOfTimesWaitingForABus = 10000000;
            var waitingTime = 0;
            Parallel.For(0, numberOfTimesWaitingForABus + 1, i =>
            {
                //Waiting for A between 0 and 12 minutes
                var busAArrivesIn = StaticRandom.Rand(0, 13);
                //Waiting for B between 0 and 8 minute
                var busBArrivesIn = StaticRandom.Rand(0, 9);
                //Take the first bus (thread safe incrementation)
                Interlocked.Add(ref waitingTime, Math.Min(busAArrivesIn, busBArrivesIn));
            });

            var averageWaitingTime = (float)waitingTime / numberOfTimesWaitingForABus;

            Console.WriteLine(averageWaitingTime);
        }
    }
}
