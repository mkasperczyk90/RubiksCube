using System.Drawing;
using RubiksCubeApp.Game.Display;

namespace RubiksCubeApp.Game;

internal sealed class RubiksCube
{
    private const short _cubeSize = 3;
    private Faces Faces { get; set; }
    
    public RubiksCube()
    {
        FillCube(_cubeSize);
    }

    public void FillCube(short size)
    {
        Faces = new Faces(
            new CubeFace("F", ConsoleColor.Green, size), // TODO: Use map/enum instead of magic string
            new CubeFace("B", ConsoleColor.Blue, size),
            new CubeFace("L", ConsoleColor.Yellow, size),
            new CubeFace("R", ConsoleColor.Red, size),
            new CubeFace("U", ConsoleColor.White, size),
            new CubeFace("D", ConsoleColor.Gray, size));
    } 
    
    public void Rotate(string key) // TODO: Use Enum 
    {
        if (key == "U") // TODO: Create enum + map and use like Keys.Up
        {
            Faces.UpFace.RotateFaceClockwise(); 
            
            // TODO: Many Duplications - move to method move(main, [up, right, down, left]) where up -> right -> down -> left ?? TO BE SURE??
            var tmp= Faces.LeftFace.GetUpperColors();
            Faces.LeftFace.SetUpperColors(Faces.FrontFace.GetUpperColors());
            Faces.FrontFace.SetUpperColors(Faces.RightFace.GetUpperColors());
            Faces.RightFace.SetUpperColors(Faces.BackFace.GetUpperColors());
            Faces.BackFace.SetUpperColors(tmp);
        }
        else if (key == "F")
        {
            Faces.FrontFace.RotateFaceClockwise(); 
            
            var tmp= Faces.LeftFace.GetRightColors();
            Faces.LeftFace.SetRightColors(Faces.DownFace.GetUpperColors());
            Faces.DownFace.SetUpperColors(Faces.RightFace.GetLeftColors());
            Faces.RightFace.SetLeftColors(Faces.UpFace.GetBottomColors());
            Faces.UpFace.SetBottomColors(tmp);
        }
        else if (key == "D")
        {
            Faces.DownFace.RotateFaceClockwise(); 
            
            var tmp= Faces.LeftFace.GetBottomColors();
            Faces.LeftFace.SetBottomColors(Faces.BackFace.GetBottomColors());
            Faces.BackFace.SetBottomColors(Faces.RightFace.GetBottomColors());
            Faces.RightFace.SetBottomColors(Faces.FrontFace.GetBottomColors());
            Faces.FrontFace.SetBottomColors(tmp);
        }
        else if (key == "L")
        {
            Faces.LeftFace.RotateFaceClockwise();
            
            var tmp= Faces.FrontFace.GetLeftColors();
            Faces.FrontFace.SetLeftColors(Faces.UpFace.GetLeftColors());
            Faces.UpFace.SetLeftColors(Faces.BackFace.GetRightColors());
            Faces.BackFace.SetRightColors(Faces.DownFace.GetLeftColors());
            Faces.DownFace.SetLeftColors(tmp);
        }
        else if (key == "R")
        {
            Faces.RightFace.RotateFaceClockwise();
            
            var tmp= Faces.FrontFace.GetRightColors();
            Faces.FrontFace.SetRightColors(Faces.DownFace.GetRightColors());
            Faces.DownFace.SetRightColors(Faces.BackFace.GetLeftColors());
            Faces.BackFace.SetLeftColors(Faces.UpFace.GetRightColors());
            Faces.UpFace.SetRightColors(tmp);
        }
        else if (key == "B")
        {
            Faces.BackFace.RotateFaceClockwise();
            
            var tmp= Faces.RightFace.GetRightColors();
            Faces.RightFace.SetRightColors(Faces.DownFace.GetBottomColors());
            Faces.DownFace.SetBottomColors(Faces.LeftFace.GetLeftColors());
            Faces.LeftFace.SetLeftColors(Faces.UpFace.GetUpperColors());
            Faces.UpFace.SetUpperColors(tmp);
        } else if (key == "R")
        {
            FillCube(_cubeSize); 
        }
    }
    
    public void Restart() => FillCube(_cubeSize);

    public void Display(IDisplayGame displayGame)
    {
        displayGame.ShowCube(Faces);
    }
}