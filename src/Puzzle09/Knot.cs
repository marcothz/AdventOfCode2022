namespace Puzzle09;

internal class Knot
{
    private readonly Knot? _followerKnot;
    private Dictionary<(int, int), int> _occupiedPositions = new();

    public Knot(string name, int x, int y)
    {
        Name = name;
        X = x;
        Y = y;

        CountCurrentPosition();
    }

    public Knot(string name, int x, int y, Knot followerKnot)
    {
        Name = name;
        X = x;
        Y = y;
        _followerKnot = followerKnot;
    }

    public bool IsTail => _followerKnot == null;

    public string Name { get; }

    public int TotalOccupiedPositions => _occupiedPositions.Count;

    public int X { get; private set; }

    public int Y { get; private set; }

    public void Move(char direction, int steps)
    {
        for (int i = 0; i < steps; i++)
        {
            switch (direction)
            {
                case 'L':
                    X--;
                    break;

                case 'R':
                    X++;
                    break;

                case 'U':
                    Y++;
                    break;

                case 'D':
                    Y--;
                    break;
            }

            _followerKnot?.KnotAheadMoved(X, Y);
        }
    }

    public void PrintOccupiedPositions()
    {
        Console.WriteLine("-- PrintOccupiedPositions");

        foreach (var key in _occupiedPositions)
        {
            Console.WriteLine(key);
        }
    }

    internal void KnotAheadMoved(int x, int y)
    {
        var horizontalDistance = HorizontalDistance(x);
        var verticalDistance = VerticalDistance(y);

        if (horizontalDistance > 1 || verticalDistance > 1)
        {
            MoveTowardsKnotAhead(x, y, horizontalDistance, verticalDistance);
        }
    }

    private void CountCurrentPosition()
    {
        var position = (X, Y);

        if (!_occupiedPositions.ContainsKey(position))
        {
            _occupiedPositions[position] = 0;
        }

        _occupiedPositions[position]++;
    }

    //  2 2(2)2 2
    //  2 1 1 1 2
    // (2)1 A 1(2)
    //  2 1 1 1 2
    //  2 2(2)2 2
    private int HorizontalDistance(int x)
    {
        return Math.Abs(X - x);
    }

    private void MoveTowardsKnotAhead(int x, int y, int horizontalDistance, int verticalDistance)
    {
        if (horizontalDistance > 0)
        {
            MoveTowardsKnotAheadHorizontally(x);
        }

        if (verticalDistance > 0)
        {
            MoveTowardsKnotAheadVertically(y);
        }

        CountCurrentPosition();

        _followerKnot?.KnotAheadMoved(X, Y);
    }

    private void MoveTowardsKnotAheadHorizontally(int x)
    {
        X += x > X ? 1 : -1;
    }

    private void MoveTowardsKnotAheadVertically(int y)
    {
        Y += y > Y ? 1 : -1;
    }

    private int VerticalDistance(int y)
    {
        return Math.Abs(Y - y);
    }
}