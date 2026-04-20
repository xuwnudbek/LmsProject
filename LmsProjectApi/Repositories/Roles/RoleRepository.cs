using LmsProjectApi.Data;
using LmsProjectApi.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace LmsProjectApi.Repositories.Roles
{
    public class RoleRepository : IRoleRepository
    {
        private readonly AppDbContext dbContext;

        public RoleRepository(AppDbContext dbContext) =>
            this.dbContext = dbContext;

        public async Task<Role> InsertRoleAsync(Role role)
        {
            await this.dbContext.Roles.AddAsync(role);
            await this.dbContext.SaveChangesAsync();

            return role;
        }

        public Task<List<Role>> SelectAllRolesAsync() =>
            this.dbContext.Roles.ToListAsync();

        public Task<Role> SelectRoleByIdAsync(Guid roleId) =>
            this.dbContext.Roles
                .FirstOrDefaultAsync(role => role.Id == roleId);

        public async Task<Role> UpdateRoleAsync(Role role)
        {
            Role existingRole =
                await this.dbContext.Roles.FirstOrDefaultAsync(r => r.Id == role.Id);

            if (existingRole is null)
                return null;

            existingRole.Name = role.Name;

            await this.dbContext.SaveChangesAsync();

            return existingRole;
        }

        public async Task DeleteRoleAsync(Guid roleId)
        {
            Role existingRole =
                await this.dbContext.Roles.FirstOrDefaultAsync(r => r.Id == roleId);

            if (existingRole is null)
                return;

            this.dbContext.Remove(existingRole);

            await this.dbContext.SaveChangesAsync();
        }

    }
}
