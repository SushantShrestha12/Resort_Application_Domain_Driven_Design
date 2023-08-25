namespace Resort.UI.Contracts;

public class MenuCreate
{
    public string FoodName { get;  set; }
    public string Currency { get;  set; }
    public decimal Amount { get;  set; }
    public int Quantity { get;  set; }
    public bool NonVeg { get;  set; }
}