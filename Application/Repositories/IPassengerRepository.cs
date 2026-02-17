using Application.Paging;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Application.Repositories
{
    public interface IPassengerRepository
    {
        Task AddAsync(Passenger passenger);
        Task<Passenger?> GetAsync(Guid id);
        Task<PaginatedList<Passenger>> GetAllAsync(PagingRequest request, bool allowPaging);
        Task<bool> IsExist(string email);
    }
}
