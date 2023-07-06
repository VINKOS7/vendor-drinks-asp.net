using Microsoft.EntityFrameworkCore;

using MediatR;
using Dotseed.Context;
using Dotseed.IntegrationEventLog;

using KSK.Vendor.Drinks.Domain.Domain.Aggregates.Drink;
using KSK.Vendor.Drinks.Infrastructure.EntityConfiguration;

namespace KSK.Vendor.Drinks.Infrastructure;

public class Context : UnitOfWorkContext
{
    private readonly IIntegrationEventLogService _integrationEventLogService;

    public DbSet<Drink> Drinks { get; set; }


    public Context(
        DbContextOptions options,
        IMediator mediator) : base(options, mediator)
    { }

    public Context(
        IIntegrationEventLogService integrationEventLogService,
        DbContextOptions options,
        IMediator mediator) : base(options, mediator)
    {
        _integrationEventLogService = integrationEventLogService;
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfiguration(new DrinkEntityConfiguration());
    }

    public override async Task<bool> SaveEntitiesAsync(CancellationToken cancellationToken = new CancellationToken())
    {
        await base.SaveEntitiesAsync(cancellationToken);

       // await _integrationEventLogService.PublishStoredIntegrationEventsAsync();

        return true;
    }
}
