using System;
using System.Collections.Generic;
using System.IO;

namespace AdventOfCode2020.Code.Day8
{
    public static class Part1
    {
        private static string[] _instructions;
        public static int Solve()
        {
            _instructions = File.ReadAllLines(@"Input\Day8.txt");
            HashSet<int> past = new HashSet<int>();
            var accumulator = 0;

            for(int i = 0; i < _instructions.Length; i++)
            {
                if (!past.Contains(i))
                {
                    past.Add(i);
                }
                else
                {

                    break;
                }

                var instruction = _instructions[i].Split(' ');
                switch (instruction[0])
                {
                    case "acc":
                        accumulator += int.Parse(instruction[1]);
                        break;
                    case "jmp":
                        i += int.Parse(instruction[1]) - 1;
                        break;
                    case "nop":
                        break;
                }
            }

            return accumulator;
        }
    }

    public static class Part2
    {
        public static int Solve()
        {
            var instructions = File.ReadAllLines(@"Input\Day8.txt");

            var accumulator = 0;
            bool? isSuccess = false;
            (_, _, var executedCode) = ExecuteInstructions(instructions);

            foreach(var index in executedCode)
            {
                string[] fixedInstructions = (string[])instructions.Clone();

                var instruction = fixedInstructions[index].Split(' ');
                switch (instruction[0])
                {
                    case "jmp":
                        fixedInstructions[index] = $"nop {instruction[1]}";
                        break;
                    case "nop":
                        fixedInstructions[index] = $"jmp {instruction[1]}";
                        break;
                    default:
                        break;
                }

                (accumulator, isSuccess, _) = ExecuteInstructions(fixedInstructions);

                if (isSuccess.Value)
                    break;
            }

            return accumulator;
        }

        public static (int, bool?, HashSet<int>) ExecuteInstructions(string[] instructions)
        {
            HashSet<int> past = new HashSet<int>();
            var accumulator = 0;
            bool? isSuccess = null;

            for (int i = 0; i < instructions.Length; i++)
            {
                if (!past.Contains(i))
                {
                    past.Add(i);
                }
                else
                {
                    isSuccess = false;
                    break;
                }

                var instruction = instructions[i].Split(' ');
                switch (instruction[0])
                {
                    case "acc":
                        accumulator += int.Parse(instruction[1]);
                        break;
                    case "jmp":
                        i += int.Parse(instruction[1]) - 1;
                        break;
                    case "nop":
                        break;
                }
            }

            if (isSuccess is null)
                isSuccess = true;

            return (accumulator, isSuccess, past);
        }
    }
}
