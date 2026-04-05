using System;

public class PetStoreItem
{

    private static int count = 0;
    private readonly int itemCode;
    private string name;
    private double price;

    public int ItemCode { get { return itemCode; } }
    public string Name { get { return name; } }
    public double Price { get { return price; } }

    public PetStoreItem(int itemCode, string name, double price)
    {
        this.itemCode = itemCode;
        this.name = name;
        this.price = price;
        count++;
    }

    public static int GetTotalCount()
    {
        return count;
    }

    public virtual string GetInfo()
    {
        return $"Код: {itemCode}, Назва: '{name}', Ціна: {price} грн";
    }

    public bool IsExpensive()
    {
        return price > 800;
    }

}

public class Food : PetStoreItem
{
    private string animalType;
    public Food(int itemCode, string name, double price, string animalType)
              : base(itemCode, name, price)
    {
        this.animalType = animalType;
    }

}
public class Accessory : PetStoreItem
{
    private string material;

    public Accessory(int itemCode, string name, double price, string material)
        : base(itemCode, name, price)
    {
        this.material = material;
    }

    public override string GetInfo()
    {
        return base.GetInfo() + $" | Матеріал: {material} (Аксесуар)";
    }
}



