namespace Puzzle09;

internal class PartOne
{
    internal static void Run(string[] lines)
    {
        var tail = new Knot("tail", 0, 0);
        var head = new Knot("head", 0, 0, tail);

        foreach (var line in lines)
        {
            var move = LineParser.ParseMove(line);

            //var headPrevPos = (head.X, head.Y);
            //var tailPrevPos = (tail.X, tail.Y);

            head.Move(move.direction, move.steps);

            //Console.WriteLine($"\tHead: ({headPrevPos}) => ({((head.X, head.Y))})");
            //Console.WriteLine($"\tTail: ({tailPrevPos}) => ({((tail.X, tail.Y))})");
        }

        Console.WriteLine($"How many positions does the tail of the rope visit at least once? {tail.TotalOccupiedPositions}");
    }
}