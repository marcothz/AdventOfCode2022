namespace Puzzle10;

internal class Program
{
    private static void Main(string[] args)
    {
        //var fileName = @"..\..\..\data\demo-input-1.txt";
        //var fileName = @"..\..\..\data\demo-input-2.txt";
        var fileName = @"..\..\..\data\input.txt";

        var text = File.ReadAllText(fileName);

        var lines = text.Split('\n', StringSplitOptions.TrimEntries | StringSplitOptions.RemoveEmptyEntries);

        Console.WriteLine(">> PartOne.Run");
        PartOne.Run(lines);

        Console.WriteLine();

        Console.WriteLine(">> PartTwo.Run");
        PartTwo.Run(lines);
    }
}