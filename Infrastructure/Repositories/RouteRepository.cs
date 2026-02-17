using Application.Paging;
using Application.Repositories;
using Domain.Entities;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class RouteRepository : IRouteRepository
    {
        private readonly TrainStationContext _context;
        public RouteRepository(TrainStationContext context)
        {
            _context = context;
        }
        public async Task AddAsync(Route route)
        {
            await _context.Routes.AddAsync(route);
        }

        public async Task<PaginatedList<Route>> GetAllAsync(PagingRequest request, bool allowPaging)
        {
            var query = _context.Routes.AsQueryable();
            var totalCount = await query.CountAsync();
            if (allowPaging)
            {
                var offset = (request.PageNumber - 1) * request.PageSize;
                var result = await query.Skip(offset).Take(totalCount).ToListAsync();
                return new PaginatedList<Route>
                {
                    Items = query,
                    TotalCount = totalCount,
                    PageNumber = request.PageNumber
                };
                }
                return new PaginatedList<Route>
                {
                    Items = query.ToList(),
                    TotalCount = totalCount,
                    PageNumber = request.PageNumber
                };
        }

        public async Task<Route?> GetAsync(Guid id)
        {
            return await _context.Routes.Include(x => x.StationRoutes).ThenInclude(a => a.Station).FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<bool> IsExist(string name)
        {
            return await _context.Routes.AnyAsync(x => x.Name == name);
        }
    }
}
