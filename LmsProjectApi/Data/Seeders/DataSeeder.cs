using LmsProjectApi.Data.Context;
using LmsProjectApi.Enums;
using LmsProjectApi.Helpers;
using LmsProjectApi.Models.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LmsProjectApi.Data.Seeders
{
    public class DataSeeder
    {
        public static async Task SeedUsers(AppDbContext context)
        {

            if (!context.Users.Any())
            {
                var now = DateTimeOffset.UtcNow;

                var users = new List<User>
                {
                    new User {
                        Id = Guid.Parse("652e9115-282f-41e6-a2f3-a10729075e40"),
                        FirstName = "Admin",
                        LastName = "Super",
                        IsActive = true,
                        Username = "admin",
                        PasswordHash = HashingHelper.GetHash("admin123"),
                        PhoneNumber = "+998901234567",
                        Role = UserRole.Admin,
                    }
                };

                context.AddRange(users);
                await context.SaveChangesAsync();
            }
        }
    }
}
