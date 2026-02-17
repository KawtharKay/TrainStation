using Domain.Enums;

namespace Domain.Entities
{
    public class Coach : BaseEntity
    {
        public Guid TrainId { get; set; }
        public string CoachNo { get; set; } = default!;
        public int CoachOrder {  get; set; }
        public int Capacity { get; set; }
        public BookingClass BookingClass { get; set; }
    }
}
