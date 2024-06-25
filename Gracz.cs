using System;
using System.Collections.Generic;

public class Player : Character
{
    private Dictionary<ConsoleKey, Point> directions = new()
    {
        { ConsoleKey.A, new Point(-1, 0) },
        { ConsoleKey.D, new Point(1, 0) },
        { ConsoleKey.W, new Point(0, -1) },
        { ConsoleKey.S, new Point(0, 1) },
        { ConsoleKey.E, new Point(1, -1) }
    };

    public Player(string visual, Point startingPosition) : base(visual, startingPosition)
    {
    }

    public override Point GetNextPosition()
    {
        Point nextPosition = new Point(Position);

        if (Console.KeyAvailable)
        {
            ConsoleKeyInfo pressedKey = Console.ReadKey(true);
            if (directions.ContainsKey(pressedKey.Key))
            {
                nextPosition.X += directions[pressedKey.Key].X;
                nextPosition.Y += directions[pressedKey.Key].Y;
            }
        }

        return nextPosition;
    }
}
