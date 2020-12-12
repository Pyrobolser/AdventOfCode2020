using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AdventOfCode2020.Code.Day10
{
    public static class Part1
    {
        private static List<int> _adapters;
        private static int _builtIn;
        public static int Solve()
        {
            _adapters = File.ReadAllLines(@"Input\Day10.txt").Select(x => int.Parse(x)).OrderBy(x => x).ToList();
            _builtIn = _adapters.Last() + 3;

            int currentAdapter = 0, diff1 = 0, diff3 = 0;
            for(int i = 0; i < _adapters.Count; i++)
            {
                var diff = _adapters[i] - currentAdapter;

                if(diff == 1)
                {
                    diff1++;
                }
                else if (diff == 3)
                {
                    diff3++;
                }

                currentAdapter = _adapters[i];
            }

            return diff1 * (diff3 + 1);
        }
    }

    public static class Part2
    {
        private static List<int> _adapters;
        private static int _builtIn;
        public static long Solve()
        {
            _adapters = File.ReadAllLines(@"Input\Day10.txt").Select(x => int.Parse(x)).ToList();
            _builtIn = _adapters.Max() + 3;
            _adapters.Add(0);
            _adapters.Add(_builtIn);
            _adapters = _adapters.OrderBy(x => x).ToList();

            Dictionary<int, long> paths = new() { { 0, 1 } };
            long ways = 1;
            for (int i = 0; i < _adapters.Count - 1; i++)
            {
                var candidates = _adapters.Where(x => _adapters[i] < x && x <= _adapters[i] + 3).ToList();

                ways += paths[_adapters[i]] * (candidates.Count - 1);

                foreach(var candidate in candidates)
                {
                    if(paths.ContainsKey(candidate))
                    {
                        paths[candidate] += paths[_adapters[i]];
                    }
                    else
                    {
                        paths.Add(candidate, paths[_adapters[i]]);
                    }
                }
            }

            return ways;
        }
    }
}
