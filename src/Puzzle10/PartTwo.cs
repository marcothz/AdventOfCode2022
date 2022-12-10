using System.Text;

namespace Puzzle10;

internal partial class PartTwo
{
    internal static void Run(string[] lines)
    {
        var x = 1;
        var lineNum = 0;
        var interestingCycle = 20;
        var sumOfSignalStrenght = 0;
        var crt = new char[240];
        var position = 0;

        var instruction = LineParser.GetNextInstruction(lines, ref lineNum);

        for (int cycle = 1; cycle <= 240; cycle++)
        {
            if (instruction.kind == InstructionKind.Undefined)
            {
                break;
            }

            //Console.WriteLine($"during cycle {cycle}: x={x}, instruction={instruction}");

            crt[cycle - 1] = Math.Abs(position - x) <= 1 ? '#' : ' ';
            position = position + 1 == 40 ? 0 : position + 1;

            if (cycle == interestingCycle)
            {
                sumOfSignalStrenght += x * cycle;
                interestingCycle += 40;
            }

            switch (instruction.kind)
            {
                case InstructionKind.Noop:
                    instruction.cycles--;
                    break;

                case InstructionKind.Addx:
                    instruction.cycles--;

                    if (instruction.cycles == 0)
                    {
                        x += instruction.arg;
                    }

                    break;
            }

            //Console.WriteLine($"after cycle: {cycle}, x: {x}, instruction: {instruction}");

            if (instruction.cycles == 0)
            {
                instruction = LineParser.GetNextInstruction(lines, ref lineNum);
            }
        }

        PrintCrt(crt);
    }

    private static void PrintCrt(char[] crt)
    {
        var buffer = new StringBuilder();

        for (int i = 0; i < 6; i++)
        {
            buffer.AppendLine(string.Join("", crt.Skip(i * 40).Take(40)));
        }

        Console.WriteLine();
        Console.WriteLine(buffer.ToString());
    }
}