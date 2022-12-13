using System.Text.RegularExpressions;

namespace Puzzle11;

internal static class MonkeyParser
{
    private const string MonkeyIdPattern = @"^Monkey (\d+):$";
    private const string OperationPattern = @"^Operation: new = (\w+) ([+*]) (\w+)$";
    private const string StartingItemsPattern = @"\d+";
    private const string TestPattern = @"Test: divisible by (\d+)";
    private const string ConditionPattern = @"If (?:true|false): throw to monkey (\d+)";

    internal static IEnumerable<Monkey> ParseMonkeys(string[] lines)
    {
        var lineNum = 0;
        var monkeys = new List<Monkey>();

        while (lineNum < lines.Length)
        {
            try
            {
                var id = ParseMonkeyId(lines[lineNum++]);
                var items = ParseStartingItems(lines[lineNum++]).ToArray();
                var (leftOperand, rightOperand, @operator) = ParseOperation(lines[lineNum++]);
                var divisor = ParseTest(lines[lineNum++]);
                var positiveCondition = ParseCondition(lines[lineNum++]);
                var negativeCondition = ParseCondition(lines[lineNum++]);

                var monkey = new Monkey(
                    id,
                    items,
                    leftOperand,
                    rightOperand,
                    @operator,
                    divisor,
                    positiveCondition,
                    negativeCondition);

                monkeys.Add(monkey);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while parsing line #{lineNum}. {ex}");
            }
        }

        return monkeys;
    }

    private static int ParseCondition(string line)
    {
        var match = Regex.Match(line, ConditionPattern);

        if (!match.Success)
        {
            throw new ArgumentException("Could not parse condition");
        }

        return int.Parse(match.Groups[1].Value);
    }

    private static int ParseTest(string line)
    {
        var match = Regex.Match(line, TestPattern);

        if (!match.Success)
        {
            throw new ArgumentException("Could not parse test");
        }

        return int.Parse(match.Groups[1].Value);
    }

    private static int ParseMonkeyId(string line)
    {
        var match = Regex.Match(line, MonkeyIdPattern);

        if (!match.Success)
        {
            throw new ArgumentException("Could not parse monkey ID");
        }

        return int.Parse(match.Groups[1].Value);
    }

    private static (int? leftOperand, int? rightOperand, char @operator) ParseOperation(string line)
    {
        var match = Regex.Match(line, OperationPattern);

        if (!match.Success)
        {
            throw new ArgumentException("Could not parse operation");
        }

        var value = match.Groups[1].Value;

        int? leftOperand = null;

        if (string.Compare(value, "old", ignoreCase: true) != 0)
        {
            leftOperand = int.Parse(value);
        }

        value = match.Groups[3].Value;

        int? rightOperand = null;

        if (string.Compare(value, "old", ignoreCase: true) != 0)
        {
            rightOperand = int.Parse(value);
        }

        var @operator = match.Groups[2].Value.Trim().First();

        return (leftOperand, rightOperand, @operator);
    }

    private static IEnumerable<int> ParseStartingItems(string line)
    {
        var matches = Regex.Matches(line, StartingItemsPattern);

        if (!matches.Any())
        {
            throw new ArgumentException("Could not parse starting items");
        }

        for (int i = 0; i < matches.Count; i++)
        {
            yield return int.Parse(matches[i].Value);
        }
    }
}