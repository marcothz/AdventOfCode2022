namespace Puzzle05;

internal class PartTwo
{
    internal static void Run(Stack<char>[] stacks, IEnumerable<(int source, int destination, int quantity)> moves)
    {
        var transferStack = new Stack<char>();

        foreach (var (source, destination, quantity) in moves)
        {
            for (int i = 0; i < quantity; i++)
            {
                transferStack.Push(stacks[source].Pop());
            }

            while (transferStack.Any())
            {
                stacks[destination].Push(transferStack.Pop());
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