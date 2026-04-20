using LmsProjectApi.Data;
using LmsProjectApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LmsProjectApi.Repositories.Roles
{
    public class RoleRepository : IRoleRepository
    {
        private readonly AppDbContext dbContext;

        public RoleRepository(AppDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        
        public async Task<Role> InsertRoleAsync(Role role)
        {
            //await this.dbContext.Roles
            throw new System.NotImplementedException();
        }

        public Task<List<Role>> SelectAllRolesAsync()
        {
            throw new System.NotImplementedException();
        }

        public Task<Role> SelectRoleByIdAsync(Guid roleId)
        {
            throw new System.NotImplementedException();
        }
        
        public Task<Role> UpdateRoleAsync(Role role)
        {
            throw new System.NotImplementedException();
        }
        
        public Task<Role> DeleteRoleAsync(Guid roleId)
        {
            throw new System.NotImplementedException();
        }

    }
}
