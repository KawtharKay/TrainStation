using Application.Repositories;
using Domain.Entities;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Repositories
{
    public class RoleRepository(TrainStationContext context) : IRoleRepository
    {
        public async Task AddAsync(Role role)
        {
            await context.Roles.AddAsync(role);
        }

        public async Task<ICollection<Role>> GetAllAsync()
        {
            return await context.Roles.ToListAsync();
        }

        public async Task<Role?> GetAsync(Guid id)
        {
            return await context.Roles.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Role?> GetAsync(string name)
        {
            return await context.Roles.FirstOrDefaultAsync(x => x.Name == name);
        }
        public Task<bool> IsExistAsync(string name)
        {
            return context.Roles.AnyAsync(a => a.Name == name);
        }
    }
}
