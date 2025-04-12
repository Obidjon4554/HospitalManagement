using HospitalManagement.Extensions;
using HospitalManagement.Middlewares;
using HospitalManagement.Repository.Interfaces;
using HospitalManagement.Repository;
using Sats.PostgreSqlDistributedCache;
using HospitalManagement.Services.Doctors;
using HospitalManagement.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services
    .AddEndpointsApiExplorer()
    .AddSwaggerGen();

var configuration = builder.Configuration;

builder.Services.AddScoped<IDoctorRepository, DoctorRepository>();
builder.Services.AddScoped<IPatientRepository, PatientRepository>();


builder.Services.AddScoped<IDoctorService, DoctorService>();
builder.Services.AddScoped<IPatientService, PatientService>();


builder.Services
    .AddDependencies()
    .AddDbContext(configuration)
    .AddConfigurations(configuration)
    .AddMonitoring(configuration);

builder.Services.AddMemoryCache();

builder.Services.AddPostgresDistributedCache(options =>
{
    options.ConnectionString = builder.Configuration.GetConnectionString("DefaultConnection");
});

builder.Services.AddStackExchangeRedisCache(options =>
{
    options.Configuration = "localhost";
    options.InstanceName = "local";
});

builder.Services.AddHttpClient();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(); 
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseMiddleware<CorrelationIdLoggingMiddleware>();
app.UseMiddleware<GlobalLoggingMiddleware>();
app.UseMiddleware<ConfigurationValidationMiddleware>();

app.MapControllers();

app.Run();
