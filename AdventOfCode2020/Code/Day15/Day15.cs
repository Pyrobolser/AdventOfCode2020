using System;
using System.Collections.Generic;
using System.IO;

namespace AdventOfCode2020.Code.Day15
{
    public static class Part1
    {
        private static int _turn = 1;
        private static int[] _starters;
        public static int Solve()
        {
            _starters = Array.ConvertAll(File.ReadAllText(@"Input\Day15.txt").Split(','), int.Parse);
            int before = 0;
            Dictionary<int, (int before, int now)> _numbers = new();

            for (; _turn <= _starters.Length; _turn++)
            {
                before = _starters[_turn - 1];
                _numbers[before] = (_turn, 0);
            }

            while(_turn <= 2020)
            {
                var number = _numbers.GetValueOrDefault(before);
                if(number.now == 0)
                {
                    before = 0;
                }
                else
                {
                    before = number.now - number.before;
                }

                var nextNumber = _numbers.GetValueOrDefault(before);
                if(nextNumber.before == 0)
                {
                    _numbers[before] = (_turn, 0);
                }
                else if (nextNumber.now == 0)
                {
                    _numbers[before] = (nextNumber.before, _turn);
                }
                else
                {
                    _numbers[before] = (nextNumber.now, _turn);
                }

                _turn++;
            }

            return before;
        }
    }

    public static class Part2
    {
        private static int _turn = 1;
        private static int[] _starters;
        public static int Solve()
        {
            _starters = Array.ConvertAll(File.ReadAllText(@"Input\Day15.txt").Split(','), int.Parse);
            int before = 0;
            Dictionary<int, (int before, int now)> _numbers = new();

            for (; _turn <= _starters.Length; _turn++)
            {
                before = _starters[_turn - 1];
                _numbers[before] = (_turn, 0);
            }

            while (_turn <= 30000000)
            {
                var number = _numbers.GetValueOrDefault(before);
                if (number.now == 0)
                {
                    before = 0;
                }
                else
                {
                    before = number.now - number.before;
                }

                var nextNumber = _numbers.GetValueOrDefault(before);
                if (nextNumber.before == 0)
                {
                    _numbers[before] = (_turn, 0);
                }
                else if (nextNumber.now == 0)
                {
                    _numbers[before] = (nextNumber.before, _turn);
                }
                else
                {
                    _numbers[before] = (nextNumber.now, _turn);
                }

                _turn++;
            }

            return before;
        }
    }
}
