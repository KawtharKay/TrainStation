namespace Domain.Entities
{
    public class StationRoute
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public Guid RouteId { get; set; }
        public Route Route { get; set; } = default!;
        public Guid StationId { get; set; }
        public Station Station { get; set; } = default!;
        public int StopOrder { get; set; }
        public int DistanceFromDeparture { get; set; }
    }
}
