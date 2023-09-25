using Resort.Domain.Firms;

namespace Resort.Domain;

public record FoodMenu
{
    private FoodMenu()
    {

    }

    public FoodMenu(string foodName, Rates price, int quantity, FoodType type)
    {
        FoodName = foodName;
        Price = price;
        Quantity = quantity;
        Type = type;
    }

    public string FoodName { get; private set; }
    public Rates Price { get; private set; }
    public int Quantity { get; private set; }
    public FoodType Type { get; private set; }
}