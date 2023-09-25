namespace Resort.Domain;

public class Rates
{
    private Rates()
    {
        
    }

    public Rates(string currency, decimal amount)
    {
        Currency = currency;
        Amount = amount;
    }
    
    public string Currency { get; private set; }
    public decimal Amount { get; private set; }
}
