using Domain.Enums;

namespace Domain.Entities
{
    public class Trip : BaseEntity
    {
        public Guid TrainId { get; set; }
        public Train Train { get; set; } = default!;
        public Guid RouteId { get; set; }
        public Route Route { get; set; } = default!;
        public DateTime DepartureDate { get; set; }
        public TripStatus Status { get; set; }
        public ICollection<TripSeat> TripSeats { get; set; } = new HashSet<TripSeat>();
    }
}
