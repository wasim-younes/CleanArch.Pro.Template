using CleanArch.Application.Common.Interfaces;
using CleanArch.Infrastructure.Persistence;
using CleanArch.Infrastructure.Persistence.Contexts;
using CleanArch.Infrastructure.Persistence.Repositories;
using CleanArch.Infrastructure.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
namespace CleanArch.Infrastructure

{
    public static class DependencyInjection
    {
        // The "this" keyword here is the magic. It adds a new button to 'services'
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            // 1. Tell the app how to connect to the DB
            services.AddDbContext<ApplicationDbContext>(options =>
              options.UseInMemoryDatabase("CleanArchDb"));

            // 2. Tell the app: "When someone asks for IMemberRepository, give them MemberRepository"
            services.AddScoped<IMemberRepository, MemberRepository>();
            services.AddScoped<IEmailService, EmailService>();

            return services;
        }
    }
}
