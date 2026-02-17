using Application.Paging;
using Application.Repositories;
using Domain.Entities;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Repositories
{
    public class PassengerRepository : IPassengerRepository
    {
        private readonly TrainStationContext _context;
        public PassengerRepository(TrainStationContext context)
        {
            _context = context;
        }
        public async Task AddAsync(Passenger passenger)
        {
            await _context.Passengers.AddAsync(passenger);
        }
        public async Task<PaginatedList<Passenger>> GetAllAsync(PagingRequest request, bool allowPaging)
        {
            var query = _context.Passengers.AsQueryable();
            var totalCount = await query.CountAsync();
            if (allowPaging)
            {
                var offset = (request.PageNumber - 1) * request.PageSize;
                var result = await query.Skip(offset).Take(totalCount).ToListAsync();
                return new PaginatedList<Passenger>
                {
                    Items = query,
                    TotalCount = totalCount,
                    PageNumber = request.PageNumber
                };
            }
            return new PaginatedList<Passenger>
            {
                Items = query.ToList(),
                TotalCount = totalCount,
                PageNumber = request.PageNumber
            };
        }

        public async Task<Passenger?> GetAsync(Guid id)
        {
            return await _context.Passengers.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<bool> IsExist(string email)
        {
            return await _context.Passengers.AnyAsync(x => x.Email == email);
        }
    }
}
