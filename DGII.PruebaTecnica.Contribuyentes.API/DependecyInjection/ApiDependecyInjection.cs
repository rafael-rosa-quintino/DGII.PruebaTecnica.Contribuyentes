using DGII.PruebaTecnica.Contribuyentes.API.Middlewares;
using DGII.PruebaTecnica.Contribuyentes.Application;
using MediatR;
using NReco.Logging.File;

namespace DGII.PruebaTecnica.Contribuyentes.API.DependecyInjection
{
    public static class ApiDependecyInjection
    {
        public static void UseErrorHandlerMiddleware(this IApplicationBuilder app) 
        {
            app.UseMiddleware<ErrorHandlerMiddleware>();

        }

        public static IServiceCollection AddApiCors(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddCors(options =>
            {
                options.AddPolicy("AllowAll",
                    builder =>
                    {
                        builder.AllowAnyOrigin()
                               .AllowAnyMethod()
                               .AllowAnyHeader();
                    });
            });

            return services;

        }


        public static IServiceCollection AddLogger(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddLogging(loggingBuilder => {
                loggingBuilder.AddFile("logs/DGII-PruebaTecnica-Contribuyentes-{0:yyyy}-{0:MM}-{0:dd}.log", fileLoggerOpts => {
                    fileLoggerOpts.FormatLogFileName = fName => {
                        return String.Format(fName, DateTime.UtcNow);
                    };
                });
            });

            return services;
        }
    }
}
