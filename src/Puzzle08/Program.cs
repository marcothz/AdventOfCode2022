namespace Puzzle08;

internal class Program
{
    static void Main(string[] args)
    {
        //var fileName = @"..\..\..\demo-input.txt";
        //var fileName = @"..\..\..\demo-left-right.txt";
        //var fileName = @"..\..\..\demo-right-left.txt";
        //var fileName = @"..\..\..\demo-top-bottom.txt";
        //var fileName = @"..\..\..\demo-bottom-top.txt";
        var fileName = @"..\..\..\input.txt";

        var text = File.ReadAllText(fileName);

        var lines = text.Split('\n', StringSplitOptions.TrimEntries | StringSplitOptions.RemoveEmptyEntries);

        Console.WriteLine(">> PartOne.Run");
        PartOne.Run(lines);

        Console.WriteLine();

        Console.WriteLine(">> PartTwo.Run");
        PartTwo.Run(lines);
    }
}