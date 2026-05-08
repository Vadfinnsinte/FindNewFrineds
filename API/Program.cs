
using API.Authentication;
using API.Middleware;
using Application;
using Application.Interfaces;
using Domain.Interfaces;
using Infrastructure.Database;
using Infrastructure.Repositories.Authorization;
using Infrastructure.Repositories.Roles;
using Infrastructure.Repositories.Users;
using Microsoft.EntityFrameworkCore;
using System.Text;

namespace API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddDbContext<AppDbContext>(options =>
            options.UseSqlServer(
            builder.Configuration.GetConnectionString("DefaultConnection")));

            builder.Services.AddControllers();
            // Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
            builder.Services.AddOpenApi();
            builder.Services.AddApplication();
            //builder.Services.AddMediatR(cfg =>
            // cfg.RegisterServicesFromAssembly(typeof(DependencyInjection).Assembly));

            builder.Services.AddScoped<IUserRepository, UserRepository>();
            builder.Services.AddScoped<IPasswordHasher, PasswordHasher>();
            builder.Services.AddScoped<IJwtTokenGenerator, JwtTokenService>();
            builder.Services.AddScoped<IRoleRepository, RoleRepository>();

            var key = Encoding.UTF8.GetBytes(builder.Configuration["JWT:Key"]!);

            builder.Services.AddMyCustomAuthentication(key);

            var app = builder.Build();

            // Configure the HTTP request pipeline.

            if (app.Environment.IsDevelopment())
            {
                app.MapOpenApi();

                app.UseSwaggerUI(options =>
                {
                    options.SwaggerEndpoint("/openapi/v1.json", "My API v1");
                    options.RoutePrefix = "swagger";
                });
            }
    
            app.UseHttpsRedirection();

            app.UseAuthentication();
            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}
