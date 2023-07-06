using Dotseed.Domain;

using KSK.Vendor.Drinks.Domain.Domain.Aggregates.Drink.Commands;
using KSK.Vendor.Drinks.Domain.Domain.Aggregates.Drink.Enums;
using KSK.Vendor.Drinks.Domain.Domain.Aggregates.Drink.Values;

namespace KSK.Vendor.Drinks.Domain.Domain.Aggregates.Drink;

public class Drink : Entity, IAggregateRoot
{
    public static Drink From(IAddDrinkCommand command)
    {
        return new()
        { 
            Id = command.Id,
            Name = command.Name,
            Price = command.Price,
            Image = command.Image,
            Status = Status.Active,
            Cup = Cup.From(command.Cup)
        };
    }

    public string Name { get; set; }

    public double Price { get; set; }

    public string Image { get; set; }

    public Status Status { get; set; }

    public Cup Cup { get; set; }
}
