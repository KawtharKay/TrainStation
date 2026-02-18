using Domain.Enums;

namespace Domain.Entities
{
    public class TripSeat : BaseEntity
    {
        public Guid TripId { get; set; }
        public Trip Trip { get; set; } = default!;
        public Guid SeatId { get; set; }
        public Seat Seat { get; set; } = default!;
        public SeatStatus Status { get; set; } 
    }
}
