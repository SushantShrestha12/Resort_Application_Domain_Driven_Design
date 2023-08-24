namespace Resort.Domain
{
	public enum RoomTypes: int
	{
		Standard, 
		Deluxe, 
		Suite 
	}
	
	public sealed class Room
	{
		private Room()
		{
			
		}
        
		public Room(string roomNumber, RoomTypes roomType, Features features, Rates rate)
		{
			Number = roomNumber;
            RoomType = roomType;
			Features = features;
			Rate = rate;
			Availability = true;
		}
        public string Number { get; private set; }
        public RoomTypes RoomType { get; private set; }
        public Features Features { get; private set; }
        public Rates Rate { get; private set; }
        public bool Availability { get; private set; }
        
        public void SetRoomAvailability(bool availability)
        {
	        Availability = availability;
        }
	}
}