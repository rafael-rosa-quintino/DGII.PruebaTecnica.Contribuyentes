using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace DGII.PruebaTecnica.Contribuyentes.Application
{
    public static class ApplicationDependecyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddMediatR(typeof(ApplicationDependecyInjection).Assembly);

            return services;
        }
    }
}
