namespace Puzzle09
{
    internal class PartTwo
    {
        internal static void Run(string[] lines)
        {
            var tail = new Knot("tail", 0, 0);
            var knot8 = new Knot("knot8", 0, 0, tail);
            var knot7 = new Knot("knot7", 0, 0, knot8);
            var knot6 = new Knot("knot6", 0, 0, knot7);
            var knot5 = new Knot("knot5", 0, 0, knot6);
            var knot4 = new Knot("knot4", 0, 0, knot5);
            var knot3 = new Knot("knot3", 0, 0, knot4);
            var knot2 = new Knot("knot2", 0, 0, knot3);
            var knot1 = new Knot("knot1", 0, 0, knot2);
            var head = new Knot("head", 0, 0, knot1);

            foreach (var line in lines)
            {
                var move = LineParser.ParseMove(line);

                head.Move(move.direction, move.steps);
            }

            //tail.PrintOccupiedPositions();

            Console.WriteLine($"How many positions does the tail of the rope visit at least once? {tail.TotalOccupiedPositions}");
        }
    }
}