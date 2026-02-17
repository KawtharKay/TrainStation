using Application.Paging;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Repositories
{
    public interface ICoachRepository
    {
        Task<bool> IsExist(Guid trainId, string coachNo);
        Task AddAsync(Coach coach);
        Task<Coach?> GetAsync(Guid id);
        Task<PaginatedList<Coach>> GetAllAsync(PagingRequest request, bool allowPaging);
    }
}
