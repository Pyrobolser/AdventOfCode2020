using System.IO;
using System.Linq;

namespace AdventOfCode2020.Code.Day3
{
    public static class Part1
    {
        private static string[] _rows;
        public static int Solve()
        {
            _rows = File.ReadAllLines(@"Input\Day3.txt");

            var x = 3;
            var trees = 0;
            for(int y = 1; y < _rows.Length; y++)
            {
                if (_rows[y][x] == '#')
                    trees++;
                x = (x + 3) % _rows[y].Length;
            }

            return trees;
        }
    }

    public static class Part2
    {
        private static string[] _rows;
        private static (int X, int Y, int Trees)[] _slopes;

        public static int Solve()
        {
            _rows = File.ReadAllLines(@"Input\Day3.txt");

            _slopes = new (int, int, int)[]
            {
                new (1, 1, 0),
                new (3, 1, 0),
                new (5, 1, 0),
                new (7, 1, 0),
                new (1, 2, 0)
            };

            for(int i = 0; i < _slopes.Length; i++)
            {
                var x = _slopes[i].X;
                for (int y = _slopes[i].Y; y < _rows.Length; y += _slopes[i].Y)
                {
                    if (_rows[y][x] == '#')
                        _slopes[i].Trees++;
                    x = (x + _slopes[i].X) % _rows[y].Length;
                }
            }

            return _slopes.Select(s => s.Trees).Aggregate(1, (x, y) => x * y);
        }
    }
}
