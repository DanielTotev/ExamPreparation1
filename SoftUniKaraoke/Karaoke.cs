using System;
using System.Linq;
using System.Collections.Generic;
namespace SoftUniKaraoke
{
    public class Karaoke
    {
        public static void Main()
        {
            var participants = Console.ReadLine().Split(new[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries).ToList();
            var aviableSongs = Console.ReadLine().Split(',').Select(a => a.Trim()).ToList();
            var awards = new Dictionary<string, SortedSet<string>>();
            var input = Console.ReadLine();
            while (input != "dawn")
            {
                var tokens = input.Split(',').Select(a => a.Trim()).ToArray(); 
                var participant = tokens[0];
                var song = tokens[1];
                var award = tokens[2];
                var isLegal = participants.Contains(participant) && aviableSongs.Contains(song);
                if (isLegal)
                {
                    if (!awards.ContainsKey(participant))
                    {
                        awards[participant] = new SortedSet<string>();
                    }
                    awards[participant].Add(award);
                }
                input = Console.ReadLine();
            }
            foreach (var kvp in awards.OrderByDescending(a => a.Value.Count))
            {
                var participant = kvp.Key;
                var awardsCount = kvp.Value.Count;
                Console.WriteLine($"{participant}: {awardsCount} awards");
                var participantAwards = kvp.Value;
                foreach (var award in participantAwards)
                {
                    Console.WriteLine($"--{award}");
                }
            }
            if (awards.Count == 0)
            {
                Console.WriteLine("No awards");
            }
        }
    }
}
