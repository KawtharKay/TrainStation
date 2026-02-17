using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities
{
    public class Passenger : BaseEntity
    {
        public string Email { get; set; } = default!;
        public string PhoneNumber { get; set; } = default!;
        public string EmergencyPhoneNumber { get; set; } = default!;
        public string Name { get; set; } = default!;
        public decimal Wallet { get; set; }
        public ICollection<Booking> Bookings { get; set; } = new HashSet<Booking>();
    }
}
