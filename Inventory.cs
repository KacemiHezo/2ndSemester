public class Inventory
{
    private List<Fish> fishList = new List<Fish>();

    public void AddFish(Fish fish)
    {
        fishList.Add(fish);
    }

    public void DisplayInventory()
    {
        if (fishList.Count == 0)
        {
            Console.WriteLine("Your inventory is empty.");
        }
        else
        {
            foreach (var fish in fishList)
            {
                Console.WriteLine($"{fish} ,");
            }
        }
    }
}
