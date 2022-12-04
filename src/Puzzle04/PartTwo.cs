namespace Puzzle04
{
    internal static class PartTwo
    {
        internal static void Run(string[] lines)
        {
            var result = lines.Where(line => !string.IsNullOrWhiteSpace(line))
               .Select(CreateRanges)
                .Where(RangesOverlap)
                .Count();

            Console.WriteLine($"How many assignment pairs do the ranges overlap? {result}");
        }

        private static ((int, int), (int, int)) CreateRanges(string line)
        {
            var array = line.Split('-', ',')
                .Select(value => int.Parse(value))
                .ToArray();

            return ((array[0], array[1]), (array[2], array[3]));
        }

        private static bool RangesOverlap(((int start, int end) range1, (int start, int end) range2) ranges)
        {
            // range 1: ----------*^^^^^^^^^^^^*----------

            // range 2: --*~~~~*--|------------|----------
            // range 2: ----------|------------|--*~~~~*--

            // range 2: -----*~~~~*------------|----------  <<
            // range 2: ----------|------------*~~~~~*----  <<

            // range 2: -----*~~~~|~~*---------|----------  <<
            // range 2: ----------|---------*~~|~~~~*-----  <<

            // range 2: -----*~~~~|~~~~~~~~~~~~*----------  <<
            // range 2: ----------*~~~~~~~~~~~~|~~~~*-----  <<

            // range 2: ------*~~~|~~~~~~~~~~~~|~~~*------  <<
            // range 2: ----------*~~~~~~~~~~~~*----------  <<
            // range 2: ----------|-*~~~~~~~~*-|----------  <<

            if (ranges.range1.start > ranges.range2.end || ranges.range1.end < ranges.range2.start)
            {
                Console.WriteLine(ranges);
                return false;
            }

            Console.WriteLine($"{ranges} << overlap");
            return true;
        }
    }
}