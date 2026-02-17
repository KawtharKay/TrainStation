using Domain.Enums;

namespace Domain.Entities
{
    public class Booking : BaseEntity
    {
        public string ReferenceNo { get; set; } = default!;
        public Guid PassengerId { get; set; }
        public Guid RouteId { get; set; }
        public int SeatNo { get; set; }
        public BookingClass BookingClass { get; set; }
        public Guid TakeoffStationId { get; set; }
        public Guid DestinationStationId { get; set; }
    }
}
