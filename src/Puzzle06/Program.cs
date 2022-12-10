namespace Puzzle06;

internal class Program
{
    private static void Main(string[] args)
    {
        //var fileName = @"..\..\..\data\demo-input.txt";
        //var fileName = @"..\..\..\data\demo-input-2.txt";
        var fileName = @"..\..\..\data\input.txt";

        var text = File.ReadAllText(fileName);

        var lines = text.Split('\n', StringSplitOptions.TrimEntries | StringSplitOptions.RemoveEmptyEntries);

        Console.WriteLine(">> PartOne.Run");
        PartsOneAndTwo.RunPartOne(lines);

        Console.WriteLine();

        Console.WriteLine(">> PartTwo.Run");
        PartsOneAndTwo.RunPartTwo(lines);
    }
}