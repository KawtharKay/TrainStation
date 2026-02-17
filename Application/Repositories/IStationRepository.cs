using Application.Paging;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Repositories
{
    public interface IStationRepository
    {
        Task<bool> IsExist(string name);
        Task AddAsync(Station station);
        Task<Station?> GetAsync(Guid id);
        Task<PaginatedList<Station>> GetAll(PagingRequest request, bool allowPaging);
    }
}
