using System.Numerics;

namespace Puzzle11;

internal class Monkey
{
    private readonly int _divisor;
    private readonly int _id;
    private readonly Queue<BigInteger> _items;
    private readonly BigInteger? _leftOperand;
    private readonly int _negativeCondition;
    private readonly char _operator;
    private readonly int _positiveCondition;
    private readonly BigInteger? _rightOperand;
    private int _totalItemsInspected;

    public Monkey(int id, int[] items, int? leftOperand, int? rightOperand, char @operator, int divisor, int positiveCondition, int negativeCondition)
    {
        _id = id;
        _items = new Queue<BigInteger>(items.Select(i => new BigInteger(i)));
        _leftOperand = leftOperand.HasValue ? new BigInteger(leftOperand.Value) : null;
        _rightOperand = rightOperand.HasValue ? new BigInteger(rightOperand.Value) : null; ;
        _operator = @operator;
        _divisor = divisor;
        _positiveCondition = positiveCondition;
        _negativeCondition = negativeCondition;
    }

    public int Id => _id;

    public IEnumerable<BigInteger> Items => _items;

    public int TotalItemsInspected => _totalItemsInspected;

    internal void AddItem(BigInteger item)
    {
        _items.Enqueue(item);
    }

    internal bool HasItems() => _items.Any();

    internal (int monkeyId, BigInteger item) InspectItem(int worryFactor)
    {
        _totalItemsInspected++;
        var item = _items.Dequeue();
        item = ApplyOperation(item);

        item /= worryFactor;

        var nextMonkeyId = item % _divisor == 0 ? _positiveCondition : _negativeCondition;

        return (nextMonkeyId, item);
    }

    private BigInteger ApplyOperation(BigInteger item)
    {
        var leftOperand = _leftOperand ?? item;
        var rightOperand = _rightOperand ?? item;

        var result = _operator == '+'
            ? leftOperand + rightOperand
            : leftOperand * rightOperand;

        //Console.WriteLine($"[{Id}] item={item} => {leftOperand} {_operator} {rightOperand} = {result}");

        return result;
    }
}