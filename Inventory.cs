public class Inventory
{
    private List<Fish?> fishList = new List<Fish?>();
    private decimal money = new();

    public void AddFish(Fish? fish)
    {
        fishList.Add(fish);
    }

    public void Display()
    {
        if (fishList.Count == 0)
        {
            Console.WriteLine("Your inventory is empty.");
        }
        else
        {
            for (int i = 0; i < fishList.Count; i++)
            {
                Console.WriteLine($"{i + 1}: {fishList.ElementAt(i)} ,\n");
            }
        }
    }


    public Fish TakeFishFromInventory(int position)
    {
        var fish = fishList.ElementAt(position - 1);
        fishList.RemoveAt(position - 1);
        return fish;
    }

    public void AddMoney(decimal newMoney)
    {
        money += newMoney;
    }

    public decimal GetMoney()
    {
        return money;
    }

}
