using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KSK.Vendor.Drinks.Domain.Domain.Aggregates.Drink.Values.Commands;

public interface IAddCupCommand
{
    public string Material { get; }
    public double Size { get; }
}
