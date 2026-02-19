using Application.Paging;
using Domain.Entities;
using System.Linq.Expressions;

namespace Application.Repositories
{
    public interface ICoachRepository
    {
        Task<bool> IsExist(Guid trainId, string coachNo);
        Task<bool?> IsExist(Expression<Func<Coach, bool>> exp);
        Task AddAsync(Coach coach);
        Task<Coach?> GetAsync(Guid id);
        Task<Coach?> GetAsync(Expression<Func<Coach,bool>> exp);
        Task<int> GetTrainCoachCount(Guid trainId);
        Task<PaginatedList<Coach>> GetAllAsync(PagingRequest request, bool allowPaging);
    }
}
