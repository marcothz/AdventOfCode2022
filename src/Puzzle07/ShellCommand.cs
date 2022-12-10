namespace Puzzle07;

internal class ShellCommand
{
    public ShellCommand(ShellCommandKind kind, string args)
    {
        Kind = kind;
        Args = args;
    }

    public ShellCommandKind Kind { get; }

    public string Args { get; }
}
