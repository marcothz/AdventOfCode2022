namespace Puzzle05;

internal class Program
{
    private static void Main(string[] args)
    {
        //var fileName = @"..\..\..\data\demo-input.txt";
        var fileName = @"..\..\..\data\input.txt";

        Console.WriteLine(">> PartOne.Run");
        var input = InputLoader.Load(fileName);
        PartOne.Run(input.stacks, input.moves);

        Console.WriteLine();

        Console.WriteLine(">> PartTwo.Run");
        input = InputLoader.Load(fileName);
        PartTwo.Run(input.stacks, input.moves);
    }
}