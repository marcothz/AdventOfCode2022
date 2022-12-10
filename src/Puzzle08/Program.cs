namespace Puzzle08;

internal class Program
{
    static void Main(string[] args)
    {
        //var fileName = @"..\..\..\data\demo-input.txt";
        //var fileName = @"..\..\..\data\demo-left-right.txt";
        //var fileName = @"..\..\..\data\demo-right-left.txt";
        //var fileName = @"..\..\..\data\demo-top-bottom.txt";
        //var fileName = @"..\..\..\data\demo-bottom-top.txt";
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