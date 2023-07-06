using KSK.Vendor.Drinks.Extensions;
using KSK.Vendor.Drinks.Infrastructure.Options;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
//SecretKey
builder.Services.Configure<SecretKey>
    (builder.Configuration.GetSection("SecretKey"));

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll",
        builder =>
        {
            builder.SetIsOriginAllowedToAllowWildcardSubdomains();
            builder.AllowAnyHeader();
            builder.AllowAnyMethod();
            builder.WithOrigins(
                "http://localhost:3000",
                "https://localhost:3000",
                "http://localhost:3103",
                "http://localhost:3900",
                "http://192.168.1.207:3000",
                "https://192.168.1.207:3000",
                "http://178.155.72.53:3000",
                "https://178.155.72.53:3000",
                "https://crm.hr.vision",
                "chrome-extension://*");
        });
});
builder.Services.ConfigureEntityFramework(builder.Configuration);

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen();

builder.Services.ConfigureApplicationServices(builder.Configuration);

builder.Services.ConfigureInfrastructureServices();

builder.Services.AddMediatR(cfg =>
    cfg.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly()));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseCors("AllowAll");

app.MapControllers();

app.RunMigrations(builder.Configuration);

app.Run();
