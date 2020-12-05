using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AdventOfCode2020.Code.Day5
{
    public static class Part1
    {
        private static string[] _passes;
        private const int ROWMIN = 0, ROWMAX = 127, COLMIN = 0, COLMAX = 7;

        public static int Solve()
        {
            _passes = File.ReadAllLines(@"Input\Day5.txt");
            var maxSeatId = 0;

            foreach(var pass in _passes)
            {
                int passRowMin = ROWMIN, passRowMax = ROWMAX, passColMin = COLMIN, passColMax = COLMAX;
                bool isSmaller = false;

                for(int i = 0; i < 10; i++)
                {

                    switch (pass[i])
                    {
                        case 'F':
                            passRowMax = passRowMin + (passRowMax - passRowMin) / 2;
                            break;
                        case 'B':
                            passRowMin = passRowMax - (passRowMax - passRowMin) / 2;
                            break;
                        case 'L':
                            passColMax = passColMin + (passColMax - passColMin) / 2;
                            break;
                        case 'R':
                            passColMin = passColMax - (passColMax - passColMin) / 2;
                            break;
                    }

                    if((passRowMax * 8) + passColMax < maxSeatId)
                    {
                        isSmaller = true;
                        break;
                    }
                }

                if (isSmaller) continue;

                maxSeatId = (passRowMax * 8) + passColMax;
            }

            return maxSeatId;
        }
    }

    public static class Part2
    {
        private static string[] _passes;
        private static HashSet<int> _ids = new();
        private const int ROWMIN = 0, ROWMAX = 127, COLMIN = 0, COLMAX = 7;

        public static int Solve()
        {
            _passes = File.ReadAllLines(@"Input\Day5.txt");
            var seatId = 0;

            foreach (var pass in _passes)
            {
                int passRowMin = ROWMIN, passRowMax = ROWMAX, passColMin = COLMIN, passColMax = COLMAX;

                for (int i = 0; i < 10; i++)
                {

                    switch (pass[i])
                    {
                        case 'F':
                            passRowMax = passRowMin + (passRowMax - passRowMin) / 2;
                            break;
                        case 'B':
                            passRowMin = passRowMax - (passRowMax - passRowMin) / 2;
                            break;
                        case 'L':
                            passColMax = passColMin + (passColMax - passColMin) / 2;
                            break;
                        case 'R':
                            passColMin = passColMax - (passColMax - passColMin) / 2;
                            break;
                    }
                }

                _ids.Add((passRowMax * 8) + passColMax);
            }

            for(int id = _ids.Min(); id < _ids.Max(); id++)
            {
                if(!_ids.Contains(id))
                {
                    seatId = id;
                    break;
                }
            }

            return seatId;
        }
    }
}
