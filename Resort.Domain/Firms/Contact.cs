namespace Resort.Domain.Firms
{
	public record Contact
	{
		private Contact()
		{

		}

		public Contact(string contactPerson, string mobileNumber, string telephoneNumber,
			string email, string website)
		{
			ContactPerson = contactPerson;
			MobileNumber = mobileNumber;
			TelephoneNumber = telephoneNumber;
			Email = email;
			Website = website;
		}

		public string ContactPerson { get; private set; }
		public string MobileNumber { get; private set; }
		public string TelephoneNumber { get; private set; }
		public string Email { get; private set; }
		public string Website { get; private set; }
	}
}

