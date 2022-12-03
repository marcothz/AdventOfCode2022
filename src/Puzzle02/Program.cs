namespace Puzzle02
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            //var fileName = @"..\..\..\demo-input.txt";
            var fileName = @"..\..\..\input.txt";

            PartOne.Run(fileName);
            PartTwo.Run(fileName);
        }
    }
}