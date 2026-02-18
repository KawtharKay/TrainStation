namespace Domain.Entities
{
    public class Train : BaseEntity
    {
        public string TrainNo { get; set; } = default!;
        public string EngineNo { get; set; } = default!;
        public ICollection<Coach> Coaches { get; set; } = new HashSet<Coach>();
    }
}
