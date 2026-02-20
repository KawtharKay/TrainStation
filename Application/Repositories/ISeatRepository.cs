using Domain.Entities;

namespace Application.Repositories
{
    public interface ISeatRepository
    {
        Task<bool> IsExist(int seatNo);
        Task AddAsync(Seat seat);
        Task<Seat?> GetAsync(Guid id);
        Task<ICollection<Seat>> GetAllAsync(Guid coachId);
    }
}
