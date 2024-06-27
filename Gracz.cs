using System.Drawing;

public abstract class Character
{
    public string Visual { get; set; }
    public Point Position { get; set; }

    protected Character(string visual, Point startingPosition)
    {
        Visual = visual;
        Position = startingPosition;
    }

    public abstract Point GetNextPosition();
}

public class Player : Character
{
    private Dictionary<ConsoleKey, Point> directions = new()
    {
        { ConsoleKey.A, new Point(-1, 0) },
        { ConsoleKey.D, new Point(1, 0) },
        { ConsoleKey.W, new Point(0, -1) },
        { ConsoleKey.S, new Point(0, 1) },
    };
    public Inventory inventory = new();

    public Player(string visual, Point startingPosition) : base(visual, startingPosition)
    {
    }

    public override Point GetNextPosition()
    {
        Point nextPosition = Position;

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

    public void TakeFish(Fish fish)
    {
        inventory.AddFish(fish);
    }

    public void MoveTo(Point position)
    {
        Position = position;
    }
}
