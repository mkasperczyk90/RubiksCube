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

    private Faces Faces { get; set; }

    public void FillCube(short size)
    {
        Faces = new Faces(
            new CubeFace(CubeFaceType.Front.Label, CubeFaceType.Front.Color, size),
            new CubeFace(CubeFaceType.Back.Label, CubeFaceType.Back.Color, size),
            new CubeFace(CubeFaceType.Left.Label, CubeFaceType.Left.Color, size),
            new CubeFace(CubeFaceType.Right.Label, CubeFaceType.Right.Color, size),
            new CubeFace(CubeFaceType.Up.Label, CubeFaceType.Up.Color, size),
            new CubeFace(CubeFaceType.Down.Label, CubeFaceType.Down.Color, size));
    }

    public void RotateClockwise(string keyboardKey)
    {
        CubeMove move = new CubeMove();
        move.RotateClockwise(Faces, keyboardKey);
    }

    public void RotateAntiClockwise(string keyboardKey)
    {
        CubeMove move = new CubeMove();
        move.RotateAntiClockwise(Faces, keyboardKey);
    }

    public void Restart()
    {
        FillCube(CubeSize);
    }

    public void Display(IDisplayGame displayGame)
    {
        displayGame.ShowCube(Faces);
    }
}