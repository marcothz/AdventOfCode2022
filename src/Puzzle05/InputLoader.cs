using System.Text.RegularExpressions;

namespace Puzzle05;

internal static class InputLoader
{
    public static (Stack<char>[] stacks, (int, int, int)[] moves) Load(string fileName)
    {
        var text = File.ReadAllText(fileName);

        var lines = text.Split('\n');

        var stacks = ParseStacks(lines, out var currentLine);
        var moves = ParseMoves(lines, currentLine);

        return (stacks, moves);
    }

    private static int[] CalculateStackIndexes(string line)
    {
        var index = 1;
        var stackIndexes = new List<int>();

        while (index < line.Length)
        {
            stackIndexes.Add(index);
            index += 4;
        }

        return stackIndexes.ToArray();
    }

    private static Stack<char>[] CreateStacks(int totalStacks)
    {
        var stacks = new Stack<char>[totalStacks];

        for (int index = 0; index < totalStacks; index++)
        {
            stacks[index] = new Stack<char>();
        }

        return stacks;
    }

    private static (int, int, int)[] ParseMoves(string[] lines, int currentLine)
    {
        const string pattern = @"move (\d+) from (\d+) to (\d+)";
        var moves = new List<(int, int, int)>();

        for (currentLine++; currentLine < lines.Length; currentLine++)
        {
            var match = Regex.Match(lines[currentLine], pattern);

            if (match.Success)
            {
                var quantity = int.Parse(match.Groups[1].Value);
                var source = int.Parse(match.Groups[2].Value);
                var destination = int.Parse(match.Groups[3].Value);

                moves.Add((source - 1, destination - 1, quantity));
            }
        }

        return moves.ToArray();
    }

    private static Stack<char>[] ParseStacks(string[] lines, out int currentLine)
    {
        currentLine = 0;

        while (currentLine < lines.Length)
        {
            if (string.IsNullOrWhiteSpace(lines[currentLine]))
            {
                break;
            }

            currentLine++;
        }

        var stackIndexes = CalculateStackIndexes(lines[currentLine - 1]);

        var stacks = CreateStacks(stackIndexes.Length);

        for (int i = currentLine - 2; i >= 0; i--)
        {
            var line = lines[i];

            for (int currentStack = 0; currentStack < stackIndexes.Length; currentStack++)
            {
                var index = stackIndexes[currentStack];

                if (line[index] != ' ')
                {
                    stacks[currentStack].Push(line[index]);
                }
            }
        }

        return stacks;
    }
}