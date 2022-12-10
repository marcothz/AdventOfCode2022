using System.Text.RegularExpressions;

namespace Puzzle07;

internal static class ShellOutputParser
{
    private const string ChangeDirectoryCommandPattern = @"\$ cd (.*)";
    private const string FileEntryPattern = @"(\d+) (.*)";
    private const string FolderEntryPattern = @"dir (.*)";
    private const string ListCommandPattern = @"\$ ls";

    internal static FileSystem Parse(string[] lines, FileSystem fileSystem)
    {
        var lineNum = 0;

        foreach (var line in lines)
        {
            lineNum++;

            if (!ParseChangeDirectoryCommand(line, fileSystem))
            {
                if (!ParseListCommand(line, fileSystem))
                {
                    if (!ParseFileEntry(line, fileSystem))
                    {
                        if (!ParseFolderEntry(line, fileSystem))
                        {
                            throw new Exception($"Could not parse line {lineNum} \"{line}\".");
                        }
                    }
                }
            }
        }

        return fileSystem;
    }

    private static bool ParseChangeDirectoryCommand(string line, FileSystem fileSystem)
    {
        var match = Regex.Match(line, ChangeDirectoryCommandPattern);

        if (!match.Success)
        {
            return false;
        }

        var folderName = match.Groups[1].Value;

        fileSystem.ChangeFolder(folderName);

        return true;
    }

    private static bool ParseFileEntry(string line, FileSystem fileSystem)
    {
        var match = Regex.Match(line, FileEntryPattern);

        if (!match.Success)
        {
            return false;
        }

        var size = int.Parse(match.Groups[1].Value);
        var name = match.Groups[2].Value;

        fileSystem.AddFile(name, size);

        return true;
    }

    private static bool ParseFolderEntry(string line, FileSystem fileSystem)
    {
        var match = Regex.Match(line, FolderEntryPattern);

        if (!match.Success)
        {
            return false;
        }

        var name = match.Groups[1].Value;

        fileSystem.AddFolder(name);

        return true;
    }

    private static bool ParseListCommand(string line, FileSystem fileSystem)
    {
        var match = Regex.Match(line, ListCommandPattern);

        if (!match.Success)
        {
            return false;
        }

        return true;
    }
}