namespace Puzzle08
{
    internal class PartTwo
    {
        internal static void Run(string[] lines)
        {
            var totalRows = lines.Length;
            var totalCols = lines[0].Length;
            var maxScenicScore = 0;

            for (int row = 0; row < totalRows; row++)
            {
                for (int col = 0; col < totalCols; col++)
                {
                    var scenicScore = CalculateScenicScore(row, col, totalRows, totalCols, lines);

                    maxScenicScore = Math.Max(maxScenicScore, scenicScore);
                }
            }

            Console.WriteLine($"What is the highest scenic score possible for any tree? {maxScenicScore}");
        }

        private static int CalculateScenicScore(int row, int col, int totalRows, int totalCols, string[] lines)
        {
            return TreesLookingLeft(row, col, totalRows, totalCols, lines)
                * TreesLookingRight(row, col, totalRows, totalCols, lines)
                * TreesLookingTop(row, col, totalRows, totalCols, lines)
                * TreesLookingBottom(row, col, totalRows, totalCols, lines);
        }

        private static int TreesLookingBottom(int row, int col, int totalRows, int totalCols, string[] lines)
        {
            var currentSize = lines[row][col] - '0';
            var score = 0;

            row++;

            while (row < totalRows)
            {
                score++;

                var size = lines[row][col] - '0';

                if (size >= currentSize)
                {
                    break;
                }

                row++;
            }

            return score;
        }

        private static int TreesLookingLeft(int row, int col, int totalRows, int totalCols, string[] lines)
        {
            var currentSize = lines[row][col] - '0';
            var score = 0;

            col--;

            while (col >= 0)
            {
                score++;

                var size = lines[row][col] - '0';

                if (size >= currentSize)
                {
                    break;
                }

                col--;
            }

            return score;
        }

        private static int TreesLookingRight(int row, int col, int totalRows, int totalCols, string[] lines)
        {
            var currentSize = lines[row][col] - '0';
            var score = 0;

            col++;

            while (col < totalCols)
            {
                score++;

                var size = lines[row][col] - '0';

                if (size >= currentSize)
                {
                    break;
                }

                col++;
            }

            return score;
        }

        private static int TreesLookingTop(int row, int col, int totalRows, int totalCols, string[] lines)
        {
            var currentSize = lines[row][col] - '0';
            var score = 0;

            row--;

            while (row >= 0)
            {
                score++;

                var size = lines[row][col] - '0';

                if (size >= currentSize)
                {
                    break;
                }

                row--;
            }

            return score;
        }
    }
}