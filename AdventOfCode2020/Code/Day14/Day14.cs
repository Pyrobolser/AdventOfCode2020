using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AdventOfCode2020.Code.Day14
{
    public static class Part1
    {
        public static long Solve()
        {
            long ANDmask = 0, ORmask = 0;
            Dictionary<int, long> memory = new();

            foreach(var line in File.ReadAllLines(@"Input\Day14.txt"))
            {
                if(line.StartsWith("ma"))
                {
                    ANDmask = Convert.ToInt64(line.Split(" = ")[1].Replace('1', '0').Replace('X', '1'), 2);
                    ORmask = Convert.ToInt64(line.Split(" = ")[1].Replace('X', '0'), 2);
                }
                else
                {
                    var chunks = line.Split(" = ");
                    var id = int.Parse(chunks[0][(chunks[0].IndexOf('[') + 1)..(chunks[0].Length - 1)]);
                    long value = long.Parse(chunks[1]);

                    memory[id] = (value & ANDmask) | ORmask;
                }
            }

            return memory.Values.Sum();
        }
    }

    public static class Part2
    {
        public static long Solve()
        {
            long ANDmask = 0, ORmask = 0;
            Dictionary<long, long> memory = new();

            foreach (var line in File.ReadAllLines(@"Input\Day14.txt"))
            {
                if (line.StartsWith("ma"))
                {
                    ANDmask = Convert.ToInt64(line.Split(" = ")[1].Replace('1', '0').Replace('X', '1'), 2);
                    ORmask = Convert.ToInt64(line.Split(" = ")[1].Replace('X', '0'), 2);
                }
                else
                {
                    var chunks = line.Split(" = ");
                    long id = int.Parse(chunks[0][(chunks[0].IndexOf('[') + 1)..(chunks[0].Length - 1)]);
                    long value = long.Parse(chunks[1]);

                    id |= ORmask;
                    id &= ~ANDmask;

                    var tempMask = ANDmask;
                    memory[id] = value;

                    // Implementation of https://cp-algorithms.com/algebra/all-submasks.html
                    while (tempMask != 0)
                    {
                        memory[id | tempMask] = value;
                        tempMask = (tempMask - 1) & ANDmask;
                    }
                }
            }

            return memory.Values.Sum();
        }
    }
}
