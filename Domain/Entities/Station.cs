namespace Domain.Entities
{
    public class Station : BaseEntity
    {
        public string Name { get; set; } = default!;
        public string City { get; set; } = default!;
        public string State { get; set; } = default!;
        public ICollection<StationRoute> StationRoutes { get; set; } = new HashSet<StationRoute>();
    }
}
