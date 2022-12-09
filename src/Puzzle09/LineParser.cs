namespace Puzzle09
{
    internal static class LineParser
    {
        public static (char direction, int steps) ParseMove(string line)
        {
            var columns = line.Split(' ');
            var direction = columns[0].First();
            var steps = int.Parse(columns[1]);

            //Console.WriteLine($"Move: {(direction, steps)}");

            return (direction, steps);
        }
    }
}