namespace RubiksCubeApp.Game;

public class Faces(CubeFace frontFace, CubeFace backFace, CubeFace leftFace, CubeFace rightFace, CubeFace upFace, CubeFace downFace)
{
    public CubeFace FrontFace { get; set; } = frontFace;
    public CubeFace BackFace { get; set; } = backFace;
    public CubeFace LeftFace { get; set; } = leftFace;
    public CubeFace RightFace { get; set; } = rightFace;
    public CubeFace UpFace { get; set; } = upFace;
    public CubeFace DownFace { get; set; } = downFace;
}