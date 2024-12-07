using RubiksCubeApp.Game.Constants;

namespace RubiksCubeApp.Game;

public class CubeMove
{
    public void RotateClockwise(Faces faces, string keyboardKey)
    {
        var key = keyboardKey.ToUpper();

        switch (key)
        {
            case KeyboardKeys.Up:
            {
                faces.UpFace.RotateFaceClockwise();

                var tmp = faces.LeftFace.GetUpperColors();
                faces.LeftFace.SetUpperColors(faces.FrontFace.GetUpperColors());
                faces.FrontFace.SetUpperColors(faces.RightFace.GetUpperColors());
                faces.RightFace.SetUpperColors(faces.BackFace.GetUpperColors());
                faces.BackFace.SetUpperColors(tmp);
                break;
            }
            case KeyboardKeys.Front:
            {
                faces.FrontFace.RotateFaceClockwise();

                var tmp = faces.LeftFace.GetRightColors();
                faces.LeftFace.SetRightColors(faces.DownFace.GetUpperColors());
                faces.DownFace.SetUpperColors(faces.RightFace.GetLeftColors());
                faces.RightFace.SetLeftColors(faces.UpFace.GetBottomColors());
                faces.UpFace.SetBottomColors(tmp);
                break;
            }
            case KeyboardKeys.Down:
            {
                faces.DownFace.RotateFaceClockwise();

                var tmp = faces.LeftFace.GetBottomColors();
                faces.LeftFace.SetBottomColors(faces.BackFace.GetBottomColors());
                faces.BackFace.SetBottomColors(faces.RightFace.GetBottomColors());
                faces.RightFace.SetBottomColors(faces.FrontFace.GetBottomColors());
                faces.FrontFace.SetBottomColors(tmp);
                break;
            }
            case KeyboardKeys.Left:
            {
                faces.LeftFace.RotateFaceClockwise();

                var tmp = faces.FrontFace.GetLeftColors();
                faces.FrontFace.SetLeftColors(faces.UpFace.GetLeftColors());
                faces.UpFace.SetLeftColors(faces.BackFace.GetRightColors());
                faces.BackFace.SetRightColors(faces.DownFace.GetLeftColors());
                faces.DownFace.SetLeftColors(tmp);
                break;
            }
            case KeyboardKeys.Right:
            {
                faces.RightFace.RotateFaceClockwise();

                var tmp = faces.FrontFace.GetRightColors();
                faces.FrontFace.SetRightColors(faces.DownFace.GetRightColors());
                faces.DownFace.SetRightColors(faces.BackFace.GetLeftColors());
                faces.BackFace.SetLeftColors(faces.UpFace.GetRightColors());
                faces.UpFace.SetRightColors(tmp);
                break;
            }
            case KeyboardKeys.Back:
            {
                faces.BackFace.RotateFaceClockwise();

                var tmp = faces.RightFace.GetRightColors();
                faces.RightFace.SetRightColors(faces.DownFace.GetBottomColors());
                faces.DownFace.SetBottomColors(faces.LeftFace.GetLeftColors());
                faces.LeftFace.SetLeftColors(faces.UpFace.GetUpperColors());
                faces.UpFace.SetUpperColors(tmp);
                break;
            }
        }
    }

    public void RotateAntiClockwise(Faces faces, string keyboardKey)
    {
        var key = keyboardKey.ToUpper();
        switch (key)
        {
            case KeyboardKeys.Up:
            {
                faces.UpFace.RotateFaceAntiClockwise();
                ;

                var tmp = faces.LeftFace.GetUpperColors();
                faces.LeftFace.SetUpperColors(faces.BackFace.GetUpperColors());
                faces.BackFace.SetUpperColors(faces.RightFace.GetUpperColors());
                faces.RightFace.SetUpperColors(faces.FrontFace.GetUpperColors());
                faces.FrontFace.SetUpperColors(tmp);
                break;
            }
            case KeyboardKeys.Front:
            {
                faces.FrontFace.RotateFaceAntiClockwise();

                var tmp = faces.LeftFace.GetRightColors();
                faces.LeftFace.SetRightColors(faces.UpFace.GetBottomColors());
                faces.UpFace.SetBottomColors(faces.RightFace.GetLeftColors());
                faces.RightFace.SetLeftColors(faces.DownFace.GetUpperColors());
                faces.DownFace.SetUpperColors(tmp);
                break;
            }
            case KeyboardKeys.Down:
            {
                faces.DownFace.RotateFaceAntiClockwise();

                var tmp = faces.LeftFace.GetBottomColors();
                faces.LeftFace.SetBottomColors(faces.FrontFace.GetBottomColors());
                faces.FrontFace.SetBottomColors(faces.RightFace.GetBottomColors());
                faces.RightFace.SetBottomColors(faces.BackFace.GetBottomColors());
                faces.BackFace.SetBottomColors(tmp);
                break;
            }
            case KeyboardKeys.Left:
            {
                faces.LeftFace.RotateFaceAntiClockwise();

                var tmp = faces.FrontFace.GetLeftColors();
                faces.FrontFace.SetLeftColors(faces.DownFace.GetLeftColors());
                faces.DownFace.SetLeftColors(faces.BackFace.GetRightColors());
                faces.BackFace.SetRightColors(faces.UpFace.GetLeftColors());
                faces.UpFace.SetLeftColors(tmp);
                break;
            }
            case KeyboardKeys.Right:
            {
                faces.RightFace.RotateFaceAntiClockwise();

                var tmp = faces.FrontFace.GetRightColors();
                faces.FrontFace.SetRightColors(faces.UpFace.GetRightColors());
                faces.UpFace.SetRightColors(faces.BackFace.GetLeftColors());
                faces.BackFace.SetLeftColors(faces.DownFace.GetRightColors());
                faces.DownFace.SetRightColors(tmp);
                break;
            }
            case KeyboardKeys.Back:
            {
                faces.BackFace.RotateFaceAntiClockwise();

                var tmp = faces.RightFace.GetRightColors();
                faces.RightFace.SetRightColors(faces.UpFace.GetUpperColors());
                faces.UpFace.SetUpperColors(faces.LeftFace.GetLeftColors());
                faces.LeftFace.SetLeftColors(faces.DownFace.GetBottomColors());
                faces.DownFace.SetBottomColors(tmp);
                break;
            }
        }
    }
}