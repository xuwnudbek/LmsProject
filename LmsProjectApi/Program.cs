using LmsProjectApi.Data.Context;
using LmsProjectApi.Data.Seeders;
using LmsProjectApi.Middlewares;
using LmsProjectApi.Repositories.Attendances;
using LmsProjectApi.Repositories.Courses;
using LmsProjectApi.Repositories.Groups;
using LmsProjectApi.Repositories.Levels;
using LmsProjectApi.Repositories.Subjects;
using LmsProjectApi.Repositories.Users;
using LmsProjectApi.Services.Accounts;
using LmsProjectApi.Services.Courses;
using LmsProjectApi.Services.Groups;
using LmsProjectApi.Services.Levels;
using LmsProjectApi.Services.Subjects;
using LmsProjectApi.Services.Users;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Scalar.AspNetCore;
using System;
using System.Runtime.Intrinsics.Arm;
using System.Text;
using System.Threading.Tasks;

namespace LmsProjectApi
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add Environment Variables
            builder.Configuration.AddEnvironmentVariables();

            // ADD SERVICES TO THE CONTAINER.
            // I. Database
            builder.Services.AddDbContext<AppDbContext>(options =>
            {
                var connectionString = Environment.GetEnvironmentVariable("CONNECTION_STRING");

                if (connectionString is null)
                {
                    connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
                }

                options.UseNpgsql(connectionString);
            });

            // II. Auth Services
            builder.Services.AddAuthentication(option =>
            {
                option.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                option.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
                .AddJwtBearer(option =>
                {
                    option.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidIssuer = builder.Configuration["AuthConfiguration:Issuer"],
                        ValidateAudience = true,
                        ValidAudience = builder.Configuration["AuthConfiguration:Audience"],
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(
                            Encoding.UTF8.GetBytes(builder.Configuration["AuthConfiguration:Key"])),
                    };
                });
            builder.Services.AddAuthorization();

            // III. Custom Services
            // Repositories

            builder.Services.Scan(scan => scan
                .FromAssemblyOf<IUserRepository>()
                .AddClasses(classes => classes.Where(type => type.Name.EndsWith("Repository")))
                .AsImplementedInterfaces()
                .WithScopedLifetime()
            );

            // Services
            builder.Services.Scan(scan => scan
                .FromAssemblyOf<IUserService>()
                .AddClasses(classes => classes.Where(type => type.Name.EndsWith("Service")))
                .AsImplementedInterfaces()
                .WithScopedLifetime()
            );

            // IV. Framework Services
            builder.Configuration.AddEnvironmentVariables();
            builder.Services.AddControllers();
            builder.Services.AddOpenApi();
            builder.Services.AddAutoMapper(cfg => { }, typeof(Program));


            // Build app
            var app = builder.Build();

            // Seeder
            using (var scope = app.Services.CreateScope())
            {
                var context = scope.ServiceProvider.GetRequiredService<AppDbContext>();

                try
                {
                    await context.Database.MigrateAsync();
                    await DataSeeder.SeedUsers(context);
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Migration/Seed error: {ex.Message}");
                }
            }

            // Configure the HTTP request pipeline3.
            if (app.Environment.IsDevelopment())
            {
                try
                {
                    app.MapOpenApi();
                    app.MapScalarApiReference(option =>
                    {
                        option.Servers = new[]
                        {
                            new ScalarServer("https://lmsproject-7s5u.onrender.com")
                        };
                    });
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"OpenApi error: {ex.Message}");
                }
            }

            app.Use(async (context, next) =>
            {
                if (context.Request.Path == "/")
                {
                    context.Response.Redirect("/scalar");
                    return;
                }
                await next();
            });

            app.UseMiddleware<GlobalExceptionHandlingMiddleware>();
            app.UseHttpsRedirection();
            app.UseAuthentication();
            app.UseAuthorization();
            app.MapControllers();
            app.Run();
        }

    }
}
