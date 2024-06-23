internal class KeyboardInputComponent : IInputComponent


{    
    private Dictionary<ConsoleKey, Point> directions;

    public KeyboardInputComponent()
    {
        directions = new()
        {
            directions[ConsoleKey.A] = new Point(-1, 0),
            directions[ConsoleKey.D] = new Point(1, 0),
            directions[ConsoleKey.W] = new Point(0, -1),
            directions[ConsoleKey.S] = new Point(0, 1),
        }; //
    }

    public Point GetDirection()
    {
        Point nextPosition = new Point(0, 0);
        
        ConsoleKeyInfo pressedKey = Console.ReadKey(true);
        if (directions.ContainsKey(pressedKey.Key))
        {
            nextPosition.X = directions[pressedKey.Key].X;
            nextPosition.Y = directions[pressedKey.Key].Y;
        }

        return nextPosition;
    }
}
