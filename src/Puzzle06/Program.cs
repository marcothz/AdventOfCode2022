namespace Puzzle06
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            //var fileName = @"..\..\..\demo-input.txt";
            //var fileName = @"..\..\..\demo-input-2.txt";
            var fileName = @"..\..\..\input.txt";

            var text = File.ReadAllText(fileName);

            var lines = text.Split('\n', StringSplitOptions.TrimEntries | StringSplitOptions.RemoveEmptyEntries);

            Console.WriteLine(">> PartOne.Run");
            PartsOneAndTwo.RunPartOne(lines);

            Console.WriteLine();

            Console.WriteLine(">> PartTwo.Run");
            PartsOneAndTwo.RunPartTwo(lines);
        }
    }
}