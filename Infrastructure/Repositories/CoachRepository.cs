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
    public class CoachRepository : ICoachRepository
    {
        private readonly TrainStationContext _context;
        public CoachRepository(TrainStationContext context)
        {
            _context = context;
        }
        public async Task AddAsync(Coach coach)
        {
            await _context.Coaches.AddAsync(coach);
        }

        public async Task<PaginatedList<Coach>> GetAllAsync(PagingRequest request, bool allowPaging)
        {
            var query = _context.Coaches.AsQueryable();
            var totalCount = await query.CountAsync();
            if (allowPaging)
            {
                var offset = (request.PageNumber - 1) * request.PageSize;
                var result = await query.Skip(offset).Take(totalCount).ToListAsync();
                return new PaginatedList<Coach>
                {
                    Items = query,
                    TotalCount = totalCount,
                    PageNumber = request.PageNumber
                };
            }
            return new PaginatedList<Coach>
            {
                Items = query.ToList(),
                TotalCount = totalCount,
                PageNumber = request.PageNumber
            };
        }

        public async Task<Coach?> GetAsync(Guid id)
        {
            return await _context.Coaches.FirstOrDefaultAsync(a => a.Id == id);
        }

        public async Task<bool> IsExist(Guid trainId, string coachNo)
        {
            return await _context.Coaches.AnyAsync(x => x.TrainId == trainId);
        }
    }
}
