using System.Drawing;

public class Program
{
    public static void Main(string[] args)
    {
        var npc = new NPC();
        Map map = new Map();
        map.Display(new Point(0, 0));

        Player player = new Player("P", new Point(4, 4));
        Console.SetCursorPosition(player.Position.X, player.Position.Y);
        FishNumber fishNumber = new FishNumber();
        Console.Write(player.Visual);
        while (true)
        { 
            Point nextPosition = player.GetNextPosition();
            if (nextPosition != player.Position)
            {
                if (map.IsPositionWalkable(nextPosition))
                {
                    if (map.IsTeleport(nextPosition))
                    {
                        nextPosition = map.GetTeleportDestination(nextPosition);
                    }
                    if (map.IsShop(nextPosition))
                    {
                        npc.BuildShop(player.inventory);
                    }
                    player.MoveTo(nextPosition);
                    Console.Clear();
                    map.Display(new Point(0, 0));
                    Console.SetCursorPosition(player.Position.X, player.Position.Y);
                    Console.Write(player.Visual);
                }
                if (map.IsWater(nextPosition))
                {
                    Console.Clear();
                    fishNumber.CheckFishNumber(player);
                    Console.Clear();
                    map.Display(new Point(0, 0));
                    Console.SetCursorPosition(player.Position.X, player.Position.Y);
                    Console.Write(player.Visual);
                }
            }
        }
    }
}

