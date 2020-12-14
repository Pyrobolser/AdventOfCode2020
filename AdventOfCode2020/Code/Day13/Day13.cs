using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AdventOfCode2020.Code.Day13
{
    public static class Part1
    {
        public static int _timeStamp;
        public static int[] _buses;
        public static int Solve()
        {
            string[] text = File.ReadAllLines(@"Input\Day13.txt");
            _timeStamp = int.Parse(text[0]);
            _buses = Array.ConvertAll(text[1].Split(new char[] { ',', 'x' }, StringSplitOptions.RemoveEmptyEntries), int.Parse);

            var waitTime = int.MaxValue;
            var busId = 0;
            for(int i = 0; i < _buses.Length; i++)
            {
                var loops = _timeStamp / _buses[i];
                var currentWaitTime = ((loops + 1) * _buses[i]) - _timeStamp;

                if (currentWaitTime < waitTime)
                {
                    waitTime = currentWaitTime;
                    busId = _buses[i];
                }
            }

            return busId * waitTime;
        }
    }

    public static class Part2
    {
        public static string[] _busIDs;
        public static long Solve()
        {
            string[] text = File.ReadAllLines(@"Input\Day13.txt");
            _busIDs = text[1].Split(',');
            Dictionary<int, int> _alignment = new ();

            for(int i = 0; i < _busIDs.Length; i++)
            {
                if(int.TryParse(_busIDs[i], out int busId))
                {
                    _alignment[busId] = i;
                }
            }

            long time = _alignment.First().Key;
            long multiplier = _alignment.First().Key;
            foreach (var bus in _alignment.Skip(1))
            {
                while((time + bus.Value) % bus.Key != 0)
                {
                    time += multiplier;
                }
                multiplier *= bus.Key;
            }

            return time;
        }
    }
}
