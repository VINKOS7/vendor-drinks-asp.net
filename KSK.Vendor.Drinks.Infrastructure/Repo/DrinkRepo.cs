using Dotseed.Domain;

using KSK.Vendor.Drinks.Domain.Domain.Aggregates.Drink;
using KSK.Vendor.Drinks.Domain.Domain.Aggregates.Drink.Enums;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace KSK.Vendor.Drinks.Infrastructure.Repo;

public class DrinkRepo : IDrinkRepo
{
    private readonly Context _db;

    public DrinkRepo(Context db)
    {
        _db = db;
    }

    public IUnitOfWork UnitOfWork => _db;

    public async Task PushDrinkAsync(Drink drink)
    {     
        await _db.Drinks.AddAsync(drink);
    }

    public async Task PushDrinksAsync(IReadOnlyCollection<Drink> drinks)
    {
        await _db.Drinks.AddRangeAsync(drinks);
    }

    public async Task<Drink> FindDrinkByIdAsync(Guid id)
    {
        return await _db.Drinks.FirstOrDefaultAsync(d => d.Id == id);
    }

    public async Task RemoveAllDrinksAsync()
    {
       foreach(var drink in _db.Drinks) _db.Drinks.Remove(drink);     
    }
}
