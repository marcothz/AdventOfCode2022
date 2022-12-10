namespace Puzzle04;

internal class Program
{
    private static void Main(string[] args)
    {
        //var fileName = @"..\..\..\demo-input.txt";
        var fileName = @"..\..\..\input.txt";

        var text = File.ReadAllText(fileName);

        var lines = text.Split('\n', StringSplitOptions.TrimEntries);

        Console.WriteLine(">> PartOne.Run");
        PartOne.Run(lines);

        Console.WriteLine();

        Console.WriteLine(">> PartTwo.Run");
        PartTwo.Run(lines);
    }
}