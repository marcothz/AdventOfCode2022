namespace Puzzle03
{
    internal static class PartTwo
    {
        private const int MAX_ITEM_ASCII_CODE = 'z';
        private const int MAX_PRIORITY = 52;
        private const int MIN_PRIORITY = 1;
        private static readonly int[] _itemPriorities = new int[MAX_ITEM_ASCII_CODE + 1];

        static PartTwo()
        {
            var priority = 0;

            for (char item = 'a'; item <= 'z'; item++)
            {
                _itemPriorities[item] = ++priority;
            }

            for (char item = 'A'; item <= 'Z'; item++)
            {
                _itemPriorities[item] = ++priority;
            }
        }

        internal static void Run(IEnumerable<string> lines)
        {
            var sumOfPriorities = 0;
            var lineNum = 0;
            var group = new List<string>();

            foreach (var line in lines)
            {
                lineNum++;

                if (group.Count < 3)
                {
                    group.Add(line);
                }

                if (group.Count == 3)
                {
                    sumOfPriorities += ProcessGroup(group.ToArray());

                    group.Clear();
                }
            }

            Console.WriteLine($"Sum of priorities: {sumOfPriorities}");
        }

        private static void ProcessRucksack(string line, int[] rucksack)
        {
            for (int index = 0; index < line.Length; index++)
            {
                var item = line[index];
                var priority = _itemPriorities[item];
                rucksack[priority]++;
            }
        }

        private static int ProcessGroup(string[] groupOfLines)
        {
            var groupOfRucksacks = new int[groupOfLines.Count()][];

            for (int index = 0; index < groupOfRucksacks.Length; index++)
            {
                groupOfRucksacks[index] = new int[MAX_PRIORITY + 1];

                ProcessRucksack(groupOfLines[index], groupOfRucksacks[index]);
            }

            for (int index = MIN_PRIORITY; index <= MAX_PRIORITY; index++)
            {
                if (groupOfRucksacks.All(elf => elf[index] > 0))
                {
                    return index;
                }
            }

            throw new Exception("Badge not found");
        }
    }
}