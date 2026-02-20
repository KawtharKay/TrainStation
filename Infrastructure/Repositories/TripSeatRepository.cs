using Application.Repositories;
using Domain.Entities;
using Infrastructure.Context;

namespace Infrastructure.Repositories
{
    public class TripSeatRepository(TrainStationContext context) : ITripSeatRepository
    {
        public async Task AddAsync(TripSeat tripSeat)
        {
            await context.TripSeats.AddAsync(tripSeat);
        }
    }
}
