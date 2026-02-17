using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Repositories
{
    public interface IRoleRepository
    {
        Task AddAsync(Role role);
        Task<bool> IsExistAsync(string name);
    }
}
