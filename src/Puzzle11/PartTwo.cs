namespace Puzzle11;

internal class PartTwo
{
    internal static void Run(string[] lines)
    {
        var monkeys = MonkeyParser.ParseMonkeys(lines).ToArray();

        for (int round = 0; round < 100; round++)
        {
            foreach (var monkey in monkeys)
            {
                while (monkey.HasItems())
                {
                    var currentItem = monkey.Items.First();
                    var (nextMonkeyId, item) = monkey.InspectItem(1);

                    monkeys[nextMonkeyId].AddItem(item);

                    //Console.WriteLine($"[{monkey.Id}] {currentItem}=>{item} : monkey {nextMonkeyId}");
                }
            }

            Console.WriteLine($"== After round {round + 1} ==");

            //if (round + 1 == 1 || round + 1 == 20 || (round + 1) % 1000 == 0)
            {
                for (int i = 0; i < monkeys.Length; i++)
                {
                    Console.WriteLine($"Monkey {i} inspected items {monkeys[i].TotalItemsInspected} times");
                }
                Console.WriteLine();
            }
        }

        var monkeyBusiness = monkeys.OrderByDescending(m => m.TotalItemsInspected)
            .Select(m => (ulong)m.TotalItemsInspected)
            .Take(2)
            .Aggregate((accumulator, value) => accumulator * value);

        Console.WriteLine($"What is the level of monkey business after 20 rounds of stuff-slinging simian shenanigans? {monkeyBusiness}");
    }
}