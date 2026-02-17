using Application.Paging;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Repositories
{
    public interface IRouteRepository
    {
        Task<bool> IsExist(string name);
        Task AddAsync(Route route);
        Task<Route?> GetAsync(Guid id);
        Task<PaginatedList<Route>> GetAllAsync(PagingRequest request, bool allowPaging);
    }
}
