using Domain;
using Domain.Contracts;
using Domain.Models;
using Domain.Models.Identity;
using MailKit;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Presistence.Identity;
using Presistence.Repository;
using Service;
using ServiceAbstraction;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Presistence
{
    public static class InfrastructureServices
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<CPMSDbContext>(option =>
            {
                option.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
            });
            services.AddDbContext<CPMS_Identity>(option =>
            {
                option.UseSqlServer(configuration.GetConnectionString("IdentityConnection"));
            });
            services.AddSingleton<IConnectionMultiplexer>(sp =>
            ConnectionMultiplexer.Connect(configuration.GetConnectionString("RedisConnection")));

            services.Configure<MailSetting>(configuration.GetSection(nameof(MailSetting)));
            services.AddScoped<IMailService, MailService>();

            services.AddIdentity<AppUsers, IdentityRole>()
    .AddEntityFrameworkStores<CPMS_Identity>()
    .AddDefaultTokenProviders();

            services.AddScoped<IZoneServices, ZoneServices>();
            services.AddScoped<IDbIntilaizer, DbIntilaizer>();

            services.AddScoped<IUnitOfWork, UnitOfWork>();

            services.AddScoped<ICacheRepository, CacheRepository>();

            return services;
        }
    }
}
