using System;
using System.Collections.Generic;
using System.IO;

namespace AdventOfCode2020.Code.Day1
{
    public static class Part1
    {
        private static int[] _expenses;
        private const int TOTAL = 2020;

        public static int Solve()
        {
            _expenses = Array.ConvertAll(File.ReadAllLines(@"Input\Day1.txt"), int.Parse);
            var map = new HashSet<int>();
            int left = 0, right = 0;

            for(int i = 0; i < _expenses.Length; i++)
            {
                var temp = TOTAL - _expenses[i];

                if(map.Contains(temp))
                {
                    left = _expenses[i];
                    right = temp;
                }
                else
                {
                    map.Add(_expenses[i]);
                }
            }

            return left * right;
        }
    }

    public static class Part2
    {
        private static int[] _expenses;
        private const int TOTAL = 2020;

        public static int Solve()
        {
            _expenses = Array.ConvertAll(File.ReadAllLines(@"Input\Day1.txt"), int.Parse);
            var map = new HashSet<int>();
            int x = 0, y = 0, z = 0;

            for(int i = 0; i < _expenses.Length; i++)
            {
                var temp1 = TOTAL - _expenses[i];

                for(int j = 0; j < _expenses.Length; j++)
                {
                    var temp2 = temp1 - _expenses[j];

                    if(map.Contains(temp2))
                    {
                        x = _expenses[i];
                        y = _expenses[j];
                        z = temp2;
                    }
                    else
                    {
                        map.Add(_expenses[j]);
                    }
                }
                map.Clear();
            }

            return x * y * z;
        }
    }
}
