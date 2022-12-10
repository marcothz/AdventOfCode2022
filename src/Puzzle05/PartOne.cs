namespace Puzzle05;

internal class PartOne
{
    internal static void Run(Stack<char>[] stacks, IEnumerable<(int source, int destination, int quantity)> moves)
    {
        foreach (var (source, destination, quantity) in moves)
        {
            for (int i = 0; i < quantity; i++)
            {
                stacks[destination].Push(stacks[source].Pop());
            }
        }

        var result = "";

        foreach (var stack in stacks)
        {
            result += stack.Peek();
        }

        Console.WriteLine($"After the rearrangement procedure completes, what crate ends up on top of each stack? {result}");
    }
}