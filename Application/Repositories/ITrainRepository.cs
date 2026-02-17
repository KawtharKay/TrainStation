using Application.Paging;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Repositories
{
    public interface ITrainRepository
    {
        Task<bool> IsExist(string trainNumber);
        Task AddAsync(Train train);
        Task<Train?> GetAsync(Guid id);
        Task<PaginatedList<Train>> GetAll(PagingRequest request, bool allowPaging);
    }
}
