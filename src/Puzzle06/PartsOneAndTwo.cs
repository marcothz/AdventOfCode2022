namespace Puzzle06;

internal static class PartsOneAndTwo
{
    internal static void RunPartOne(string[] lines)
    {
        Run(lines, 4);
    }

    internal static void RunPartTwo(string[] lines)
    {
        Run(lines, 14);
    }

    private static void Run(string[] lines, int markerLength)
    {
        var charCounter = new int[256];
        var marker = new char[markerLength];

        foreach (var line in lines)
        {
            var latestIndex = 0;

            var markerFound = false;

            for (int lineIndex = 0; lineIndex <= line.Length - markerLength; lineIndex++)
            {
                markerFound = true;

                for (int i = 0; i < marker.Length; i++)
                {
                    var currentChar = line[lineIndex + i];
                    charCounter[currentChar]++;
                    marker[i] = currentChar;

                    if (charCounter[currentChar] > 1)
                    {
                        markerFound = false;
                    }
                }

                for (int i = 0; i < marker.Length; i++)
                {
                    charCounter[marker[i]] = 0;
                }

                if (markerFound)
                {
                    latestIndex = lineIndex + marker.Length;
                    break;
                }
            }

            if (markerFound)
            {
                Console.WriteLine($"How many characters need to be processed before the first start-of-packet marker is detected? {latestIndex}");
            }
            else
            {
                Console.WriteLine($"No start-of-packet marker was detected :-(");
            }
        }
    }
}