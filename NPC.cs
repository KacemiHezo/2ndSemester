using System;
using System.Collections.Generic;

public class Fish
{
    public int Number { get; set; }
    public string Name { get; set; }
    public FishRarity Rarity { get; set; }
    public string Description { get; set; }
    public decimal Price { get; set; }

    public Fish(int number, string name, FishRarity rarity, string description)
    {
        Number = number;
        Name = name;
        Rarity = rarity;
        Description = description;
    }

    public override string ToString()
    {
        if (Price == 0)
        {
            return $"{Name} (Rarity: {Rarity}) - {Description}";
        }
        return $"{Name} (Rarity: {Rarity}, Price: ${Price:F2}) - {Description}";
    }
}

public enum FishRarity
{
    Common,
    Rare
}

public class FishDatabase
{
    private List<Fish?> fishList;

    public FishDatabase()
    {
        fishList = new List<Fish?>
        {
            new Fish(1, "araneacis", FishRarity.Common, "A fish with 8 fins and 2 stag beetles like pincers, they make good pets"),
            new Fish(2, "sicmn", FishRarity.Common, "A black and white fish, looks skinny, almost like a skeleton, its patterns are used for shoes"),
            new Fish(3, "pislique", FishRarity.Common, "A fish whose scales look like they are melting, usually used as a spice, it has a weird sweet and spicy taste"),
            new Fish(4, "chocolate shark", FishRarity.Rare, "A shark that lives in swamps, its name comes from the pattern on its skin, it's toxic to eat"),
            new Fish(5, "wuopod", FishRarity.Rare, "An octopus-like animal that has two main tentacles and 6 smaller ones. They like to make human faces out of kelp"),
            new Fish(6, "crocodish", FishRarity.Rare, "A crocodile whose spikes look like a salad, a lot of people often eat them alive")
        };
    }

    public Fish? GetFishByNumber(int fishNumber)
    {
        foreach (var fish in fishList)
        {
            if (fish.Number == fishNumber)
            {
                return fish;
            }
        }
        return null;
    }
}

public class NPC
{
    private Random random = new Random();
    private FishDatabase fishDatabase;

    public NPC()
    {

    }

    public void BuildShop(Inventory inventory)
    {
        while (true)
        {
           Console.Clear();
            Console.WriteLine("===WELCOME TO THE SHOP===\n");
            Console.WriteLine($"Your money: ${inventory.GetMoney()}");
            inventory.Display();
            Console.WriteLine("\nWrite 0 to exit shop or any other fish number to sell it");
            var input = Console.ReadLine();
            if (input == "0")
            {
                break;
            }

            var fish = inventory.TakeFishFromInventory(int.Parse(input));
            inventory.AddMoney(SellFish(fish));
        }
    }

    public decimal SellFish(Fish fish)
    {
        if (fish == null)
        {
            throw new ArgumentException("Invalid fish number.");
        }

        if (fish.Rarity == FishRarity.Common)
        {
            fish.Price = random.Next(500, 2001) / 100.0m; // Price range $5 to $20
        }
        else if (fish.Rarity == FishRarity.Rare)
        {
            fish.Price = random.Next(700, 4001) / 100.0m; // Price range $7 to $40
        }

        return fish.Price;
    }
}
