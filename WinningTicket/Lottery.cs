using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace WinningTicket
{
    public class Lottery
    {
        public static void Main()
        {
            var input = Regex.Split(Console.ReadLine(), @"\s*,\s*").Select(a => a.Trim()).ToArray();
            foreach (var ticket in input)
            {
                if (ticket.Length != 20)
                {
                    Console.WriteLine("invalid ticket");
                    continue;
                }
                var leftSide = ticket.Substring(0, 10);
                var rightSide = ticket.Substring(10);
                var winnigSymbols = new string[] { "@", @"\$", @"\^", "#" };
                var rightSideMatch = string.Empty;
                var leftSideMatch = string.Empty;
                var specialSymbol = string.Empty; 
                foreach (var symbol in winnigSymbols)
                {
                    var regex = new Regex($@"{symbol}{{6,}}");
                    var rightMatch = regex.Match(rightSide);
                    var leftMatch = regex.Match(leftSide);
                    if (leftMatch.Success && rightMatch.Success)
                    {
                        specialSymbol = symbol.Trim('\\');
                        rightSideMatch = rightMatch.Value;
                        leftSideMatch = leftMatch.Value;
                        break;
                    }
                    //else
                    //{
                    //    if (leftSide.Length == 10 && rightSide.Length == 10)
                    //    {
                    //        Console.WriteLine($"ticket \"{ticket}\" - 10{symbol} Jackpot!");
                    //    }
                    //    else
                    //    {
                    //        var count = Math.Min(rightSide.Length, leftSide.Length);
                    //        Console.WriteLine($"");
                    //    }
                    //}
                }
                if (leftSideMatch.Length == 0 && rightSideMatch.Length == 0)
                {
                    Console.WriteLine($"ticket \"{ticket}\" - no match");
                    continue;
                }

                if (leftSideMatch.Length == 10 && rightSideMatch.Length == 10)
                {
                    Console.WriteLine($"ticket \"{ticket}\" - 10{specialSymbol} Jackpot!");
                }
                else
                {
                    var count = Math.Min(rightSideMatch.Length, leftSideMatch.Length);
                    Console.WriteLine($"ticket \"{ticket}\" - {count}{specialSymbol}");
                }

            }
        }
    }
}
