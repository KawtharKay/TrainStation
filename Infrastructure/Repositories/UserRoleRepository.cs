using Application.Repositories;
using Domain.Entities;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class UserRoleRepository(TrainStationContext context) : IUserRoleRepository
    {
        public async Task AddAsync(UserRole userRole)
        {
            await context.AddAsync(userRole);
        }

        public async Task<bool> IsExist(Guid userId, Guid roleId)
        {
            return await context.UserRoles.AnyAsync(a => a.UserId == userId && a.RoleId == roleId);
        }
    }
}
