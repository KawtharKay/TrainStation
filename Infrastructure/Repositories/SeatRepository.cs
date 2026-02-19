using Application.Repositories;
using Domain.Entities;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class SeatRepository(TrainStationContext context) : ISeatRepository
    {
        public async Task AddAsync(Seat seat)
        {
            await context.Seats.AddAsync(seat);
        }

        public async Task<ICollection<Seat>> GetAllAsync(Guid coachId)
        {
            return await context.Seats.Where(a => a.CoachId == coachId).OrderBy(a => a.SeatNo).ToListAsync();
        }

        public async Task<bool> IsExist(int seatNo)
        {
            return await context.Seats.AnyAsync(x => x.SeatNo == seatNo);
        }
    }
}
