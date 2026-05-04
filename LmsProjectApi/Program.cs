using FluentValidation;
using LmsProjectApi.Data.Context;
using LmsProjectApi.Data.Seeders;
using LmsProjectApi.Middlewares;
using LmsProjectApi.Repositories.Users;
using LmsProjectApi.Services.Users;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Scalar.AspNetCore;
using System;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;


namespace LmsProjectApi
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            
            // Add Environments
            builder.Configuration.AddEnvironmentVariables();

            // ADD SERVICES TO THE CONTAINER.
            // I. Database
            builder.Services.AddDbContext<AppDbContext>(options =>
            {
                var connectionString = Environment.GetEnvironmentVariable("CONNECTION_STRING");

                connectionString ??= builder.Configuration.GetConnectionString("DefaultConnection");

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

            // Services & Repositories
            builder.Services.Scan(scan => scan
                .FromAssemblyOf<IUserRepository>()
                .AddClasses(classes => classes.Where(type => type.Name.EndsWith("Repository")))
                .AsImplementedInterfaces()
                .WithScopedLifetime()
            );
            builder.Services.Scan(scan => scan
                .FromAssemblyOf<IUserService>()
                .AddClasses(classes => classes.Where(type => type.Name.EndsWith("Service")))
                .AsImplementedInterfaces()
                .WithScopedLifetime()
            );


            // IV. Framework Services
            builder.Services.AddValidatorsFromAssemblyContaining(typeof(Program));
            
            builder.Services.AddControllers()
                .AddJsonOptions(options =>
                {
                    options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
                });

            builder.Services.AddOpenApi();
            
            builder.Services.AddAutoMapper(cfg => { }, typeof(Program));
            builder.Services.AddCors(options =>
            {
                options.AddPolicy("AllowFrontend", policy =>
                {
                    policy.AllowAnyOrigin()
                      .AllowAnyHeader()
                      .AllowAnyMethod();
                });
            });

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

            if (app.Environment.IsDevelopment())
            {
                try
                {
                    app.MapOpenApi();
                    app.MapScalarApiReference(option =>
                    {
                        option.Servers =
                        [
                            new ScalarServer(builder.Configuration["ServerUrl"]),
                            new ScalarServer("https://localhost:7270")
                        ];
                    });
                }catch (Exception ex)
                {
                    Console.WriteLine($"OpenApi/Scalar: {ex.Message}");
                }
            }

            // Redirect to Scalar
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
            app.UseCors("AllowFrontend");
            app.UseAuthentication();
            app.UseAuthorization();
            app.MapControllers();
            app.Run();
        }

    }
}
