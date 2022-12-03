namespace Puzzle03
{
    internal static class PartOne
    {
        private const int MAX_ITEM_ASCII_CODE = 'z';
        private const int MAX_PRIORITY = 52;

        private static readonly int[] _itemPriorities = new int[MAX_ITEM_ASCII_CODE + 1];

        static PartOne()
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

            foreach (var line in lines)
            {
                lineNum++;
                var itemsInBothCompartments = new Dictionary<char, int>();
                var compartment1 = new int[MAX_PRIORITY + 1];
                var compartment2 = new int[MAX_PRIORITY + 1];

                if (line.Length % 2 != 0)
                {
                    throw new ArgumentException($"The content of line {lineNum} is invalid");
                }

                var length = line.Length / 2;

                for (int index = 0; index < length; index++)
                {
                    var item = line[index];
                    sumOfPriorities += ProcessItem(item, compartment1, compartment2, itemsInBothCompartments);

                    item = line[index + length];
                    sumOfPriorities += ProcessItem(item, compartment2, compartment1, itemsInBothCompartments);
                }

                LogItemsInBothCompartments(lineNum, itemsInBothCompartments);
            }

            Console.WriteLine($"Sum of priorities: {sumOfPriorities}");
        }

        private static void LogItemsInBothCompartments(int lineNum, Dictionary<char, int> itemsInBothCompartments)
        {
            var message = string.Join(", ", itemsInBothCompartments.Select(kvp => $"[{kvp.Key}]: {kvp.Value}"));
            Console.WriteLine($"#{lineNum}: {message}");
        }

        private static int ProcessItem(char item, int[] compartment, int[] otherCompartment, Dictionary<char, int> itemsInBothCompartments)
        {
            var priority = _itemPriorities[item];
            compartment[priority]++;

            if (otherCompartment[priority] > 0)
            {
                if (itemsInBothCompartments.ContainsKey(item))
                {
                    itemsInBothCompartments[item]++;
                }
                else
                {
                    itemsInBothCompartments[item] = 1;
                    return priority;
                }
            }

            return 0;
        }
    }
}