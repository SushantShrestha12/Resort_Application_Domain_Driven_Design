namespace Resort.Domain.Customers;

public class Contact
{
    private Contact()
    {
        
    }

    public Contact(string mobileNumber, string email)
    {
        MobileNumber = mobileNumber;
        Email = email;
    }
    
    public string MobileNumber { get; private set; }
    public string Email { get; private set; }
}