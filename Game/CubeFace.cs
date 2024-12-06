namespace RubiksCubeApp.Game;

public class CubeFace
{
    private readonly short _size;
    private readonly short _lastArrayPosition;
    public CubeFace(string name, ConsoleColor color, short size) // TODO: Use Color instead of ConsoleColor.Black
    {
        Name = name;
        _size = size;
        _lastArrayPosition = (short)(size - 1);
        Bricks = new ConsoleColor[size, size];
        
        for (var i = 0; i < Bricks.GetLength(0); i++) {
            for (var j = 0; j < Bricks.GetLength(1); j++) {
                Bricks[i,j] = color;
            }
        }
    } 
    
    public string Name { get; private set; }  
    public ConsoleColor[,] Bricks { get; private set; }
    
    private List<int> ArrayNumbers => Enumerable.Range(0, _size).ToList();
    
    public ConsoleColor[] GetRightColors() => ArrayNumbers.Select(number => Bricks[_lastArrayPosition, number]).ToArray();
    public ConsoleColor[] GetLeftColors() => ArrayNumbers.Select(number => Bricks[0, number]).ToArray();
    public ConsoleColor[] GetUpperColors() => ArrayNumbers.Select(number => Bricks[number, 0]).ToArray();
    public ConsoleColor[] GetBottomColors() => ArrayNumbers.Select(number => Bricks[number, _lastArrayPosition]).ToArray();

    public void SetLeftColors(ConsoleColor[] colors) => ArrayNumbers.ForEach(number => Bricks[0, number] = colors[number]);  
    public void SetUpperColors(ConsoleColor[] colors) => ArrayNumbers.ForEach(number =>  Bricks[_lastArrayPosition - number, 0] = colors[number]);  
    public void SetRightColors(ConsoleColor[] colors) => ArrayNumbers.ForEach(number => Bricks[_lastArrayPosition, number] = colors[number]);  
    public void SetBottomColors(ConsoleColor[] colors) => ArrayNumbers.ForEach(number => Bricks[_lastArrayPosition - number, _lastArrayPosition] = colors[number]);  
    
    public void RotateFaceClockwise()
    {
        if (_size == 3)
        {
            var tmp10 = Bricks[1, 0];
            Bricks[1, 0] = Bricks[0, 1];
            Bricks[0, 1] = Bricks[1, 2];
            Bricks[1, 2] = Bricks[2, 1];
            Bricks[2, 1] = tmp10;
            
            var tmp00 = Bricks[0, 0];
            Bricks[0, 0] = Bricks[0, 2];
            Bricks[0, 2] = Bricks[2, 2];
            Bricks[2, 2] = Bricks[2, 0];
            Bricks[2, 0] = tmp00;
        }
        else
        {
            throw new NotImplementedException();
        }
    }

}