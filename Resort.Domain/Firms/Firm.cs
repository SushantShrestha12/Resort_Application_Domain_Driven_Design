﻿using Resort.Domain.SharedKernel;

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

    public void AddRoom( string roomNumber, RoomTypes roomType, Features features,
        Rates rate)
    {
        _rooms.Add(new Room(roomNumber, roomType, features, rate));
    }

    public Room? GetRoomById(IReadOnlyCollection<Room> rooms, string roomNumber)
    {
        return rooms.FirstOrDefault(r => r.Number == roomNumber);
    }
    
    public void RemoveRoom(string roomNumber, RoomTypes roomType, Features features,
        Rates rate)
    {
        _rooms.Remove(new Room( roomNumber, roomType, features, rate));
    }
    public void AddFoodMenu(string foodName, Rates price, int quantity, FoodType type)
    {
        _foodMenus.Add(new FoodMenu(foodName, price, quantity, type));
    }

    public void UpdateAddress(string province, string city, string municipality, string addressLine, string wardNo)
    {
        Address = new( province, city, municipality, addressLine, wardNo);
    }
    
    public void UpdateContactDetail(string contactPerson, string mobileNumber, string telephone, string email, string website)
    {
        Contact = new(contactPerson, mobileNumber, telephone, email, website);
    }
}
