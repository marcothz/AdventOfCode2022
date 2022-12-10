namespace Puzzle08;

[Flags]
internal enum Side
{
    NotVisible = 0,

    Left = 1,

    Right = 2,

    Top = 4,

    Bottom = 8,

    Edge = 16
}