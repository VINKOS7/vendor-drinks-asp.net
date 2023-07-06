using KSK.Vendor.Drinks.Domain.Domain.Aggregates.Drink.Enums;
using KSK.Vendor.Drinks.Domain.Domain.Aggregates.Drink.Values.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KSK.Vendor.Drinks.Domain.Domain.Aggregates.Drink.Commands;

public interface IAddDrinkCommand
{
    public Guid Id { get; }
    public string Name { get; }
    public string Image { get; }
    public double Price { get; }
    public IAddCupCommand Cup { get; }
}
