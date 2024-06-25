using API.Important_Area;
using Application.AutoMapperAll.AutoMapper;
using Domain.Models.ApplicationUser;
using Infra.Context;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Security.Claims;

namespace API
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Configure DbContext
            builder.Services.AddDbContext<DataContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("Context1")));

            // Configure Identity
            builder.Services.AddIdentity<ApplicationUser, IdentityRole<int>>(options => options.SignIn.RequireConfirmedAccount = true)
                .AddEntityFrameworkStores<DataContext>()
                .AddDefaultTokenProviders();

            builder.Services.AddIdentityCore<ApplicationUser>()
            .AddRoles<IdentityRole<int>>()
            .AddEntityFrameworkStores<DataContext>();

            builder.Services.AddControllers();

            // Configure Swagger
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            // Resolve other dependencies
            DependencyInjectionConfig.ResolveDependencies(builder.Services);
            AutoMapperConfig.AddAutoMapperConfiguration(builder.Services);

            var app = builder.Build();

            // Configure HTTP pipeline
            //if (app.Environment.IsDevelopment())
            //{
                app.UseSwagger();
                app.UseSwaggerUI();
            //}

            using (var scope = app.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                await InitializeRolesAsync(services);
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();
            app.UseAuthentication();

            app.MapControllers();

            app.Run();
        }

        private static async Task InitializeRolesAsync(IServiceProvider serviceProvider)
        {
            var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole<int>>>();

            // Verificar se as roles já existem
            if (!await roleManager.RoleExistsAsync("Admin"))
                await roleManager.CreateAsync(new IdentityRole<int>("Admin"));

            if (!await roleManager.RoleExistsAsync("User"))
                await roleManager.CreateAsync(new IdentityRole<int>("User"));

            //var adminRole = await roleManager.FindByNameAsync("Admin");
            //if (adminRole != null)
            //{
            //    await roleManager.AddClaimAsync(adminRole, new Claim("Permission", "View"));
            //    await roleManager.AddClaimAsync(adminRole, new Claim("Permission", "Edit"));
            //    await roleManager.AddClaimAsync(adminRole, new Claim("Permission", "Delete"));
            //}

            //// Adiciona claims ao role "User"
            //var userRole = await roleManager.FindByNameAsync("User");
            //if (userRole != null)
            //{
            //    await roleManager.AddClaimAsync(userRole, new Claim("Permission", "View"));
            //}
            // Adicionar mais roles conforme necessário
        }
    }
}