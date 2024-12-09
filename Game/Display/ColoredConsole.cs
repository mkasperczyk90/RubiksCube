using RubiksCubeApp.Game.Constants;

namespace RubiksCubeApp.Game.Display;

public class ColoredConsole : IDisplayGame
{
    private const int WidthDisplayCount = 4;
    private const int HeightDisplayCount = 3;
    private const string NewLine = "\n";
    private const char DefaultSquareCharacter = '0';
    private const ConsoleColor DefaultBackgroundColor = ConsoleColor.Black;
    
    private IList<Func<FaceDisplayDimensions, bool>> GetAllPrintActions(CubeFaces cubeFaces)
    {
        IList<Func<FaceDisplayDimensions, bool>> printActions = new List<Func<FaceDisplayDimensions, bool>>();
        printActions.Add((faceDimension) => PrintSquareIfInPlace(cubeFaces.UpFace, CubeFaceType.Up.Row, CubeFaceType.Up.Column, faceDimension));
        printActions.Add((faceDimension) => PrintSquareIfInPlace(cubeFaces.LeftFace, CubeFaceType.Left.Row, CubeFaceType.Left.Column, faceDimension));
        printActions.Add((faceDimension) => PrintSquareIfInPlace(cubeFaces.FrontFace, CubeFaceType.Front.Row, CubeFaceType.Front.Column, faceDimension));
        printActions.Add((faceDimension) => PrintSquareIfInPlace(cubeFaces.RightFace, CubeFaceType.Right.Row, CubeFaceType.Right.Column, faceDimension));
        printActions.Add((faceDimension) => PrintSquareIfInPlace(cubeFaces.BackFace, CubeFaceType.Back.Row, CubeFaceType.Back.Column, faceDimension));
        printActions.Add((faceDimension) => PrintSquareIfInPlace(cubeFaces.DownFace, CubeFaceType.Down.Row, CubeFaceType.Down.Column, faceDimension));
        printActions.Add((faceDimension) =>
        {
            PrintNoSquere(); 
            return true;
        });
        return printActions;
    }
    
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
    public void ShowCube(CubeFaces cubeFaces)
    {
        Console.Write(NewLine);
        Console.Write(NewLine);

        var width = cubeFaces.BackFace.Bricks.GetLength(0);
        var height = cubeFaces.BackFace.Bricks.GetLength(1);

        var displayWidth = width * WidthDisplayCount;
        var displayHeight = height * HeightDisplayCount;

        var printActions = GetAllPrintActions(cubeFaces);

        for (var row = 0; row < displayHeight; row++)
        {
            for (var column = 0; column < displayWidth; column++)
            {
                var faceDimension = new FaceDisplayDimensions(row, column, width, height);

                foreach (var printAction in printActions)
                {
                    var result = printAction(faceDimension);
                    if (result) break; 
                }
            }

            Console.ResetColor();
            Console.Write(NewLine);
        }

        Console.ResetColor();
        Console.WriteLine("Please enter key (Q - quit, X - restart or move clockwise using keys U, D, L, R, F, B. To move anti-clockwise press shift SHIFT and key)");
    }

    private bool IfInPlace(int row, int column, FaceDisplayDimensions faceDimensions)
    {
        return IsInColumn(column, faceDimensions.Column, faceDimensions.Width) &&
               IsInRow(row, faceDimensions.Row, faceDimensions.Height);
    }

    
    private void PrintSquare(CubeFace cubeFace, int row, int column, FaceDisplayDimensions faceDimensions)
    {
        PrintFace(faceDimensions.Column - (column - 1) * faceDimensions.Width,
            faceDimensions.Row - (row - 1) * faceDimensions.Height, cubeFace.Bricks, cubeFace.Name);
    }
    
    private bool PrintSquareIfInPlace(CubeFace cubeFace, int row, int column, FaceDisplayDimensions faceDimensions)
    {
        if (!IfInPlace(row, column, faceDimensions)) return false;
        PrintSquare(cubeFace, row, column, faceDimensions);
        return true;

    }

    private static void PrintNoSquere()
    {
        Console.BackgroundColor = DefaultBackgroundColor;
        Console.Write(DefaultSquareCharacter);
    }

    private static void PrintFace(int col, int row, ConsoleColor[,] colors, string name)
    {
        Console.BackgroundColor = colors[col, row];
        Console.Write(name);
    }

    private static bool IsInColumn(int columnNumber, int column, int width)
    {
        var arrayColumnNumber = columnNumber - 1;
        var startColumnPosition = arrayColumnNumber * width - 1;
        var endColumnPosition = columnNumber * width;

        return column > startColumnPosition && column < endColumnPosition;
    }

    private static bool IsInRow(int rowNumber, int row, int height)
    {
        var arrayRowNumber = rowNumber - 1;
        var startRowPosition = arrayRowNumber * height - 1;
        var endRowPosition = rowNumber * height;

        return row > startRowPosition && row < endRowPosition;
    }
}