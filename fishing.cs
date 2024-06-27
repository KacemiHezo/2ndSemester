public class FishNumber
{
    public void CheckFishNumber(Player player)
    {
        string[] getfishtxt = { "reel" };

        Random rand = new Random();
        Random r = new Random();
        
        
        int numberwater = rand.Next(1, 100);
        int fishnumber = rand.Next(1, 7);
        string notreel = string.Empty;

        while (numberwater >= 1 && numberwater <= 90)
        {
            numberwater = rand.Next(1, 100);
            string[] nofishtxt = { "nothing yet...", "sinkin the hopes and dreams...", "no food for you I guess..." };
            Console.WriteLine(nofishtxt[r.Next(0, nofishtxt.Length)]);
            Thread.Sleep(2000);
        }

        if (numberwater >= 90 && numberwater <= 100)
        {
            Console.WriteLine("oh shit a fish! type REEL!!");
            notreel = Console.ReadLine()?.ToLower().Trim() ?? string.Empty;
            while (!getfishtxt.Contains(notreel))
            {
                Console.WriteLine("not that!!");
                notreel = Console.ReadLine()?.ToLower().Trim() ?? string.Empty;
            }

            FishDatabase fishData = new FishDatabase();
            Fish? caughtFish = fishData.GetFishByNumber(fishnumber);

            Console.WriteLine("you got a fish!");
            Console.WriteLine($"you got a {caughtFish.Name}");
            Console.WriteLine(caughtFish.Description);

            player.inventory.AddFish(caughtFish);
            Console.WriteLine(caughtFish);
            Console.ReadKey();
        }
    }
}
