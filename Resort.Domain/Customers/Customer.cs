using Resort.Domain.SharedKernel;

namespace Resort.Domain.Customers;

public class Customer : AggregateRoot<Guid>
{
    private Customer()
    {

    }

    public Customer(Guid id, string name, Address address, Contact contact)
    {
        Name = name;
        Address = address;
        Contact = contact;
    }
    
    public string Name { get; private set; }
    public Address Address { get; private set; }
    public Contact Contact { get; private set; }
    
    public void UpdateAddress(Address address)
    {
        Address = address;
    }
    public void UpdateContactDetail(Contact contact)
    {
        Contact = contact;
    }
}
