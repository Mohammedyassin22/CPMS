using CPMS.Extantion;
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

            builder.Services.Register(builder.Configuration);


            var app = builder.Build();

           await app.configurationmiddleware();

            app.Run();
        }
    }      
}
