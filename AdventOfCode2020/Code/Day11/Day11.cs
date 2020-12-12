using System.IO;

namespace AdventOfCode2020.Code.Day11
{
    public static class Part1
    {
        private static char[,] _seats;
        private static int _occupiedSeats;
        public static int Solve()
        {
            var text = File.ReadAllLines(@"Input\Day11.txt");
            _seats = new char[text[0].Length, text.Length];

            for(int y = 0; y < text.Length; y++)
            {
                for(int x = 0; x < text[y].Length; x++)
                {
                    _seats[x, y] = text[y][x];
                }
            }
            var nextSeats = (char[,])_seats.Clone();

            _occupiedSeats = 0;
            var hasChanged = false;
            do
            {
                nextSeats = (char[,])_seats.Clone();
                hasChanged = false;

                for (int x = 0; x < _seats.GetLength(0); x++)
                {
                    for (int y = 0; y < _seats.GetLength(1); y++)
                    {
                        if (_seats[x, y] != '.')
                        {
                            var occupied = GetNeighbors(x, y);

                            if (_seats[x, y] == 'L' && occupied == 0)
                            {
                                nextSeats[x, y] = '#';
                                _occupiedSeats++;
                                hasChanged = true;
                            }
                            else if (_seats[x, y] == '#' && occupied >= 4)
                            {
                                nextSeats[x, y] = 'L';
                                _occupiedSeats--;
                                hasChanged = true;
                            }
                        }
                    }
                }

                _seats = nextSeats;

            } while (hasChanged);

            return _occupiedSeats;
        }

        public static int GetNeighbors(int x, int y)
        {
            int occupied = 0;

            for (int a = (x - 1); a <= (x + 1); a++)
            {
                if (a < 0 || a >= _seats.GetLength(0))
                    continue;

                for(int b = (y - 1); b <= (y + 1); b++)
                {
                    if (b < 0 || b >= _seats.GetLength(1) || (x == a && y == b))
                    {
                        continue;
                    }
                    else if (_seats[a, b] == '#')
                    {
                        occupied++;
                    }
                }
            }

            return occupied;
        }
    }

    public static class Part2
    {
        private static char[,] _seats;
        private static int _occupiedSeats;
        public static int Solve()
        {
            var text = File.ReadAllLines(@"Input\Day11.txt");
            _seats = new char[text[0].Length, text.Length];

            for (int y = 0; y < text.Length; y++)
            {
                for (int x = 0; x < text[y].Length; x++)
                {
                    _seats[x, y] = text[y][x];
                }
            }
            var nextSeats = (char[,])_seats.Clone();

            _occupiedSeats = 0;
            var hasChanged = false;
            do
            {
                nextSeats = (char[,])_seats.Clone();
                hasChanged = false;

                for (int x = 0; x < _seats.GetLength(0); x++)
                {
                    for (int y = 0; y < _seats.GetLength(1); y++)
                    {
                        if (_seats[x, y] != '.')
                        {
                            var occupied = GetNeighbors(x, y);

                            if (_seats[x, y] == 'L' && occupied == 0)
                            {
                                nextSeats[x, y] = '#';
                                _occupiedSeats++;
                                hasChanged = true;
                            }
                            else if (_seats[x, y] == '#' && occupied >= 5)
                            {
                                nextSeats[x, y] = 'L';
                                _occupiedSeats--;
                                hasChanged = true;
                            }
                        }
                    }
                }

                _seats = nextSeats;

            } while (hasChanged);

            return _occupiedSeats;
        }

        public static int GetNeighbors(int x, int y)
        {
            int occupied = 0;
            for (int deltaX = - 1; deltaX <= 1; deltaX++)
            {
                for (int deltaY = - 1; deltaY <= 1; deltaY++)
                {
                    int step = 1, localDX = deltaX, localDY = deltaY;
                    while (true)
                    {
                        if ((x + localDX) < 0 || (x + localDX) >= _seats.GetLength(0) || (y + localDY) < 0 || (y + localDY) >= _seats.GetLength(1) || localDX == 0 && localDY == 0)
                        {
                            break;
                        }
                        else if (_seats[(x + localDX), (y + localDY)] == '#')
                        {
                            occupied++;
                            break;
                        }
                        else if (_seats[(x + localDX), (y + localDY)] == '.')
                        {
                            step++;
                            localDX = (deltaX * step);
                            localDY = (deltaY * step);
                        }
                        else
                        {
                            break;
                        }
                    }
                }
            }

            return occupied;
        }
    }
}
