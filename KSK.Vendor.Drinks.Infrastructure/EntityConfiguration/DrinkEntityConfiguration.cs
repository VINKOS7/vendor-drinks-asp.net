using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using KSK.Vendor.Drinks.Domain.Domain.Aggregates.Drink;

namespace KSK.Vendor.Drinks.Infrastructure.EntityConfiguration;

public class DrinkEntityConfiguration : IEntityTypeConfiguration<Drink>
{
    public void Configure(EntityTypeBuilder<Drink> builder)
    {
        builder.OwnsOne(d => d.Cup);
    }
}
