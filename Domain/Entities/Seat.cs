using Domain.Enums;

namespace Domain.Entities
{
    public class Seat : BaseEntity
    {
        public Guid CoachId { get; set; }
        public Coach Coach { get; set; } = default!;
        public int SeatNo { get; set; }
    }
}
