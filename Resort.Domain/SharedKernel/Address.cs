using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Resort.Domain.SharedKernel
{
    public sealed record Address
    {
        private Address()
        {

        }

        public Address(string province, string city, string municipality, string addressLine, string wardNo)
        {
            Province = province;
            City = city;
            Municipality = municipality;
            AddressLine = addressLine;
            WardNo = wardNo;
        }
        public string Province { get; private set; }
        public string City { get; private set; }
        public string Municipality { get; private set; }
        public string AddressLine { get; private set; }
        public string WardNo { get; private set; }
        
    }
}

