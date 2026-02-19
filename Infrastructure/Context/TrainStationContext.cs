using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Context
{
    public class TrainStationContext : DbContext
    {
        public TrainStationContext(DbContextOptions<TrainStationContext> options) : base(options)
        {   }

        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }
        public DbSet<Booking> Bookings { get; set; }
        public DbSet<Coach> Coaches { get; set; }
        public DbSet<Passenger> Passengers { get; set; }
        public DbSet<Route> Routes { get; set; }
        public DbSet<Station> Stations { get; set; }
        public DbSet<StationRoute> StationRoutes { get; set; }
        public DbSet<Train> Trains { get; set; }
        public DbSet<Seat> Seats { get; set; }
        public DbSet<Trip> Trips { get; set; }
        public DbSet<TripSeat> TripSeats { get; set; }
    }
}
