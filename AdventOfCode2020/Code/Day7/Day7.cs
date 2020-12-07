using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace AdventOfCode2020.Code.Day7
{
    public static class Part1
    {
        private static string[] _rules;

        public static int Solve()
        {
            _rules = File.ReadAllLines(@"Input\Day7.txt");
            var count = 0;
            HashSet<string> bags = new HashSet<string> { " shiny gold" };
            GetBags(" shiny gold");

            void GetBags(string bag)
            {
                foreach (var rule in _rules.Where(r => r.Contains(bag)))
                {
                    var currentBag = $" {rule.Split(" bags ")[0]}";
                    if (!bags.Contains(currentBag))
                    {
                        count++;
                        bags.Add(currentBag);
                        GetBags(currentBag);
                    }
                }
            }

            return count;
        }
    }

    public static class Part2
    {
        private static string[] _rules;

        public static int Solve()
        {
            _rules = File.ReadAllLines(@"Input\Day7.txt");

            int GetBags(string bag)
            {
                var count = 0;
                foreach (var rule in _rules.Where(r => r.StartsWith(bag)))
                {
                    var ruleBags = Regex.Matches(rule, @"(?<number>\d+) (?<color>.*?) bag");

                    foreach(Match match in ruleBags)
                    {
                        count += int.Parse(match.Groups["number"].Value) * (1 + GetBags(match.Groups["color"].Value));
                    }
                }

                return count;
            }

            return GetBags("shiny gold");
        }
    }
}
