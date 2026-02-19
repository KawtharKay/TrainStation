using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Repositories
{
    public interface ISeatRepository
    {
        Task<bool> IsExist(int seatNo);
        Task AddAsync(Seat seat);
        Task<ICollection<Seat>> GetAllAsync(Guid coachId);
    }
}
