using RubiksCubeApp.Game.Constants;

namespace RubiksCubeApp.Game;

public class CubeFaces(
    CubeFace frontFace,
    CubeFace backFace,
    CubeFace leftFace,
    CubeFace rightFace,
    CubeFace upFace,
    CubeFace downFace)
{
    public CubeFace FrontFace { get; } = frontFace;
    public CubeFace BackFace { get; } = backFace;
    public CubeFace LeftFace { get; } = leftFace;
    public CubeFace RightFace { get; } = rightFace;
    public CubeFace UpFace { get; } = upFace;
    public CubeFace DownFace { get; } = downFace;
    
    public void RotateClockwise(string keyboardKey)
    {
        var key = keyboardKey.ToUpper();

        switch (key)
        {
            case KeyboardKeys.Up:
            {
                UpFace.RotateFaceClockwise();

                var tmp = LeftFace.GetUpperColors();
                LeftFace.SetUpperColors(FrontFace.GetUpperColors());
                FrontFace.SetUpperColors(RightFace.GetUpperColors());
                RightFace.SetUpperColors(BackFace.GetUpperColors());
                BackFace.SetUpperColors(tmp);
                break;
            }
            case KeyboardKeys.Front:
            {
                FrontFace.RotateFaceClockwise();

                var tmp = LeftFace.GetRightColors();
                LeftFace.SetRightColors(DownFace.GetUpperColors());
                DownFace.SetUpperColors(RightFace.GetLeftColors());
                RightFace.SetLeftColors(UpFace.GetBottomColors());
                UpFace.SetBottomColors(tmp);
                break;
            }
            case KeyboardKeys.Down:
            {
                DownFace.RotateFaceClockwise();

                var tmp = LeftFace.GetBottomColors();
                LeftFace.SetBottomColors(BackFace.GetBottomColors());
                BackFace.SetBottomColors(RightFace.GetBottomColors());
                RightFace.SetBottomColors(FrontFace.GetBottomColors());
                FrontFace.SetBottomColors(tmp);
                break;
            }
            case KeyboardKeys.Left:
            {
                LeftFace.RotateFaceClockwise();

                var tmp = FrontFace.GetLeftColors();
                FrontFace.SetLeftColors(UpFace.GetLeftColors());
                UpFace.SetLeftColors(BackFace.GetRightColors());
                BackFace.SetRightColors(DownFace.GetLeftColors());
                DownFace.SetLeftColors(tmp);
                break;
            }
            case KeyboardKeys.Right:
            {
                RightFace.RotateFaceClockwise();

                var tmp = FrontFace.GetRightColors();
                FrontFace.SetRightColors(DownFace.GetRightColors());
                DownFace.SetRightColors(BackFace.GetLeftColors());
                BackFace.SetLeftColors(UpFace.GetRightColors());
                UpFace.SetRightColors(tmp);
                break;
            }
            case KeyboardKeys.Back:
            {
                BackFace.RotateFaceClockwise();

                var tmp = RightFace.GetRightColors();
                RightFace.SetRightColors(DownFace.GetBottomColors());
                DownFace.SetBottomColors(LeftFace.GetLeftColors());
                LeftFace.SetLeftColors(UpFace.GetUpperColors());
                UpFace.SetUpperColors(tmp);
                break;
            }
        }
    }

    public void RotateAntiClockwise(string keyboardKey)
    {
        var key = keyboardKey.ToUpper();
        switch (key)
        {
            case KeyboardKeys.Up:
            {
                UpFace.RotateFaceAntiClockwise();
                ;

                var tmp = LeftFace.GetUpperColors();
                LeftFace.SetUpperColors(BackFace.GetUpperColors());
                BackFace.SetUpperColors(RightFace.GetUpperColors());
                RightFace.SetUpperColors(FrontFace.GetUpperColors());
                FrontFace.SetUpperColors(tmp);
                break;
            }
            case KeyboardKeys.Front:
            {
                FrontFace.RotateFaceAntiClockwise();

                var tmp = LeftFace.GetRightColors();
                LeftFace.SetRightColors(UpFace.GetBottomColors());
                UpFace.SetBottomColors(RightFace.GetLeftColors());
                RightFace.SetLeftColors(DownFace.GetUpperColors());
                DownFace.SetUpperColors(tmp);
                break;
            }
            case KeyboardKeys.Down:
            {
                DownFace.RotateFaceAntiClockwise();

                var tmp = LeftFace.GetBottomColors();
                LeftFace.SetBottomColors(FrontFace.GetBottomColors());
                FrontFace.SetBottomColors(RightFace.GetBottomColors());
                RightFace.SetBottomColors(BackFace.GetBottomColors());
                BackFace.SetBottomColors(tmp);
                break;
            }
            case KeyboardKeys.Left:
            {
                LeftFace.RotateFaceAntiClockwise();

                var tmp = FrontFace.GetLeftColors();
                FrontFace.SetLeftColors(DownFace.GetLeftColors());
                DownFace.SetLeftColors(BackFace.GetRightColors());
                BackFace.SetRightColors(UpFace.GetLeftColors());
                UpFace.SetLeftColors(tmp);
                break;
            }
            case KeyboardKeys.Right:
            {
                RightFace.RotateFaceAntiClockwise();

                var tmp = FrontFace.GetRightColors();
                FrontFace.SetRightColors(UpFace.GetRightColors());
                UpFace.SetRightColors(BackFace.GetLeftColors());
                BackFace.SetLeftColors(DownFace.GetRightColors());
                DownFace.SetRightColors(tmp);
                break;
            }
            case KeyboardKeys.Back:
            {
                BackFace.RotateFaceAntiClockwise();

                var tmp = RightFace.GetRightColors();
                RightFace.SetRightColors(UpFace.GetUpperColors());
                UpFace.SetUpperColors(LeftFace.GetLeftColors());
                LeftFace.SetLeftColors(DownFace.GetBottomColors());
                DownFace.SetBottomColors(tmp);
                break;
            }
        }
    }
}