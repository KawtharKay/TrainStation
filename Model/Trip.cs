using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TrainStation.Model
{
    public class Trip : BaseEntity
    {
        public int TakeOffLocationId { get; set; } 
        public int DestinationId { get; set; }
        public DateTime TakeOffTime { get; set; }
        public double Price { get; set; }

        public Trip(int id, int takeOff, int destination, DateTime takeOffTime,  double price) : base(id)
        {
            TakeOffLocationId = takeOff;
            DestinationId = destination;
            TakeOffTime = takeOffTime;
            Price = price;
        }
    }
}