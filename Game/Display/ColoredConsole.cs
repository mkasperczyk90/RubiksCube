using RubiksCubeApp.Game.Constants;

namespace RubiksCubeApp.Game.Display;

public class ColoredConsole : IDisplayGame
{
    private const int WidthDisplayCount = 4;
    private const int HeightDisplayCount = 3;
    private const string NewLine = "\n";
    private ConsoleColor DefaultBackgroundColor { get; } = ConsoleColor.Black;
    private char DefaultSquareCharacter { get; } = '0';

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
        Console.Write(NewLine);
        Console.Write(NewLine);

        var width = faces.BackFace.Bricks.GetLength(0);
        var height = faces.BackFace.Bricks.GetLength(1);

        var displayWidth = width * WidthDisplayCount;
        var displayHeight = height * HeightDisplayCount;

        for (var row = 0; row < displayHeight; row++)
        {
            for (var column = 0; column < displayWidth; column++)
            {
                var faceDimentions = new FaceDisplayDimensions(row, column, width, height);

                if (PrintFaceIfInPlace(faces.UpFace, CubeFaceType.Up.Row, CubeFaceType.Up.Column, faceDimentions))
                {
                }
                else if (PrintFaceIfInPlace(faces.LeftFace, CubeFaceType.Left.Row, CubeFaceType.Left.Column,
                             faceDimentions))
                {
                }
                else if (PrintFaceIfInPlace(faces.FrontFace, CubeFaceType.Front.Row, CubeFaceType.Front.Column,
                             faceDimentions))
                {
                }
                else if (PrintFaceIfInPlace(faces.RightFace, CubeFaceType.Right.Row, CubeFaceType.Right.Column,
                             faceDimentions))
                {
                }
                else if (PrintFaceIfInPlace(faces.BackFace, CubeFaceType.Back.Row, CubeFaceType.Back.Column,
                             faceDimentions))
                {
                }
                else if (PrintFaceIfInPlace(faces.DownFace, CubeFaceType.Down.Row, CubeFaceType.Down.Column,
                             faceDimentions))
                {
                }
                else
                {
                    Console.BackgroundColor = DefaultBackgroundColor;
                    Console.Write(DefaultSquareCharacter);
                }
            }

            Console.ResetColor();
            Console.Write(NewLine);
        }

        Console.ResetColor();
        Console.Write("Please enter key (Q - quit, X - restart or move clockwise using U, D, L, R, F, B. To move anti-clockwise click shift)");
    }

    private bool PrintFaceIfInPlace(CubeFace cubeFace, int row, int column, FaceDisplayDimensions faceDimensions)
    {
        if (IsInColumn(column, faceDimensions.Column, faceDimensions.Width) &&
            IsInRow(row, faceDimensions.Row, faceDimensions.Height))
        {
            PrintFace(faceDimensions.Column - (column - 1) * faceDimensions.Width,
                faceDimensions.Row - (row - 1) * faceDimensions.Height, cubeFace.Bricks, cubeFace.Name);
            return true;
        }

        return false;
    }

    private void PrintFace(int col, int row, ConsoleColor[,] colors, string name)
    {
        Console.BackgroundColor = colors[col, row];
        Console.Write(name);
    }

    private bool IsInColumn(int columnNumber, int column, int width)
    {
        var arrayColumnNumber = columnNumber - 1;
        var startColumnPosition = arrayColumnNumber * width - 1;
        var endColumnPosition = columnNumber * width;

        return column > startColumnPosition && column < endColumnPosition;
    }

    private bool IsInRow(int rowNumber, int row, int height)
    {
        var arrayRowNumber = rowNumber - 1;
        var startRowPosition = arrayRowNumber * height - 1;
        var endRowPosition = rowNumber * height;

        return row > startRowPosition && row < endRowPosition;
    }
}