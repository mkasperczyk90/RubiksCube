using RubiksCubeApp.Game.Constants;
using RubiksCubeApp.Game.Display;

namespace RubiksCubeApp.Game;

internal class RubiksGame
{
    private readonly Dictionary<string, Action> _keyActionMap = new();
    private readonly Dictionary<string, Action> _keyWithShiftActionMap = new();
    private readonly RubiksCube _rubiksCube;
    private IDisplayGame _displayGame;
    private bool _isRunning = true;

    public RubiksGame()
    {
        _rubiksCube = new RubiksCube();
        _displayGame = new ColoredConsole();
        
        _keyWithShiftActionMap.Add(CubeFaceType.Front.Label, () => _rubiksCube.RotateAntiClockwise(CubeFaceType.Front.Key));
        _keyWithShiftActionMap.Add(CubeFaceType.Back.Label, () => _rubiksCube.RotateAntiClockwise(CubeFaceType.Back.Key));
        _keyWithShiftActionMap.Add(CubeFaceType.Up.Label, () => _rubiksCube.RotateAntiClockwise(CubeFaceType.Up.Key));
        _keyWithShiftActionMap.Add(CubeFaceType.Down.Label, () => _rubiksCube.RotateAntiClockwise(CubeFaceType.Down.Key));
        _keyWithShiftActionMap.Add(CubeFaceType.Left.Label, () => _rubiksCube.RotateAntiClockwise(CubeFaceType.Left.Key));
        _keyWithShiftActionMap.Add(CubeFaceType.Right.Label, () => _rubiksCube.RotateAntiClockwise(CubeFaceType.Right.Key));

        _keyActionMap.Add(CubeFaceType.Front.Label, () => _rubiksCube.RotateClockwise(CubeFaceType.Front.Key));
        _keyActionMap.Add(CubeFaceType.Back.Label, () => _rubiksCube.RotateClockwise(CubeFaceType.Back.Key));
        _keyActionMap.Add(CubeFaceType.Up.Label, () => _rubiksCube.RotateClockwise(CubeFaceType.Up.Key));
        _keyActionMap.Add(CubeFaceType.Down.Label, () => _rubiksCube.RotateClockwise(CubeFaceType.Down.Key));
        _keyActionMap.Add(CubeFaceType.Left.Label, () => _rubiksCube.RotateClockwise(CubeFaceType.Left.Key));
        _keyActionMap.Add(CubeFaceType.Right.Label, () => _rubiksCube.RotateClockwise(CubeFaceType.Right.Key));
        _keyActionMap.Add(KeyboardKeys.Restart, () => _rubiksCube.Restart());
        _keyActionMap.Add(KeyboardKeys.Exit, () => _isRunning = false);
    }

    public void SetDisplay(IDisplayGame displayGame)
    {
        _displayGame = displayGame;
    }
    
    public void Run()
    {
        _rubiksCube.Restart();
        _rubiksCube.Display(_displayGame);

        while (_isRunning)
        {
            var keyboardKey = Console.ReadKey();
            var isShiftClicked = (keyboardKey.Modifiers & ConsoleModifiers.Shift) != 0;

            if (keyboardKey.Key.ToString() == KeyboardKeys.Exit)
            {
                _rubiksCube.Display(_displayGame);
                Console.WriteLine("\n Thanks for playing! Press any key to exit.");
                return;
            }

            var hasKey = isShiftClicked
                ? _keyWithShiftActionMap.TryGetValue(keyboardKey.Key.ToString(), out var action)
                : _keyActionMap.TryGetValue(keyboardKey.Key.ToString(), out action);

            if (hasKey)
                action?.Invoke();
            else
                Console.WriteLine("\n No such key.");

            _rubiksCube.Display(_displayGame);
        }
    }
}