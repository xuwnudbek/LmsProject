
using LmsProjectApi.Data;
using LmsProjectApi.Mappings;
using LmsProjectApi.Middlewares;
using LmsProjectApi.Repositories.Roles;
using LmsProjectApi.Repositories.Users;
using LmsProjectApi.Services.Roles;
using LmsProjectApi.Services.Users;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Scalar.AspNetCore;

namespace LmsProjectApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            
            // I. Database
            builder.Services.AddDbContext<AppDbContext>(options =>
            {
                string connectionString = 
                    builder.Configuration.GetConnectionString("DefaultConnection");

                options.UseSqlite(connectionString);
            });

            // II. Auth Services
            //builder.Services.AddAuthentication();
            //builder.Services.AddAuthorization();

            // III. Custom Services
            // Repositories
            builder.Services.AddTransient<IUserRepository, UserRepository>();
            builder.Services.AddTransient<IRoleRepository, RoleRepository>();
            // Services
            builder.Services.AddTransient<IUserService, UserService>();
            builder.Services.AddTransient<IRoleService, RoleService>();


            // IV. Framework Services
            builder.Services.AddControllers();
            builder.Services.AddOpenApi();
            builder.Services.AddAutoMapper(cfg => {}, typeof(Program));
            
            // Build app
            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.MapOpenApi();
                app.MapScalarApiReference();
            }

            app.UseMiddleware<GlobalExceptionHandlingMiddleware>();
            app.UseHttpsRedirection();
            app.UseAuthorization();
            app.MapControllers();
            app.Run();
        }
    }
}
