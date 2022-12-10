namespace Puzzle10;

internal partial class PartOne
{
    internal static void Run(string[] lines)
    {
        var x = 1;
        var lineNum = 0;
        var interestingCycle = 20;
        var sumOfSignalStrenght = 0;

        var instruction = LineParser.GetNextInstruction(lines, ref lineNum);

        for (int cycle = 1; cycle <= 220; cycle++)
        {
            if (instruction.kind == InstructionKind.Undefined)
            {
                break;
            }

            //Console.WriteLine($"during cycle {cycle}: x={x}, instruction={instruction}");

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

        Console.WriteLine($"What is the sum of these six signal strengths? {sumOfSignalStrenght}");
    }
}