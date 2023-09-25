using Resort.Domain.SharedKernel;

namespace Resort.Domain.Firms;

public class Firm : AggregateRoot<Guid>
{
    private Firm()
    {

    }

    public Firm(Guid id, string name, Address address, Contact contact)
        : base(id) 
    {
        if (string.IsNullOrEmpty(name))
        {
            throw new ArgumentException( "Name can not be empty.", nameof(Name));
        }
        
        Name = name;
        Address = address;
        Contact = contact;
    }
    public string Name { get; private set; }
    public Address Address { get; private set; }
    public Contact Contact { get; private set; }

    private readonly List<Room> _rooms = new();
    public IReadOnlyCollection<Room> Rooms => _rooms;

    private readonly List<FoodMenu> _foodMenus = new();
    
    public IReadOnlyCollection<FoodMenu> Foods => _foodMenus;

    public void AddRoom( Guid roomId, string roomNumber, RoomTypes roomType, Features features,
        Rates rate)
    {
        _rooms.Add(new Room(roomId, roomNumber, roomType, features, rate));
    }

    public Room? GetRoomById(IReadOnlyCollection<Room> rooms, string roomNumber)
    {
        return rooms.FirstOrDefault(r => r.Number == roomNumber);
    }
    
    public void RemoveRoom(Guid roomId, string roomNumber, RoomTypes roomType, Features features,
        Rates rate)
    {
        _rooms.Remove(new Room(roomId, roomNumber, roomType, features, rate));
    }
    public void AddFoodMenu(string foodName, Rates price, int quantity, FoodType type)
    {
        _foodMenus.Add(new FoodMenu(foodName, price, quantity, type));
    }

    public void UpdateAddress(Address address)
    {
        Address = address;
    }
    public void UpdateContactDetail(Contact contact)
    {
        Contact = contact;
    }
}

