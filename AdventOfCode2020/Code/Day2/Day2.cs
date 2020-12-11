using System;
using System.IO;
using System.Linq;

namespace AdventOfCode2020.Code.Day2
{
    public static class Part1
    {
        public static int Solve()
        {
            var valids = 0;

            foreach(var line in File.ReadAllLines(@"Input\Day2.txt"))
            {
                var chunks = line.Split(' ');
                var limits = Array.ConvertAll(chunks[0].Split('-'), int.Parse);

                if(chunks[2].GroupBy(x => x)
                    .Any(g => g.Key == chunks[1][0]
                    && g.Count() >= limits[0]
                    && g.Count() <= limits[1]))
                {
                    valids++;
                }
            }

            return valids;
        }
    }

    public static class Part2
    {

        public static int Solve()
        {
            var valids = 0;

            foreach (var line in File.ReadAllLines(@"Input\Day2.txt"))
            {
                var chunks = line.Split(' ');
                var limits = Array.ConvertAll(chunks[0].Split('-'), int.Parse);

                if ((chunks[2][limits[0] - 1] == chunks[1][0]) != (chunks[2][limits[1] - 1] == chunks[1][0]))
                    valids++;
            }

            return valids;
        }
    }
}
