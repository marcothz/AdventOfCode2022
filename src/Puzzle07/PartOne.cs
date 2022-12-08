namespace Puzzle07
{
    internal static class PartOne
    {
        internal static void Run(string[] lines)
        {
            var fileSystem = new FileSystem(0);

            ShellOutputParser.Parse(lines, fileSystem);

            fileSystem.ComputeSize();

            var x = fileSystem.GetFoldersBySize(null, 100_000).ToArray();
            var result = fileSystem.GetFoldersBySize(null, 100_000)
                .Sum(f => f.Size);

            Console.WriteLine($"What is the sum of the total sizes of those directories? {result}");
        }
    }
}