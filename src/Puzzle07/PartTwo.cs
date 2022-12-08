namespace Puzzle07
{
    internal static class PartTwo
    {
        internal static void Run(string[] lines)
        {
            var fileSystem = new FileSystem(70_000_000);

            ShellOutputParser.Parse(lines, fileSystem);

            fileSystem.ComputeSize();

            const int updateRequiredSpace = 30_000_000;

            var requiredFreeDiskSpace = Math.Max(updateRequiredSpace - fileSystem.AvailableDiskSpace, 0);

            Console.WriteLine($"UsedDiskSpace={fileSystem.UsedDiskSpace:N0}, AvailableDiskSpace={fileSystem.AvailableDiskSpace:N0}, RequiredFreeDiskSpace={requiredFreeDiskSpace:N0}");

            var folder = fileSystem.GetFoldersBySize(requiredFreeDiskSpace, null)
                .OrderBy(f => f.Size)
                .First();

            Console.WriteLine($"What is the total size of that directory? {folder.Size}");
        }
    }
}