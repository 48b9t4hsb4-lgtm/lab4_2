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
    public override string GetInfo()
    {
        return base.GetInfo() + $" | Тип тварини: {animalType} (Корм)";
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

namespace lab4_2
{
    class Program
    {
        static void Main()
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            List<PetStoreItem> inventory = new List<PetStoreItem>
            {
                new Food(891, "Паштет преміум", 150, "Кіт"),
                new Food(892, "Сухий корм", 950, "Пес"),
                new Accessory(101, "Шкіряний нашийник", 300, "Шкіра"),
                new Accessory(102, "Великий будиночок", 1500, "Дерево та плюш")
            };

            double totalPrice = 0;
            int expensiveItemsCount = 0;


            foreach (PetStoreItem item in inventory)
            {
                Console.WriteLine(item.GetInfo());

                totalPrice = totalPrice + item.Price;

                if (item.IsExpensive())
                {
                    expensiveItemsCount++;
                }
            }

            Console.WriteLine($"Загальна кількість створених товарів: {PetStoreItem.GetTotalCount()}");
            Console.WriteLine($"Загальна сума цін усіх товарів: {totalPrice} грн");
            Console.WriteLine($"Кількість 'дорогих' товарів: {expensiveItemsCount}");
        }
    }
}


