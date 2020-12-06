using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AdventOfCode2020.Code.Day6
{
    public static class Part1
    {
        private static string[] _answers;

        public static int Solve()
        {
            _answers = File.ReadAllText(@"Input\Day6.txt").Split("\r\n\r\n");
            var counts = 0;
            HashSet<char> uniques;

            foreach(var answer in _answers)
            {
                uniques = new(answer.Replace("\r\n", string.Empty));
                counts += uniques.Count;
            }

            return counts;
        }
    }

    public static class Part2
    {
        private static string[] _answers;

        public static int Solve()
        {
            _answers = File.ReadAllText(@"Input\Day6.txt").Split("\r\n\r\n");
            int counts = 0, same = 0;
            List<char> groupAnswers;

            foreach (var answer in _answers)
            {
                groupAnswers = new(answer.Replace("\r", string.Empty));
                same = groupAnswers.Where(c => c == '\n').Count() + 1;
                counts += groupAnswers.GroupBy(x => x).Where(x => x.Count() == same).Count();
            }

            return counts;
        }
    }
}
