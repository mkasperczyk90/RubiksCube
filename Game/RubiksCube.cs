using RubiksCubeApp.Game.Constants;
using RubiksCubeApp.Game.Display;

namespace RubiksCubeApp.Game;

internal sealed class RubiksCube
{
    private const short CubeSize = 3;

    public RubiksCube()
    {
        FillCube(CubeSize);
    }

    private CubeFaces CubeFaces { get; set; }

    private void FillCube(short size)
    {
        CubeFaces = new CubeFaces(
            new CubeFace(CubeFaceType.Front.Label, CubeFaceType.Front.Color, size),
            new CubeFace(CubeFaceType.Back.Label, CubeFaceType.Back.Color, size),
            new CubeFace(CubeFaceType.Left.Label, CubeFaceType.Left.Color, size),
            new CubeFace(CubeFaceType.Right.Label, CubeFaceType.Right.Color, size),
            new CubeFace(CubeFaceType.Up.Label, CubeFaceType.Up.Color, size),
            new CubeFace(CubeFaceType.Down.Label, CubeFaceType.Down.Color, size));
    }

    public void RotateClockwise(string keyboardKey)
    {
        CubeFaces.RotateClockwise(keyboardKey);
    }

    public void RotateAntiClockwise(string keyboardKey)
    {
        CubeFaces.RotateAntiClockwise(keyboardKey);
    }

    public void Restart()
    {
        FillCube(CubeSize);
    }

    public void Display(IDisplayGame displayGame)
    {
        displayGame.ShowCube(CubeFaces);
    }
}