namespace DotNetris;
[Flags]
public enum Inputs: byte
{
    None = 0,
    Up = 1,
    Down = 2,
    Left = 4,
    Right = 8,
    RotateLeft = 16,
    RotateRight = 32,
}