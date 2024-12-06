namespace RubiksCubeApp.Game.Display;

public record Square
{
    public ConsoleColor Color { get; init; }
    public char Character { get; init; }
}
public class ColoredConsole: IDisplayGame
{
    private const int WidthDisplayCount = 4;
    private const int HeightDisplayCount = 3;
    private ConsoleColor DefaultBackgroundColor { get; init; } = ConsoleColor.Black;
    private char DefaultSquareCharacter { get; init; } = '0';
    
    /*
     * Display Cube as a matrix in console. For 3x3 cube
     *
     * [000UUU000000]
     * [000UUU000000]
     * [000UUU000000]
     * [RRRFFFLLLBBB]
     * [RRRFFFLLLBBB]
     * [RRRFFFLLLBBB]
     * [000DDD000000]
     * [000DDD000000]
     * [000DDD000000]
     */
    public void ShowCube(Faces faces)
    {
        Console.Write("\n");
        Console.Write("\n");
        
        var width = faces.BackFace.Bricks.GetLength(0);
        var height = faces.BackFace.Bricks.GetLength(1);

        var displayWidth = width * WidthDisplayCount; 
        var displayHeight = height * HeightDisplayCount;
        
        for (var row = 0; row < displayHeight ; row++) 
        {
            for (var column = 0; column < displayWidth; column++)
            {
                if (IsInColumn(2, column, width) && IsInRow(1, row, height))
                {
                    PrintFace(column - width, row, faces.UpFace.Bricks, faces.UpFace.Name);
                }
                else if (IsInColumn(1, column, width) && IsInRow(2, row, height))
                {
                    PrintFace(column, row - height, faces.LeftFace.Bricks, faces.LeftFace.Name);
                }
                else if (IsInColumn(2, column, width) && IsInRow(2, row, height))
                {
                    PrintFace(column - width, row - height, faces.FrontFace.Bricks, faces.FrontFace.Name);
                }
                else if (IsInColumn(3, column, width) && IsInRow(2, row, height))
                {
                    PrintFace(column - (2*width), row - height, faces.RightFace.Bricks, faces.RightFace.Name);
                }
                else if (IsInColumn(4, column, width) && IsInRow(2, row, height))
                {
                    PrintFace(column - (3*width), row - height, faces.BackFace.Bricks, faces.BackFace.Name);
                }
                else if (IsInColumn(2, column, width) && IsInRow(3, row, height))
                {
                    PrintFace(column - width, row - (2*height), faces.DownFace.Bricks, faces.DownFace.Name);
                }
                else
                {
                    Console.BackgroundColor = DefaultBackgroundColor;
                    Console.Write(DefaultSquareCharacter);
                }
            }
            Console.ResetColor();
            Console.Write("\n");
        }
        
        Console.ResetColor();
        Console.Write("Please enter key (Q - quit, X - restart, U, D, L, R, F, B)");
    }

    private void PrintFace(int col, int row, ConsoleColor[,] colors, string name)
    {
        Console.BackgroundColor = colors[col, row];
        Console.Write(name);
    }

    private bool IsInColumn(int columnNumber, int column, int width)
    {
        var arrayColumnNumber = columnNumber - 1;
        var startColumnPosition = (arrayColumnNumber * width) - 1;
        var endColumnPosition = columnNumber * width;
        
        return column > startColumnPosition && column < endColumnPosition;
    }

    private bool IsInRow(int rowNumber, int row, int height)
    {
        var arrayRowNumber = rowNumber - 1;
        var startRowPosition = (arrayRowNumber * height) - 1;
        var endRowPosition = rowNumber * height;
        
        return row > startRowPosition && row < endRowPosition;
    }
}