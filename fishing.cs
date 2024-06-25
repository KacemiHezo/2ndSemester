public class FishNumber
{
    public void CheckFishNumber()
    {
        string[] getfishtxt = { "reel" };
        Inventory inventory = new Inventory();

        Random rand = new Random();
        int numberwater = rand.Next(1, 100);
        int fishnumber = rand.Next(1, 7);
        string notreel = string.Empty;

        while (numberwater >= 1 && numberwater <= 70)
        {
            Random r = new Random();
            string[] nofishtxt = { "nothing yet", "sinkin the hopes and dreams", "no food for you I guess" };
            Console.WriteLine(nofishtxt[r.Next(0, nofishtxt.Length)]);
        }

        if (numberwater >= 70 && numberwater <= 100)
        {
            Console.WriteLine("oh shit a fish! type REEL!!");
            while (!getfishtxt.Contains(notreel))
            {
                Console.WriteLine("not that!!");
                notreel = Console.ReadLine()?.ToLower().Trim() ?? string.Empty;
            }

            FishData fishData = new FishData();
            Fish caughtFish = fishData.GetFishInfo(fishnumber);

            Console.WriteLine("you got a fish!");
            Console.WriteLine($"you got a {caughtFish.Name}");
            Console.WriteLine(caughtFish.Description);

            inventory.AddFish(caughtFish);
            inventory.DisplayInventory();
        }
    }
}
