using Application.Repositories;
using Domain.Entities;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly TrainStationContext _context;
        public UserRepository(TrainStationContext context)
        {
            _context = context;
        }
        public async Task AddAsync(User user)
        {
            await _context.Users.AddAsync(user);
        }

        public async Task<ICollection<User>> GetAllAsync()
        {
            return await _context.Users.Include(x => x.UserRoles).ThenInclude(x => x.Role).ToListAsync();
        }

        public async Task<User?> GetAsync(string email)
        {
            return await _context.Users.Include(x => x.UserRoles).ThenInclude(x => x.Role).SingleOrDefaultAsync(user => user.Email == email);
        }

        public async Task<User?> GetAsync(Guid id)
        {
            return await _context.Users.Include(x => x.UserRoles).ThenInclude(a => a.Role).SingleOrDefaultAsync(user => user.Id == id);
        }

        public async Task<bool> IsExist(string email)
        {
            return await _context.Users.AnyAsync(user => user.Email == email);
        }

        public void Update(User user)
        {
            _context.Users.Update(user);
        }
    }
}
