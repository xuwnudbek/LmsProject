using LmsProjectApi.Data;
using LmsProjectApi.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
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

        public async Task<User> InsertUserAsync(User user)
        {
            await this.dbContext.Users.AddAsync(user);
            await this.dbContext.SaveChangesAsync();

            return user;
        }

        public List<User> SelectAllUsersAsync()
        {
            List<User> users = 
                this.dbContext.Users
                    .AsNoTracking()
                    .ToList();

            return users;
        }

        public async Task<User> SelectUserByIdAsync(Guid userId)
        {
            User existingUser =
                await this.dbContext.Users
                    .Include(user => user.Role)
                    .FirstOrDefaultAsync(user => user.Id == userId);

            return existingUser;
        }

        public async Task<User> SelectUserByUsernameAsync(string username)
        {
            User existingUser =
                await this.dbContext.Users
                    .FirstOrDefaultAsync(user => user.Username == username);

            return existingUser;
        }

        public async Task<User> UpdateUserAsync(User user)
        {
            await this.dbContext.SaveChangesAsync();
            return user;
        }

        public async Task<User> DeleteUserAsync(Guid userId)
        {
            var user = await this.dbContext.Users
                .FirstOrDefaultAsync(u => u.Id == userId);

            if (user is null)
                return null;

            user.IsActive = false;

            await this.dbContext.SaveChangesAsync();

            return user;
        }
    }
}
