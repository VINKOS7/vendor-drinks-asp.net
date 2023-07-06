using Dotseed.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KSK.Vendor.Drinks.Domain.Domain.Aggregates.Drink;

public interface IDrinkRepo : IRepository<Drink>
{
    Task PushDrinkAsync(Drink drink);

    Task RemoveAllDrinksAsync();

    Task PushDrinksAsync(IReadOnlyCollection<Drink> drinks);

    Task<Drink> FindDrinkByIdAsync(Guid id);
}
