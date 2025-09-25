using Microsoft.AspNetCore.Mvc;
using Service;
using ServiceAbstraction;
using Microsoft.OpenApi.Services;
using Shared.ErrorModels;
using Presistence;
using CPMS.MiddleWare;
using Domain;
using Shared;
using Microsoft.AspNetCore.Authentication.JwtBearer;

namespace CPMS.Extantion
{
    public static class Extantion
    { 
        public static IServiceCollection Register (this IServiceCollection services,IConfiguration configuration)
        {
            services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
           services.AddEndpointsApiExplorer();
           services.AddSwaggerGen();
          
           services.AddInfrastructure(configuration);
         
           services.AddScoped<IServiceManager, ServiceManager>();
           services.AddAutoMapper(typeof(MappingAssemblyReference).Assembly);


            services.AddApplicationServices(configuration);

            services.Configure<ApiBehaviorOptions>(options =>

         
            services.AddApplicationServices(configuration);

           services.Configure<ApiBehaviorOptions>(options =>

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
            return services;

            var JwtOptions= configuration.GetSection("JWTOptions").Get<JWTOptions>();
            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
           .AddJwtBearer(JwtBearerDefaults.AuthenticationScheme, options =>
           {
               options.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
               {
                   ValidateIssuer = true,
                   ValidateAudience = true,
                   ValidateLifetime = true,
                   ValidateIssuerSigningKey = true,
                   ValidIssuer = JwtOptions.Issuer,
                   ValidAudience = JwtOptions.Audience,
                   IssuerSigningKey = new Microsoft.IdentityModel.Tokens.SymmetricSecurityKey(
                       System.Text.Encoding.UTF8.GetBytes(JwtOptions.SecreteKey)
                   ),
                   ClockSkew = TimeSpan.Zero
               };
           });

        }

        public static async Task<WebApplication> configurationmiddleware(this WebApplication app) 
        {
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

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseMiddleware<GlobalErrorMiddleWare>();

            app.MapControllers();
            return app;
        }
    }
}
