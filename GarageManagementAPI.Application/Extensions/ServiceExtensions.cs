using FluentValidation;
using GarageManagementAPI.Application.Security;
using GarageManagementAPI.Entities.ConfigurationModels;
using GarageManagementAPI.Entities.Models;
using GarageManagementAPI.Presentation.ActionFilters;
using GarageManagementAPI.Presentation.Validator;
using GarageManagementAPI.Repository;
using GarageManagementAPI.Repository.Contracts;
using GarageManagementAPI.Service;
using GarageManagementAPI.Service.Contracts;
using GarageManagementAPI.Service.DataShaping;
using GarageManagementAPI.Shared.Constant.Request;
using GarageManagementAPI.Shared.DataTransferObjects.Workplace;
using GarageManagementAPI.Shared.ResultModel;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Net;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.RateLimiting;

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
                config.CacheProfiles.Add("120SecondsDuration", new CacheProfile
                {
                    Duration = 120
                });
            })
            .AddJsonOptions(options =>
            {
                options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
                options.JsonSerializerOptions.DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull;
            })
            .AddApplicationPart(typeof(GarageManagementAPI.Presentation.AssemblyReference).Assembly);


        public static void ConfigureActionFilter(this IServiceCollection services)
        {
            services.AddScoped<ValidationFilterAttribute>();
        }

        public static void ConfigureResponseCaching(this IServiceCollection services) =>
            services.AddResponseCaching();

        public static void ConfigureRateLimitingOptions(this IServiceCollection services)
        {
            services.AddRateLimiter(options =>
            {
                options.GlobalLimiter = PartitionedRateLimiter.Create<HttpContext, string>(context => RateLimitPartition.GetFixedWindowLimiter("GloabalLimiter", partition =>
                new FixedWindowRateLimiterOptions
                {
                    AutoReplenishment = true,
                    PermitLimit = 1000,
                    QueueLimit = 50,
                    QueueProcessingOrder = QueueProcessingOrder.OldestFirst,
                    Window = TimeSpan.FromMinutes(1)
                }));
                options.AddPolicy("SendMailConfirmEmailPolicy", context =>
                 RateLimitPartition.GetFixedWindowLimiter("SendMailPolicyLimiter",
                 partition => new FixedWindowRateLimiterOptions
                 {
                     AutoReplenishment = true,
                     PermitLimit = 1,
                     Window = TimeSpan.FromMinutes(5)
                 }));
                options.AddPolicy("SendMailForgotPasswordPolicy", context =>
                 RateLimitPartition.GetFixedWindowLimiter("SendMailPolicyLimiter",
                 partition => new FixedWindowRateLimiterOptions
                 {
                     AutoReplenishment = true,
                     PermitLimit = 1,
                     Window = TimeSpan.FromMinutes(5)
                 }));

                options.OnRejected = async (context, token) =>
                {
                    context.HttpContext.Response.ContentType = "application/json";
                    context.HttpContext.Response.StatusCode = StatusCodes.Status429TooManyRequests;

                    if (context.Lease.TryGetMetadata(MetadataName.RetryAfter, out var retryAfter))
                    {
                        var response = Result.Failure(HttpStatusCode.TooManyRequests,
                            [RequestErrors.GetTooManyRequestsWithRetryAfterError(retryAfter.TotalSeconds)]).ToString();

                        await context.HttpContext.Response.WriteAsync(response, token);
                    }

                    else
                    {
                        var response = Result.Failure(HttpStatusCode.TooManyRequests,
                            [RequestErrors.GetTooManyRequestsError()]).ToString();

                        await context.HttpContext.Response.WriteAsync(response, token);
                    }
                };
            });
        }

        public static void ConfigureIdentity(this IServiceCollection services)
        {
            var builder = services.AddIdentity<User, Roles>(options =>
            {
                options.Password.RequireDigit = true;
                options.Password.RequireLowercase = true;
                options.Password.RequireUppercase = true;
                options.Password.RequireNonAlphanumeric = true;
                options.Password.RequiredLength = 10;
                options.Password.RequiredUniqueChars = 1;

                options.User.RequireUniqueEmail = true;
                options.User.AllowedUserNameCharacters = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";

                options.ClaimsIdentity.UserNameClaimType = "UserName";
                options.ClaimsIdentity.RoleClaimType = "Role";

                options.SignIn.RequireConfirmedEmail = true;

                options.Tokens.EmailConfirmationTokenProvider = "CustomEmailConfirmation";

            }).AddEntityFrameworkStores<RepositoryContext>()
            .AddDefaultTokenProviders()
            .AddTokenProvider<CustomEmailConfirmationTokenProvider<User>>("CustomEmailConfirmation");

            services.Configure<DataProtectionTokenProviderOptions>(o =>
            {
                o.TokenLifespan = TimeSpan.FromHours(5);
            });

            services.Configure<CustomEmailConfirmationTokenProviderOptions>(o =>
            {
                o.TokenLifespan = TimeSpan.FromDays(3);
            });


        }

        public static void ConfigureJWT(this IServiceCollection services, IConfiguration configuration)
        {
            var jwtConfiguration = new JwtConfiguration();
            configuration.Bind(jwtConfiguration.Section, jwtConfiguration);

            var secretKey = Environment.GetEnvironmentVariable("SECRET");

            services.AddAuthentication(opt =>
            {
                opt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                opt.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(opt =>
            {
                opt.TokenValidationParameters = new TokenValidationParameters()
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = jwtConfiguration.ValidIssuer,
                    ValidAudience = jwtConfiguration.ValidAudience,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey!)),
                    NameClaimType = "UserName",
                    RoleClaimType = "Role",
                };
            });
        }

        public static void AddJwtConfiguration(this IServiceCollection services, IConfiguration configuration) =>
            services.Configure<JwtConfiguration>(configuration.GetSection("JwtSettings"));

        public static void AddMailConfiguration(this IServiceCollection services, IConfiguration configuration) =>
            services.Configure<MailConfiguration>(configuration.GetSection("MailSettings"));

        public static void ConfigureSwagger(this IServiceCollection services)
        {
            services.AddSwaggerGen(s =>
            {
                s.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    In = ParameterLocation.Header,
                    Description = "Place to add JWT with Bearer",
                    Name = "Authorization",
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer"
                });
                var xmlFile = $"{typeof(Presentation.AssemblyReference).Assembly.GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                s.IncludeXmlComments(xmlPath);
                s.AddSecurityRequirement(new OpenApiSecurityRequirement()
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            },
                            Name = "Bearer"
                        },
                        new List<string>()
                    }
                });
            });
        }

        public static void ConfigureValidator(this IServiceCollection services)
            => services.AddValidatorsFromAssembly(typeof(GarageManagementAPI.Presentation.AssemblyReference).Assembly, includeInternalTypes: true);


    }
}
