using LmsProjectApi.Data;
using LmsProjectApi.Middlewares;
using LmsProjectApi.Repositories.Levels;
using LmsProjectApi.Repositories.Subjects;
using LmsProjectApi.Repositories.Users;
using LmsProjectApi.Services.Accounts;
using LmsProjectApi.Services.Levels;
using LmsProjectApi.Services.Subjects;
using LmsProjectApi.Services.Users;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Scalar.AspNetCore;
using System.Text;
using System.Threading.Tasks;

namespace LmsProjectApi
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // ADD SERVICES TO THE CONTAINER.
            // I. Database
            builder.Services.AddDbContext<AppDbContext>(options =>
            {
                string connectionString =
                    builder.Configuration.GetConnectionString("DefaultConnection");

                options.UseSqlite(connectionString);
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
            builder.Services.AddTransient<IUserRepository, UserRepository>();
            builder.Services.AddTransient<ISubjectRepository, SubjectRepository>();
            builder.Services.AddTransient<ILevelRepository, LevelRepository>();

            // Services
            builder.Services.AddTransient<IUserService, UserService>();
            builder.Services.AddTransient<IAccountService, AccountService>();
            builder.Services.AddTransient<ISubjectService, SubjectService>();
            builder.Services.AddTransient<ILevelService, LevelService>();

            // IV. Framework Services
            builder.Services.AddControllers();
            builder.Services.AddOpenApi();
            builder.Services.AddAutoMapper(cfg => { }, typeof(Program));

            // Build app
            var app = builder.Build();

            // Seeder
            using (var scope = app.Services.CreateScope())
            {
                var context = scope.ServiceProvider.GetRequiredService<AppDbContext>();

                await DataSeeder.SeedUsers(context);
            }

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.MapOpenApi();
                app.MapScalarApiReference();
            }

            app.UseMiddleware<GlobalExceptionHandlingMiddleware>();
            app.UseHttpsRedirection();
            app.UseAuthentication();
            app.UseAuthorization();
            app.MapControllers();
            app.Run();
        }
    
    }
}
