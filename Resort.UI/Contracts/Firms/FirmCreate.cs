namespace Resort.UI.Contracts;

public class FirmCreate
{
    public string Name { get; set; }
    public string Province { get; set; }
    public string City { get; set; }
    public string Municipality { get; set; }
    public string AddressLine { get; set; }
    public string WardNumber { get; set; }
    
    public string ContactPerson { get; set; }
    public string MobileNumber { get; set; }
    public string TelephoneNumber { get; set; }
    public string Email { get; set; }
    public string Website { get; set; }
}