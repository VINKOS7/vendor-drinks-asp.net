using Dotseed.Domain;
using KSK.Vendor.Drinks.Domain.Domain.Aggregates.Drink.Values.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KSK.Vendor.Drinks.Domain.Domain.Aggregates.Drink.Values;

public class Cup : ValueObject
{
    public static Cup From(IAddCupCommand command)
    {
        return new()
        {
            Material = command.Material,
            Size = command.Size,
        };
    }

    public string Material { get; set; }
    public double Size { get; set; }

    protected override IEnumerable<object> GetAtomicValues()
    {
        yield return Material;
        yield return Size;
    }
}
