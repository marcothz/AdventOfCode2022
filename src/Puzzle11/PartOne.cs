namespace Puzzle11;

internal class PartOne
{
    internal static void Run(string[] lines)
    {
        var monkeys = MonkeyParser.ParseMonkeys(lines).ToArray();

        Console.WriteLine($"The monkeys are holding items with these worry levels ({monkeys.Select(m => m.Items.Count()).Sum()}):");
        for (int i = 0; i < monkeys.Length; i++)
        {
            Console.WriteLine($"Monkey {i}: {string.Join(", ", monkeys[i].Items)} => {monkeys[i].TotalItemsInspected}");
        }
        Console.WriteLine();

        for (int round = 0; round < 20; round++)
        {
            //Console.WriteLine($"Round {round + 1}");

            foreach (var monkey in monkeys)
            {
                while (monkey.HasItems())
                {
                    var (nextMonkeyId, item) = monkey.InspectItem(3);

                    monkeys[nextMonkeyId].AddItem(item);
                }
            }

            Console.WriteLine($"After round {round + 1}, the monkeys are holding items with these worry levels ({monkeys.Select(m => m.Items.Count()).Sum()}):");
            for (int i = 0; i < monkeys.Length; i++)
            {
                Console.WriteLine($"Monkey {i}: {string.Join(", ", monkeys[i].Items)} => {monkeys[i].TotalItemsInspected}");
            }
            Console.WriteLine();
        }

        var monkeyBusiness = monkeys.OrderByDescending(m => m.TotalItemsInspected)
            .Select(m => m.TotalItemsInspected)
            .Take(2)
            .Aggregate((accumulator, value) => accumulator * value);

        Console.WriteLine($"What is the level of monkey business after 20 rounds of stuff-slinging simian shenanigans? {monkeyBusiness}");
    }
}