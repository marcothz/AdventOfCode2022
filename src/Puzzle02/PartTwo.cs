namespace Puzzle02
{
    internal class PartTwo
    {
        private static readonly Dictionary<string, Shape> _oponnentDecoderMap = new()
        {
            { "A", Shape.Rock },
            { "B", Shape.Paper },
            { "C", Shape.Scissors },
        };

        private static readonly Dictionary<Outcome, int> _outcomeValueMap = new()
        {
            { Outcome.Loss, 0 },
            { Outcome.Draw, 3 },
            { Outcome.Win, 6 },
        };

        private static readonly Dictionary<string, Outcome> _playerDecoderMap = new()
        {
            { "X", Outcome.Loss },
            { "Y", Outcome.Draw },
            { "Z", Outcome.Win },
        };

        private static readonly Dictionary<Shape, int> _shapeValueMap = new()
        {
            { Shape.Rock, 1 },
            { Shape.Paper, 2 },
            { Shape.Scissors, 3 },
        };

        public static void Run(string fileName)
        {
            var text = File.ReadAllText(fileName);

            var lines = text.Split('\n');

            var score = 0;

            foreach (var line in lines)
            {
                if (string.IsNullOrWhiteSpace(line))
                {
                    continue;
                }

                var columns = line.Split();

                var oponnentShape = _oponnentDecoderMap[columns[0]];
                var outcome = _playerDecoderMap[columns[1]];

                var playerShape = CalculatePlayerShape(outcome, oponnentShape);

                score += CalculateScore(playerShape, outcome);
            }

            Console.WriteLine($"Part Two - Total score: {score}");
        }

        private static Shape CalculatePlayerShape(Outcome outcome, Shape player2)
        {
            return outcome switch
            {
                Outcome.Loss => player2 == Shape.Rock ? Shape.Scissors : player2 == Shape.Paper ? Shape.Rock : Shape.Paper,
                Outcome.Draw => player2,
                Outcome.Win => player2 == Shape.Rock ? Shape.Paper : player2 == Shape.Paper ? Shape.Scissors : Shape.Rock,
                _ => throw new NotImplementedException(),
            };
        }

        private static int CalculateScore(Shape shape, Outcome outcome)
        {
            return _shapeValueMap[shape] + _outcomeValueMap[outcome];
        }
    }
}