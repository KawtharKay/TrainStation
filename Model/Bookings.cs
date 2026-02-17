using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TrainStation.Model
{
    public class Bookings : BaseEntity
    {
        public string RefNo { get; set; } = null!;
        public int CustomerId { get; set; } 
        public int TripId { get; set; }

        public Bookings(int id, string refNo, int customerId, int tripId) : base(id)
        {
            RefNo = refNo;
            CustomerId = customerId;
            TripId = tripId;
        }
    }
}