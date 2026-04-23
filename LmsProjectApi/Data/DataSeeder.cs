using LmsProjectApi.Enums;
using LmsProjectApi.Helpers;
using LmsProjectApi.Models.Users;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LmsProjectApi.Data
{
    public class DataSeeder
    {
        public static async Task SeedUsers(AppDbContext context)
        {

            if (!context.Users.Any())
            {
                var now = DateTime.UtcNow;

                var users = new List<User>
                {
                    new User {
                        Id = Guid.NewGuid(),
                        FirstName = "Admin",
                        LastName = "Super",
                        IsActive = true,
                        Username = "admin",
                        PasswordHash = HashingHelper.GetHash("admin123"),
                        PhoneNumber = "+998901234567",
                        Role = UserRole.Admin,
                        CreatedAt = now,
                        UpdatedAt = now,
                    }
                };

                context.AddRange(users);
                await context.SaveChangesAsync();
            }
        }
    }
}
