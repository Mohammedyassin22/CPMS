using CPMS.MiddleWare;
using Domain;
using Domain.Contracts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Presistence;
using Service;
using ServiceAbstraction;
using Shared.ErrorModels;
using System.Reflection;

namespace CPMS
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddDbContext<CPMSDbContext>(option =>
            {
                option.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
            });

            builder.Services.AddScoped<IDbIntilaizer, DbIntilaizer>();

            builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
            builder.Services.AddScoped<IServiceManager, ServiceManager>();
            builder.Services.AddAutoMapper(typeof(MappingAssemblyReference).Assembly);

            builder.Services.Configure<ApiBehaviorOptions>(options =>
            {
                options.InvalidModelStateResponseFactory = context =>
                {
                    var errors = context.ModelState
                        .Where(x => x.Value.Errors.Any())
                        .Select(x => new ValidationError
                        {
                            field = x.Key,
                            errors = x.Value.Errors.Select(e => e.ErrorMessage)
                        }).ToList();

                    var response = new ValidationErrorResponse
                    {
                        Errors = errors
                    };

                    return new BadRequestObjectResult(response);
                };
            });


            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }
            using var scope = app.Services.CreateScope();
            var dbintilaizer = scope.ServiceProvider.GetService<IDbIntilaizer>();
            await dbintilaizer.IntilaizerAsync();

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.UseMiddleware<GlobalErrorMiddleWare>();

            app.MapControllers();

            app.Run();
        }
    }      
}
