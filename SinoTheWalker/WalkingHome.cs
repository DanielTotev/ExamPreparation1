using System;
using System.Linq;

namespace SinoTheWalker
{
    public class WalkingHome
    {
        public static void Main()
        {
            var timeOfLeaving = Console.ReadLine().Split(new[] { ' ', ':' }, StringSplitOptions.RemoveEmptyEntries).Select(long.Parse).ToArray();
            var numberOfSteps = long.Parse(Console.ReadLine());
            var secondsPerStep = long.Parse(Console.ReadLine());
            var secondsOfLeaving = timeOfLeaving[2];
            var minutessOfLeaving = timeOfLeaving[1];
            var hourOfLeaving = timeOfLeaving[0];
            var leavingTimeInSeconds = secondsOfLeaving + (minutessOfLeaving * 60) + (hourOfLeaving * 3600);
            var processedTimeInSeconds = numberOfSteps * secondsPerStep;
            var totatlTimeInSeconds = processedTimeInSeconds + leavingTimeInSeconds;
            var finalTimeSeconds = totatlTimeInSeconds % 60;
            var finalTimeMinutes = (totatlTimeInSeconds / 60) % 60;
            var finalTimeHour = (totatlTimeInSeconds / 3600) % 24;
            Console.WriteLine($"Time Arrival: {finalTimeHour:D2}:{finalTimeMinutes:D2}:{finalTimeSeconds:D2}");
        }
    }
}