using System.IO;
using System.Text.RegularExpressions;

namespace AdventOfCode2020.Code.Day4
{
    public static class Part1
    {
        private static string[] _passports;

        public static int Solve()
        {
            _passports = File.ReadAllText(@"Input\Day4.txt").Split("\r\n\r\n");

            int valids = 0;
            string pattern = @"(\b(byr|iyr|eyr|hgt|hcl|ecl|pid)\b.*){7}";

            for (int i = 0; i < _passports.Length; i++)
            {
                _passports[i] = Regex.Replace(_passports[i], @"\r\n", " ", RegexOptions.Compiled);

                if (Regex.IsMatch(_passports[i], pattern, RegexOptions.Compiled))
                    valids++;
            }

            return valids;
        }
    }

    public static class Part2
    {
        private static string[] _passports;

        public static int Solve()
        {
            _passports = File.ReadAllText(@"Input\Day4.txt").Split("\r\n\r\n");

            int valids = 0;
            string pattern = @"(?:\b(?:(?:byr:(?<byr>\d{4}))|(?:iyr:(?<iyr>\d{4}))|(?:eyr:(?<eyr>\d{4}))|(?:hgt:(?<hgt>\d+)(?<unit>in|cm))|(?:hcl:#[0-9a-f]{6})|(?:ecl:(?:amb|blu|brn|gry|grn|hzl|oth))|(?:pid:\d{9}))\b.*){7}";

            for (int i = 0; i < _passports.Length; i++)
            {
                _passports[i] = Regex.Replace(_passports[i], @"\r\n", " ", RegexOptions.Compiled);

                Match match = Regex.Match(_passports[i], pattern);
                if (match.Success)
                {
                    if (int.Parse(match.Groups["byr"].Value) is not (>= 1920 and <= 2002)) continue;
                    if (int.Parse(match.Groups["iyr"].Value) is not (>= 2010 and <= 2020)) continue;
                    if (int.Parse(match.Groups["eyr"].Value) is not (>= 2020 and <= 2030)) continue;
                    if ((match.Groups["unit"].Value == "cm" && int.Parse(match.Groups["hgt"].Value) is >= 150 and <= 193)
                        || (match.Groups["unit"].Value == "in" && int.Parse(match.Groups["hgt"].Value) is >= 59 and <= 76)) valids++;
                }
            }

            return valids;
        }
    }
}
