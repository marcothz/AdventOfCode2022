namespace Puzzle10;

internal static class LineParser
{
    internal static (InstructionKind kind, int arg, int cycles) GetNextInstruction(string[] lines, ref int lineNum)
    {
        if (lineNum >= lines.Length)
        {
            return (InstructionKind.Undefined, 0, 0);
        }

        var line = lines[lineNum++];

        var columns = line.Split(" ");

        var instruction = Enum.Parse<InstructionKind>(columns[0], ignoreCase: true);
        var arg = instruction == InstructionKind.Addx ? int.Parse(columns[1]) : 0;
        var cycles = instruction == InstructionKind.Addx ? 2 : 1;

        return (instruction, arg, cycles);
    }
}