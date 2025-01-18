using GarageManagementAPI.Presentation.ActionFilters;
using GarageManagementAPI.Repository;
using GarageManagementAPI.Repository.Contracts;
using GarageManagementAPI.Service;
using GarageManagementAPI.Service.Contracts;
using GarageManagementAPI.Service.DataShaping;
using GarageManagementAPI.Shared.ErrorModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System.Text.Json.Serialization;

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
                options.AddPolicy("CorsPolicy", builder =>
                builder.AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader()
                .WithExposedHeaders("X-Pagination"));
            });

        public static void ConfigureRepositoryManager(this IServiceCollection services) =>
            services.AddScoped<IRepositoryManager, RepositoryManager>();

        public static void ConfigureServiceManager(this IServiceCollection services) =>
            services.AddScoped<IServiceManager, ServiceManager>();

        public static void ConfigureDataShaperManager(this IServiceCollection services) =>
            services.AddScoped<IDataShaperManager, DataShaperManager>();

        public static void ConfigureSqlContext(this IServiceCollection services, IConfiguration configuration) =>
            services.AddDbContext<RepositoryContext>(opts => opts.UseSqlServer(configuration.GetConnectionString("sqlConnection")));

        public static void ConfigureApiBehavior(this IServiceCollection services) =>
            services.Configure<ApiBehaviorOptions>(options =>
            {
                options.SuppressModelStateInvalidFilter = true;
            });

        public static void ConfigureController(this IServiceCollection services) =>
            services.AddControllers(config =>
            {
                config.RespectBrowserAcceptHeader = true;
                config.ReturnHttpNotAcceptable = true;
                config.InputFormatters.Insert(0, new ServiceCollection()
                    .AddLogging()
                    .AddMvc()
                    .AddNewtonsoftJson()
                    .Services
                    .BuildServiceProvider()
                    .GetRequiredService<IOptions<MvcOptions>>().Value.InputFormatters
                    .OfType<NewtonsoftJsonPatchInputFormatter>().First());
                config.Filters.Add(new ValidationFilterAttribute());
            })
            .AddJsonOptions(options =>
            {
                options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
                options.JsonSerializerOptions.DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull;
                options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;

            })
            .AddApplicationPart(typeof(GarageManagementAPI.Presentation.AssemblyReference).Assembly);


        public static void ConfigureActionFilter(this IServiceCollection services)
        {
            //services.AddScoped<ValidationFilterAttribute>();
        }

    }
}
