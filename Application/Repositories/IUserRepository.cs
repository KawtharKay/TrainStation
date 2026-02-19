using Domain.Entities;

namespace Application.Repositories
{
    public interface IUserRepository
    {
        Task<bool> IsExist(string email);
        Task AddAsync(User user);
        Task<User?> GetAsync(string email);
        Task<User?> GetAsync(Guid id);
        Task<ICollection<User>> GetAllAsync();
        void Update(User user);
    }
}
