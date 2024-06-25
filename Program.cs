public class Program
{
    public static void Main(string[] args)
    {
        Map map = new Map();
        map.DrawMap();

        Player player = new Player("P", new Point(1, 1));

        FishNumber fishNumber = new FishNumber();

        while (true)
        {
            Console.Clear();
            map.DrawMap();
            Console.SetCursorPosition(player.Position.X, player.Position.Y);
            Console.Write(player.Visual);

            Point nextPosition = player.GetNextPosition();

            if (map.IsWalkable(nextPosition))
            {
                player.MoveTo(nextPosition);
            }

            if (map.IsWater(player.Position))
            {
                fishNumber.CheckFishNumber();
            }
        }
    }
}

