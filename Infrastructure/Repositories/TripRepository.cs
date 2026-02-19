using Application.Repositories;
using Domain.Entities;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Repositories
{
    public class TripRepository(TrainStationContext context) : ITripRepository
    {
        public async Task AddAsync(Trip trip)
        {
            await context.Trips.AddAsync(trip);
        }

        public async Task<ICollection<Trip>> GetAllAsync()
        {
            return await context.Trips.ToListAsync();
        }

        public async Task<Trip?> GetAsync(Guid id)
        {
            return await context.Trips.FirstOrDefaultAsync(x  => x.Id == id);
        }

        public async Task<bool> IsExist(Guid id)
        {
            return await context.Trips.AnyAsync(x => x.Id == id);
        }
    }
}
