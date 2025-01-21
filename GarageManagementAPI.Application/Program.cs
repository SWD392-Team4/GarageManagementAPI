using GarageManagementAPI.Application;
using GarageManagementAPI.Application.Extensions;
using Microsoft.AspNetCore.HttpOverrides;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.ConfigureCors();
builder.Services.ConfigureIISIntegration();
builder.Services.ConfigureRepositoryManager();
builder.Services.ConfigureServiceManager();
builder.Services.ConfigureDataShaperManager();
builder.Services.ConfigureSqlContext(builder.Configuration);
builder.Services.ConfigureApiBehavior();
builder.Services.ConfigureController();
builder.Services.AddAutoMapper(typeof(Program));
builder.Services.AddExceptionHandler<GlobalExceptionHandler>();
builder.Services.ConfigureActionFilter();
builder.Services.ConfigureRateLimitingOptions();
builder.Services.AddAuthentication();
builder.Services.ConfigureIdentity();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseExceptionHandler(opt => { });
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//app.UseHttpsRedirection();
app.UseForwardedHeaders(new ForwardedHeadersOptions
{
    ForwardedHeaders = ForwardedHeaders.All
});
app.UseCors("CorsPolicy");
app.UseRateLimiter();
app.UseResponseCaching();

app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();

app.Run();

