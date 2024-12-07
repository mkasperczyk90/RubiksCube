namespace RubiksCubeApp.Game;

public class Faces(
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
}