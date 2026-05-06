using LmsProjectApi.Data.Context;
using LmsProjectApi.Enums;
using LmsProjectApi.Models.Users;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace LmsProjectApi.Repositories.Users
{
    public class UserRepository : IUserRepository
    {
        private readonly AppDbContext dbContext;

        public UserRepository(AppDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<User> InsertAsync(User user)
        {
            await this.dbContext.Users.AddAsync(user);
            await this.dbContext.SaveChangesAsync();

            return user;
        }

        public IQueryable<User> SelectAll()
        {
            return this.dbContext.Users
                .AsNoTracking();
        }

        public IQueryable<User> SelectByRole(UserRole role)
        {
            return this.dbContext.Users
                .Where(user => user.Role == role);
        }

        public async Task<User> SelectByIdAsync(Guid userId)
        {
            return await this.dbContext.Users
                .FirstOrDefaultAsync(user => user.Id == userId);
        }

        public async Task<User> SelectByUsernameAsync(string username)
        {
            return await this.dbContext.Users
                .FirstOrDefaultAsync(user => user.Username == username);
        }

        public async Task UpdateAsync()
        {
            await this.dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid userId)
        {
            var existingUser = await this.dbContext.Users
                .FirstOrDefaultAsync(u => u.Id == userId);

            if (existingUser is null)
                return;

            existingUser.IsActive = false;

            await this.dbContext.SaveChangesAsync();
        }
    }
}