namespace Puzzle07;

internal static class ShellCommandBuilder
{
    internal static ShellCommand Build(string command, string args)
    {
        var kind = Enum.Parse<ShellCommandKind>(command);

        return new ShellCommand(kind, args);
    }
}
