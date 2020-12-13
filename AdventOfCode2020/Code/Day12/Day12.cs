using System;
using System.IO;

namespace AdventOfCode2020.Code.Day12
{
    public static class Part1
    {
        private static string[] _actions;
        private static int _northPos = 0, _eastPos = 0;
        private static char _direction = 'E';
        private static readonly char[] _directions = new[] { 'N', 'E', 'S', 'W' };
        public static int Solve()
        {
            _actions = File.ReadAllLines(@"Input\Day12.txt");

            for (int i = 0; i < _actions.Length; i++)
            {
                var action = _actions[i][0];
                var value = int.Parse(_actions[i][1..]);

                switch (action)
                {
                    case 'N':
                        _northPos += value;
                        break;
                    case 'S':
                        _northPos -= value;
                        break;
                    case 'E':
                        _eastPos += value;
                        break;
                    case 'W':
                        _eastPos -= value;
                        break;
                    case 'L':
                        _direction = _directions[(Array.IndexOf(_directions, _direction) - (value / 90) + _directions.Length) % _directions.Length];
                        break;
                    case 'R':
                        _direction = _directions[(Array.IndexOf(_directions, _direction) + (value / 90)) % _directions.Length];
                        break;
                    case 'F':
                        switch (_direction)
                        {
                            case 'N':
                                _northPos += value;
                                break;
                            case 'S':
                                _northPos -= value;
                                break;
                            case 'E':
                                _eastPos += value;
                                break;
                            case 'W':
                                _eastPos -= value;
                                break;
                        }
                        break;
                }
            }

            return Math.Abs(_northPos) + Math.Abs(_eastPos);
        }
    }

    public static class Part2
    {
        private static string[] _actions;
        private static int _shipNPos = 0, _shipEPos = 0;
        private static int _wpNPos = 1, _wpEPos = 10;
        public static int Solve()
        {
            _actions = File.ReadAllLines(@"Input\Day12.txt");

            for (int i = 0; i < _actions.Length; i++)
            {
                var action = _actions[i][0];
                var value = int.Parse(_actions[i][1..]);
                int tempN = 0, tempE = 0;

                switch (action)
                {
                    case 'N':
                        _wpNPos += value;
                        break;
                    case 'S':
                        _wpNPos -= value;
                        break;
                    case 'E':
                        _wpEPos += value;
                        break;
                    case 'W':
                        _wpEPos -= value;
                        break;
                    case 'L':
                        tempN = _wpNPos;
                        tempE = _wpEPos;

                        switch (value)
                        {
                            case 90:
                                _wpNPos = tempE;
                                _wpEPos = -1 * tempN;
                                break;
                            case 180:
                                _wpNPos *= -1;
                                _wpEPos *= -1;
                                break;
                            case 270:
                                _wpNPos = -1 * tempE;
                                _wpEPos = tempN;
                                break;
                        }
                        break;
                    case 'R':
                        tempN = _wpNPos;
                        tempE = _wpEPos;

                        switch (value)
                        {
                            case 90:
                                _wpNPos = -1 * tempE;
                                _wpEPos = tempN;
                                break;
                            case 180:
                                _wpNPos *= -1;
                                _wpEPos *= -1;
                                break;
                            case 270:
                                _wpNPos = tempE;
                                _wpEPos = -1 * tempN;
                                break;
                        }
                        break;
                    case 'F':
                        _shipNPos += value * _wpNPos;
                        _shipEPos += value * _wpEPos;
                        break;
                }
            }

            return Math.Abs(_shipNPos) + Math.Abs(_shipEPos);
        }
    }
}
