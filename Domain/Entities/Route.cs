namespace Domain.Entities
{
    public class Route : BaseEntity
    {
        public string Name { get; set; } = default!;
        public ICollection<StationRoute> StationRoutes { get; set; } = new HashSet<StationRoute>();
    }
}
