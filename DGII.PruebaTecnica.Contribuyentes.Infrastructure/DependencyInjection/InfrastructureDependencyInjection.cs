using DGII.PruebaTecnica.Contribuyentes.Domain.Aggregates.TaxpayerAggregate;
using DGII.PruebaTecnica.Contribuyentes.Domain.Exceptions;
using DGII.PruebaTecnica.Contribuyentes.Domain.Shared.Repository;
using DGII.PruebaTecnica.Contribuyentes.Infrastructure.EFCore.Context;
using DGII.PruebaTecnica.Contribuyentes.Infrastructure.EFCore.Repositories;
using DGII.PruebaTecnica.Contribuyentes.Infrastructure.EFCore.UniOfWork;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DGII.PruebaTecnica.Contribuyentes.Infrastructure.DependencyInjection
{
    public static class InfrastructureDependencyInjection
    {
        public static IServiceCollection AddInfrastucture(this IServiceCollection services, IConfiguration configuration)
        {
            AddPersitenceEFCore(services, configuration);
            return services;
        }
        private static IServiceCollection AddPersitenceEFCore(this IServiceCollection services, IConfiguration configuration)        
        {
            services.AddDbContext<DGIIDbContext>(options =>
            {
                string connectionString = configuration.GetConnectionString("DGII") 
                ?? throw new AppSettingMissingKeyException("ConnectionString.DGII");
                
                string dataBaseServer = configuration?.GetSection("DataBaseServer").Value
                ?? throw new AppSettingMissingKeyException("DataBaseServer");

                switch (dataBaseServer)
                {
                    case "MSSQL":
                        options.UseSqlServer(connectionString);
                        break;
                    case "MySql":
                        options.UseMySQL(connectionString);
                        break;
                    default:
                        throw new Domain.Exceptions.ArgumentException("DataBaseServer");
                }

            });

            services.AddScoped<IUniOfWork, DGIIUnitOfWork>();
            services.AddScoped<ITaxpayerRepository, TaxpayerRepository>();

            return services;
        }

        private static IServiceCollection AddPersitenceDataDummy(this IServiceCollection services, IConfiguration configuration)
        {
            return services;
        }

    }
}
