using Application.Paging;
using Application.Repositories;
using Domain.Entities;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using Mysqlx.Session;
using MySqlX.XDevAPI.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Repositories
{
    public class TrainRepository : ITrainRepository
    {
        private readonly TrainStationContext _context;
        public TrainRepository(TrainStationContext context)
        {
            _context = context;
        }
        public async Task AddAsync(Train train)
        {
            await _context.Trains.AddAsync(train);
        }

        public async Task<PaginatedList<Train>> GetAll(PagingRequest request, bool allowPaging)
        {
            var query = _context.Trains.AsQueryable();
            var totalCount = await query.CountAsync();
            if(allowPaging)
            {
                var offset = (request.PageNumber - 1) * request.PageSize;
                var result = await query.Skip(offset).Take(totalCount).ToListAsync();
                return new PaginatedList<Train>
                {
                    Items = result,
                    TotalCount = totalCount,
                    PageNumber = request.PageNumber
                };
            }
            return new PaginatedList<Train>
            {
                Items = query.ToList(),
                TotalCount = totalCount,
                PageNumber = request.PageNumber
            };
        }

        public Task<Train?> GetAsync(Guid id)
        {
            return _context.Trains.FirstOrDefaultAsync(t => t.Id == id);
        }

        public async Task<bool> IsExist(string trainNumber)
        {
            return await _context.Trains.AnyAsync(train => train.TrainNo == trainNumber);
        }
    }
}
