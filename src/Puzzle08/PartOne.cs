using System.Text;

namespace Puzzle08
{
    internal class PartOne
    {
        internal static void Run(string[] lines)
        {
            var visibleTrees = new Dictionary<(int, int), Side>();

            var totalRows = lines.Length;
            var totalCols = lines[0].Length;

            TraverseLeftToRight(lines, visibleTrees, totalCols, totalRows);
            TraverseRightToLeft(lines, visibleTrees, totalCols, totalRows);
            TraverseTopToBottom(lines, visibleTrees, totalCols, totalRows);
            TraverseBottomToTop(lines, visibleTrees, totalCols, totalRows);

            var edgeTree = visibleTrees.Values.Count(s => s == Side.Edge);
            Console.WriteLine($"Trees visible on the edge: {edgeTree}");

            Console.WriteLine($"How many trees are visible from outside the grid? {visibleTrees.Values.Count}");

            PrintVisibilityMap(lines, visibleTrees);
        }

        private static int CheckVisibility(Side side, int row, int col, int width, int height, string[] lines, Dictionary<(int, int), Side> visibleTrees, int maxSize)
        {
            var size = lines[row][col] - '0';

            if (IsAroundTheEdge(row, col, height, width))
            {
                MarkTreeAsVisible(row, col, Side.Edge, visibleTrees);
            }
            else if (size > maxSize)
            {
                MarkTreeAsVisible(row, col, side, visibleTrees);
            }

            //Console.WriteLine($"({row},{col})={size} => {(visibleTrees.ContainsKey((row, col)) ? visibleTrees[(row, col)] : Side.NotVisible)}");

            maxSize = Math.Max(maxSize, size);
            return maxSize;
        }

        private static bool IsAroundTheEdge(int row, int col, int height, int width)
        {
            return row == 0 || col == 0 || row == height - 1 || col == width - 1;
        }

        private static void MarkTreeAsVisible(int row, int col, Side side, Dictionary<(int, int), Side> visibleTrees)
        {
            var coordinates = (row, col);

            if (!visibleTrees.ContainsKey(coordinates))
            {
                visibleTrees[coordinates] = Side.NotVisible;
            }

            visibleTrees[coordinates] |= side;
        }

        private static void PrintVisibilityMap(string[] lines, Dictionary<(int, int), Side> visibleTrees)
        {
            var newLines = lines.Select(l => Enumerable.Repeat('.', l.Length).ToList())
                .ToArray();

            foreach (var key in visibleTrees.Keys)
            {
                var sides = visibleTrees[key];

                var letter = sides switch
                {
                    Side.Top => 'T',
                    Side.NotVisible => 'N',
                    Side.Left => 'L',
                    Side.Right => 'R',
                    Side.Bottom => 'B',
                    Side.Edge => 'E',
                    (Side.Left | Side.Right | Side.Top | Side.Bottom) => '1',
                    (Side.Left | Side.Top | Side.Bottom) => '2',
                    (Side.Left | Side.Right) => '3',
                    (Side.Right | Side.Top | Side.Bottom) => '4',
                    (Side.Top | Side.Bottom) => '5',
                    _ => '*'
                };

                newLines[key.Item1][key.Item2] = letter;
            }

            var buffer = new StringBuilder();
            foreach (var line in newLines)
            {
                buffer.AppendLine(string.Join("", line));
            }

            File.WriteAllText(@"..\..\..\visibility-map.txt", buffer.ToString());
        }

        private static void TraverseBottomToTop(string[] lines, Dictionary<(int, int), Side> visibleTrees, int totalCols, int totalRows)
        {
            Console.WriteLine($">> {nameof(TraverseTopToBottom)}");

            for (int col = 0; col < totalCols; col++)
            {
                var maxSize = 0;

                for (int row = totalRows - 1; row >= 0; row--)
                {
                    maxSize = CheckVisibility(Side.Bottom, row, col, totalCols, totalRows, lines, visibleTrees, maxSize);
                }
            }
        }

        private static void TraverseLeftToRight(string[] lines, Dictionary<(int, int), Side> visibleTrees, int totalCols, int totalRows)
        {
            Console.WriteLine($">> {nameof(TraverseLeftToRight)}");

            for (int row = 0; row < totalRows; row++)
            {
                var maxSize = 0;

                for (int col = 0; col < totalCols; col++)
                {
                    maxSize = CheckVisibility(Side.Left, row, col, totalCols, totalRows, lines, visibleTrees, maxSize);
                }
            }
        }

        private static void TraverseRightToLeft(string[] lines, Dictionary<(int, int), Side> visibleTrees, int totalCols, int totalRows)
        {
            Console.WriteLine($">> {nameof(TraverseRightToLeft)}");

            for (int row = 0; row < totalRows; row++)
            {
                var maxSize = 0;

                for (int col = totalCols - 1; col >= 0; col--)
                {
                    maxSize = CheckVisibility(Side.Right, row, col, totalCols, totalRows, lines, visibleTrees, maxSize);
                }
            }
        }

        private static void TraverseTopToBottom(string[] lines, Dictionary<(int, int), Side> visibleTrees, int totalCols, int totalRows)
        {
            Console.WriteLine($">> {nameof(TraverseTopToBottom)}");

            for (int col = 0; col < totalCols; col++)
            {
                var maxSize = 0;

                for (int row = 0; row < totalRows; row++)
                {
                    maxSize = CheckVisibility(Side.Top, row, col, totalCols, totalRows, lines, visibleTrees, maxSize);
                }
            }
        }
    }
}