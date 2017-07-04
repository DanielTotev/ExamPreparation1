using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace EnduranceRally
{
    public class Lottery
    {
        public static void Main()
        {
            var drivers = Regex.Split(Console.ReadLine(), @"\s+");
            var route = Regex.Split(Console.ReadLine(), @"\s+").Select(double.Parse).ToArray();
            var checkPoints = Regex.Split(Console.ReadLine(), @"\s+").Select(int.Parse).ToArray();

            for (int i = 0; i < drivers.Length; i++)
            {
                var currentDriver = drivers[i];
                var currentDriverFuel = (double)currentDriver[0];
                for (int j = 0; j < route.Length; j++)
                {
                    if (checkPoints.Contains(j))
                    {
                        currentDriverFuel += route[j];
                    }
                    else
                    {
                        currentDriverFuel -= route[j];
                    }

                    if (currentDriverFuel <= 0)
                    {
                        Console.WriteLine($"{currentDriver} - reached {j}");
                        break;
                    }
                }
                if (currentDriverFuel > 0)
                {
                    Console.WriteLine($"{currentDriver} - fuel left {currentDriverFuel:f2}");
                }
            }
        }
    }
}
