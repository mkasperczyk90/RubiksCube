using RubiksCubeApp.Game.Display;

namespace RubiksCubeApp.Game;

internal class RubiksGame
{
    private readonly Dictionary<string, Action> _keyActionMap = new ();
    private const string QuitKey = "Q";
    public RubiksGame()
    {        
        RubiksCube = new RubiksCube();

        _keyActionMap.Add("F", () => RubiksCube.Rotate("F")); // TODO: Remove magic string - some kind of dictionary/enum
        _keyActionMap.Add("B", () => RubiksCube.Rotate("B"));
        _keyActionMap.Add("U", () => RubiksCube.Rotate("U"));
        _keyActionMap.Add("D", () => RubiksCube.Rotate("D"));
        _keyActionMap.Add("L", () => RubiksCube.Rotate("L"));
        _keyActionMap.Add("R", () => RubiksCube.Rotate("R"));
    }

    private RubiksCube RubiksCube { get; set; }

    public void Run(IDisplayGame displayGame)
    {
        RubiksCube.FillCube(3);
        RubiksCube.Display(displayGame);
        
        while (true)
        {
            var keyboardKey = Console.ReadKey();
            
            if (keyboardKey.Key.ToString() == QuitKey)
            {
                RubiksCube.Display(displayGame);
                Console.WriteLine("\n Thanks for playing! Press any key to exit.");
                return;
            }
            else
            {
                bool hasKey = _keyActionMap.TryGetValue(keyboardKey.Key.ToString(), out Action action); // maybe use Mediator 

                if (hasKey)
                {
                    action?.Invoke();
                }
                else
                {
                    Console.WriteLine("\n No such key.");
                }
            }

            RubiksCube.Display(displayGame);
        }
    }
}