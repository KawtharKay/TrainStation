using Domain.Enums;

namespace Domain.Entities
{
    public class Booking : BaseEntity
    {
        public string ReferenceNo { get; set; } = default!;
        public Guid PassengerId { get; set; }
        public Passenger Passenger { get; set; } = default!;
        public Guid TripId { get; set; }
        public Trip Trip { get; set; } = default!;
        public Guid TripSeatId { get; set; }
        public TripSeat TripSeat { get; set; } = default!;
        public Guid TakeoffStationId { get; set; }
        public Station TakeoffStation { get; set; } = default!;
        public Guid DestinationStationId { get; set; }
        public Station DestinationStation { get; set; } = default!;
        public BookingStatus Status { get; set; }
        public decimal AmountPaid { get; set; }
    }
}
