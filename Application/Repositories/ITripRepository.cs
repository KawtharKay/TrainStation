using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Repositories
{
    public interface ITripRepository
    {
        Task<bool> IsExist(Guid id);
        Task AddAsync(Trip trip);
        Task<Trip?> GetAsync(Guid id);
        Task<ICollection<Trip>> GetAllAsync();
    }
}
