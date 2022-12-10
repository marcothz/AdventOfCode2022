namespace Puzzle03;

internal class Program
{
    private static void Main(string[] args)
    {
        //var fileName = @"..\..\..\data\demo-input.txt";
        var fileName = @"..\..\..\data\input.txt";

        var text = File.ReadAllText(fileName);

        var lines = text.Split('\n', StringSplitOptions.TrimEntries);

        Console.WriteLine(">> PartOne.Run");
        PartOne.Run(lines);

        Console.WriteLine();

        Console.WriteLine(">> PartTwo.Run");
        PartTwo.Run(lines);
    }
}