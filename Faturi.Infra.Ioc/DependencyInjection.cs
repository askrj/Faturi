using Faturi.Application.Interfaces;
using Faturi.Application.Mappings;
using Faturi.Application.Services;
using Faturi.Domain.Interface;
using Faturi.Infra.Data.Context;
using Faturi.Infra.Data.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Faturi.Infra.Ioc
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services,
            IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
             options.UseSqlServer(configuration.GetConnectionString("ClinicaContext"
            ), b => b.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName)));

            services.AddScoped<IConvenioRepository, ConvenioRepository>();
            services.AddScoped<IBeneficiarioRepository, BeneficiarioRepository>();

            services.AddScoped<IBeneficiarioService, BeneficiarioService>();
            services.AddScoped<IConvevioService, ConvenioService>();
            services.AddAutoMapper(typeof(DomainToDTOMappingProfile));

            var myhandlers = AppDomain.CurrentDomain.Load("Faturi.Application");
            services.AddMediatR(myhandlers);

            return services;
        }
    }
}
