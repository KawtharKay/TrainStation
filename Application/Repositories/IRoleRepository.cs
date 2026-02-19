using Domain.Entities;

namespace Application.Repositories
{
    public interface IRoleRepository
    {
        Task AddAsync(Role role);
        Task<bool> IsExistAsync(string name);
        Task<ICollection<Role>> GetAllAsync();
        Task<Role?> GetAsync(Guid id);
        Task<Role?> GetAsync(string name);
    }
}
