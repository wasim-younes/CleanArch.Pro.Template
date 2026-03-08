
using CleanArch.Application;
using CleanArch.Infrastructure;
using CleanArch.Infrastructure.Persistence;
using CleanArch.Infrastructure.Persistence.Contexts;
using CleanArch.WebAPI.Middleware;
using Microsoft.OpenApi;

namespace CleanArch.WebAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // --- PART 1: REGISTER SWAGGER ---
            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer(); // Required for Swagger to find your Controllers
            builder.Services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "Clean Architecture Dictionary API",
                    Version = "v1"
                });
            });

            // Add your other layers
            builder.Services.AddApplication();
            builder.Services.AddInfrastructure(builder.Configuration);
            builder.Services.AddCors(options =>
            {
                options.AddPolicy("AllowAll", policy =>
                {
                    policy.AllowAnyOrigin()
                          .AllowAnyMethod()
                          .AllowAnyHeader();
                });
            });

            var app = builder.Build();
            app.UseMiddleware<ExceptionMiddleware>();

            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger(); // Generates the JSON file
                app.UseSwaggerUI(c =>
                {
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "CleanArch API V1");
                    c.RoutePrefix = string.Empty; // This makes Swagger open at the root (http://localhost:xxxx/)
                });
            }

            app.UseHttpsRedirection();

            //app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
