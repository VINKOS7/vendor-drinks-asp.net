﻿using Microsoft.EntityFrameworkCore;

using MediatR;
using KSK.Vendor.Drinks.Infrastructure;

namespace KSK.Vendor.Drinks.Extensions;

public static class EntityFrameworkCoreExtensions
{
    public static IServiceCollection ConfigureEntityFramework(this IServiceCollection services, IConfiguration configuration)
    {
        string connectionString = configuration.GetConnectionString("Context");
        services
            .AddEntityFrameworkNpgsql()
            .AddDbContext<Context>(
                options => options
                    .UseNpgsql(
                        connectionString,
                        b => b.MigrationsAssembly("KSK.Vendor.Drinks")
                    )
                    .EnableSensitiveDataLogging()
            );

        return services;
    }

    public static void RunMigrations(this WebApplication app, IConfiguration configuration)
    {
        var mediator = app.Services.GetRequiredService<IMediator>();
        string connectionString = configuration.GetConnectionString("Context");

        var options = new DbContextOptionsBuilder<Context>()
            .UseNpgsql(
                connectionString,
                b => b
                    .MigrationsAssembly(typeof(Program).Assembly.FullName)
                    .MigrationsHistoryTable(
                        "__EFMigrationsHistory",
                "public"))
            .Options;

        using var context = new Context(options, mediator);
        context.Database.Migrate();
    }
}
