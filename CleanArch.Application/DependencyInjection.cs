using CleanArch.Application.Features.Members;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace CleanArch.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            // This registers all the "Brain" logic of your app
            services.AddScoped<IMemberService, MemberService>();

            return services;
        }
    }
}
