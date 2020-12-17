using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace AdventOfCode2020.Code.Day16
{
    public record TicketField(int RuleId, int Min1, int Max1, int Min2, int Max2);

    public static class Part1
    {
        private static int _errorRate = 0;
        private static int[] _myTicket;
        private static List<int[]> _nearbyTickets = new();
        private static List<TicketField> _rules = new();
        public static int Solve()
        {
            int step = 0, ruleId = 0;
            foreach (var line in File.ReadAllLines(@"Input\Day16.txt"))
            {
                if (string.IsNullOrEmpty(line))
                {
                    step++;
                    continue;
                }

                if (step == 0)
                {
                    var match = Regex.Matches(line, @"\d+");
                    _rules.Add(new(ruleId, int.Parse(match[0].Value), int.Parse(match[1].Value), int.Parse(match[2].Value), int.Parse(match[3].Value)));
                    ruleId++;
                }
                else if (step == 1)
                {
                    if (line.StartsWith('y'))
                        continue;

                    _myTicket = Array.ConvertAll(line.Split(','), int.Parse);
                }
                else if (step == 2)
                {
                    if (line.StartsWith('n'))
                        continue;

                    _nearbyTickets.Add(Array.ConvertAll(line.Split(','), int.Parse));
                }
            }

            foreach(var ticket in _nearbyTickets)
            {
                for(int i = 0; i < ticket.Length; i++)
                {
                    var isValid = false;
                    for(int r = 0; r < _rules.Count; r++)
                    {
                        if ((_rules[r].Min1 <= ticket[i] && ticket[i] <= _rules[r].Max1) || (_rules[r].Min2 <= ticket[i] && ticket[i] <= _rules[r].Max2))
                        {
                            isValid = true;
                            break;
                        }
                    }

                    if(!isValid)
                    {
                        _errorRate += ticket[i];
                    }
                }
            }

            return _errorRate;
        }
    }

    public static class Part2
    {
        private static int[] _myTicket;
        private static List<int[]> _nearbyTickets = new();
        private static List<TicketField> _rules = new();
        public static long Solve()
        {
            int step = 0, ruleId = 0;
            foreach (var line in File.ReadAllLines(@"Input\Day16.txt"))
            {
                if (string.IsNullOrEmpty(line))
                {
                    step++;
                    continue;
                }

                if (step == 0)
                {
                    var match = Regex.Matches(line, @"\d+");
                    _rules.Add(new(ruleId, int.Parse(match[0].Value), int.Parse(match[1].Value), int.Parse(match[2].Value), int.Parse(match[3].Value)));
                    ruleId++;
                }
                else if (step == 1)
                {
                    if (line.StartsWith('y'))
                        continue;

                    _myTicket = Array.ConvertAll(line.Split(','), int.Parse);
                }
                else if (step == 2)
                {
                    if (line.StartsWith('n'))
                        continue;

                    var tempTicket = Array.ConvertAll(line.Split(','), int.Parse);
                    var isValid = false;
                    for (int i = 0; i < tempTicket.Length; i++)
                    {
                        isValid = false;
                        for (int r = 0; r < _rules.Count; r++)
                        {
                            if ((_rules[r].Min1 <= tempTicket[i] && tempTicket[i] <= _rules[r].Max1) || (_rules[r].Min2 <= tempTicket[i] && tempTicket[i] <= _rules[r].Max2))
                            {
                                isValid = true;
                                break;
                            }
                        }

                        if (!isValid)
                            break;
                    }

                    if(isValid)
                        _nearbyTickets.Add(tempTicket);
                }
            }


            Dictionary<int, List<int>> valids = new();
            foreach (var rule in _rules)
            {
                valids.Add(rule.RuleId, new());
                for (int f = 0; f < _myTicket.Length; f++)
                {
                    var isValid = true;
                    for (int i = 0; i < _nearbyTickets.Count; i++)
                    {
                        if ((rule.Min1 > _nearbyTickets[i][f] || _nearbyTickets[i][f] > rule.Max1) && (rule.Min2 > _nearbyTickets[i][f] || _nearbyTickets[i][f] > rule.Max2))
                        {
                            isValid = false;
                            break;
                        }
                    }

                    if (isValid)
                        valids[rule.RuleId].Add(f);
                }
            }

            Dictionary<int, int> final = new();
            long result = 1;
            while(true)
            {
                var validRule = valids.Where(r => r.Value.Count == 1).FirstOrDefault();
                int currentValue = validRule.Value.First();
                final.Add(validRule.Key, currentValue);

                foreach(var rule in valids)
                {
                    rule.Value.RemoveAll(x => x == currentValue);
                }

                valids.Remove(validRule.Key);

                if(validRule.Key < 6) // All the `departure` are the first 6 rules
                {
                    result *= _myTicket[currentValue];
                }

                if (valids.Count == 0)
                    break;
            }

            return result;
        }
    }
}
