namespace Puzzle02;

internal class PartOne
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

    private static readonly Dictionary<string, Shape> _playerDecoderMap = new()
    {
        { "X", Shape.Rock },
        { "Y", Shape.Paper },
        { "Z", Shape.Scissors },
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
            var playerShape = _playerDecoderMap[columns[1]];

            var outcome = CalculateOutcome(playerShape, oponnentShape);

            score += CalculateScore(playerShape, outcome);
        }

        Console.WriteLine($"Part One - Total score: {score}");
    }

    private static Outcome CalculateOutcome(Shape player1, Shape player2)
    {
        return player1 switch
        {
            Shape.Rock => player2 == Shape.Rock ? Outcome.Draw : player2 == Shape.Paper ? Outcome.Loss : Outcome.Win,
            Shape.Paper => player2 == Shape.Paper ? Outcome.Draw : player2 == Shape.Scissors ? Outcome.Loss : Outcome.Win,
            Shape.Scissors => player2 == Shape.Scissors ? Outcome.Draw : player2 == Shape.Rock ? Outcome.Loss : Outcome.Win,
            _ => throw new NotImplementedException(),
        };
    }

    private static int CalculateScore(Shape shape, Outcome outcome)
    {
        return _shapeValueMap[shape] + _outcomeValueMap[outcome];
    }
}