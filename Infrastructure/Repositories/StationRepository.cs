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
    public class StationRepository : IStationRepository
    {
        private readonly TrainStationContext _context;
        public StationRepository(TrainStationContext context)
        {
            _context = context;
        }
        public async Task AddAsync(Station station)
        {
            await _context.Stations.AddAsync(station);
        }

        public async Task<PaginatedList<Station>> GetAll(PagingRequest request, bool allowPaging)
        {
            var query = _context.Stations.AsQueryable();
            var totalCount = await query.CountAsync();
            if (allowPaging)
            {
                var offset = (request.PageNumber - 1) * request.PageSize;
                var result = await query.Skip(offset).Take(totalCount).ToListAsync();
                return new PaginatedList<Station>
                {
                    Items = query,
                    TotalCount = totalCount,
                    PageNumber = request.PageNumber
                };
            }
            return new PaginatedList<Station>
            {
                Items = query.ToList(),
                TotalCount = totalCount,
                PageNumber = request.PageNumber
            };

        }

        public async Task<Station?> GetAsync(Guid id)
        {
            return await _context.Stations.FirstOrDefaultAsync(station => station.Id == id);
        }

        public async Task<bool> IsExist(string name)
        {
            return await _context.Stations.AnyAsync(station => station.Name == name);
        }
    }
}
