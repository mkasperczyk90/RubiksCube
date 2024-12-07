namespace RubiksCubeApp.Game.Constants;

public class CubeFaceType
{
    public static readonly CubeFaceType Up = new(KeyboardKeys.Up, ConsoleColor.White, 1, 2);
    public static readonly CubeFaceType Front = new(KeyboardKeys.Front, ConsoleColor.Green, 2, 2);
    public static readonly CubeFaceType Back = new(KeyboardKeys.Back, ConsoleColor.Blue, 2, 4);
    public static readonly CubeFaceType Left = new(KeyboardKeys.Left, ConsoleColor.Yellow, 2, 1);
    public static readonly CubeFaceType Right = new(KeyboardKeys.Right, ConsoleColor.Red, 2, 3);
    public static readonly CubeFaceType Down = new(KeyboardKeys.Down, ConsoleColor.Gray, 3, 2);

    private CubeFaceType(string label, ConsoleColor color, int row, int column)
    {
        Label = label;
        Color = color;
        Key = label;
        Row = row;
        Column = column;
    }

    public string Label { get; }
    public string Key { get; }
    public int Row { get; }
    public int Column { get; }
    public ConsoleColor Color { get; }
}