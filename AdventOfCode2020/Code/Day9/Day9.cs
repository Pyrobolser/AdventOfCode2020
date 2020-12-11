using AdventOfCode2020.Code.Utils;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AdventOfCode2020.Code.Day9
{

    public static class Part1
    {
        private static long[] _xmasData;
        private const int PREAMBLE_SIZE = 25;
        
        public static long Solve()
        {
            _xmasData = Array.ConvertAll(File.ReadAllLines(@"Input\Day9.txt"), long.Parse);
            long xmaxValue = 0;
            var preamble = new IndexedQueue<long>(_xmasData[..PREAMBLE_SIZE]);

            for (int i = preamble.Count; i < _xmasData.Length; i++)
            {
                var isFound = false;
                xmaxValue = _xmasData[i];
                for (int j = 0; j < preamble.Count; j++)
                {
                    var left = xmaxValue - preamble[j];
                    if(preamble.Contains(left))
                    {
                        isFound = true;
                        preamble.Dequeue();
                        preamble.Enqueue(xmaxValue);
                        break;
                    }
                }

                if (!isFound)
                    break;
            }

            return xmaxValue;
        }
    }

    public class Part2
    {
        private static long[] _xmasData;
        private static long _part1;

        public static long Solve()
        {
            _xmasData = Array.ConvertAll(File.ReadAllLines(@"Input\Day9.txt"), long.Parse);

            _part1 = Part1.Solve();
            long min = long.MaxValue, max = long.MinValue;
            var queue = new Queue<long>();

            for(int i = 0; i < _xmasData.Length; i++)
            {
                if (queue.Sum() + _xmasData[i] > _part1)
                {
                    queue.Dequeue();
                    i--;
                }
                else
                {
                    queue.Enqueue(_xmasData[i]);
                }

                min = queue.Min();
                max = queue.Max();

                if (queue.Sum() == _part1)
                    break;
            }

            return min + max;
        }
    }
}
