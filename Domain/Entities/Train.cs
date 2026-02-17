namespace Domain.Entities
{
    public class Train : BaseEntity
    {
        public string TrainNo { get; set; } = default!;
        public string EngineNo { get; set; } = default!;
    }
}
