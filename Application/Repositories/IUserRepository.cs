using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Repositories
{
    public interface IUserRepository
    {
        Task<bool> IsExist(string email);
        Task AddAsync(User user);
        Task<User?> GetAsync(string email);
    }
}
