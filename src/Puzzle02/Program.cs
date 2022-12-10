namespace Puzzle02;

internal class Program
{
    private static void Main(string[] args)
    {
        //var fileName = @"..\..\..\data\demo-input.txt";
        var fileName = @"..\..\..\data\input.txt";

        PartOne.Run(fileName);
        PartTwo.Run(fileName);
    }
}