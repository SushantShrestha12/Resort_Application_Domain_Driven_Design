namespace Resort.Domain;

public record FoodType
{
    private FoodType()
    {
        
    }

    public FoodType(bool nonVeg)
    {
        NonVeg = nonVeg;
    }
    public bool NonVeg { get; private set; }
}