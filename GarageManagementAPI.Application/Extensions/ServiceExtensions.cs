using GarageManagementAPI.Repository;
using GarageManagementAPI.Repository.Contracts;
using GarageManagementAPI.Service;
using GarageManagementAPI.Service.Contracts;
using Microsoft.EntityFrameworkCore;

namespace GarageManagementAPI.Application.Extensions
{
    public static class ServiceExtensions
    {
        public static void ConfigureIISIntegration(this IServiceCollection services) =>
            services.Configure<IISOptions>(options =>
            {

            });

        public static void ConfigureCors(this IServiceCollection services) =>
            services.AddCors(options =>
            {
                options.AddPolicy("CorPolicy", builder =>
                builder.AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader());
            });

        public static void ConfigureRepositoryManager(this IServiceCollection services) =>
            services.AddScoped<IRepositoryManager, RepositoryManager>();

        public static void ConfigureServiceManager(this IServiceCollection services) =>
            services.AddScoped<IServiceManager, ServiceManager>();

        public static void ConfigureSqlContext(this IServiceCollection services, IConfiguration configuration) =>
            services.AddDbContext<RepositoryContext>(opts => opts.UseSqlServer(configuration.GetConnectionString("sqlConnection")));

        public static void ConfigureController(this IServiceCollection services) =>
            services.AddControllers()
            .AddApplicationPart(typeof(GarageManagementAPI.Presentation.AssemblyReference).Assembly);
    }
}
