using System.Drawing;

namespace Szluha;

internal class KeyboardInputComponent : IInputComponent
{    
    private Dictionary<ConsoleKey, Point> directions;

    public KeyboardInputComponent()
    {
        directions = new()
        {
            {ConsoleKey.A, new Point(-1, 0)},
            { ConsoleKey.D, new Point(1, 0) },
            {ConsoleKey.W, new Point(0, -1)},
            { ConsoleKey.S,  new Point(0, 1)},
        }; 
    }

    public Point GetDirection()
    {
        var nextPosition = new Point(0, 0);
        
        var pressedKey = Console.ReadKey(true);
        if (directions.ContainsKey(pressedKey.Key))
        {
            nextPosition.X = directions[pressedKey.Key].X;
            nextPosition.Y = directions[pressedKey.Key].Y;
        }

        return nextPosition;
    }
}