namespace Domain.Entities
{
    public class Seat : BaseEntity
    {
        public Guid CoachId { get; set; }
        public Coach Coach { get; set; } = default!;
        public int SeatNo { get; set; }
        public ICollection<TripSeat> TripSeats { get; set; } = new HashSet<TripSeat>();
    }
}
