using KSK.Vendor.Drinks.Domain.Domain.Aggregates.Drink;
using KSK.Vendor.Drinks.Requests;
using MediatR;

namespace KSK.Vendor.Drinks.Handlers.DrinkHandlers;

public class SetDrinksRequestHandler : IRequestHandler<SetDrinksRequest>
{
    private readonly IDrinkRepo _drinkRepo;
    private readonly ILogger<PushDrinksRequestHandler> _logger;

    public SetDrinksRequestHandler(IDrinkRepo drinkRepo, ILogger<PushDrinksRequestHandler> logger)
    {
        _drinkRepo = drinkRepo;
        _logger = logger;
    }

    public async Task Handle(SetDrinksRequest request, CancellationToken cancellationToken)
    {
        try
        {
            await _drinkRepo.RemoveAllDrinksAsync();

            await _drinkRepo.PushDrinksAsync(request.Drinks.Select(d => Drink.From(d)).ToList());

            await _drinkRepo.UnitOfWork.SaveEntitiesAsync(cancellationToken);
        }
        catch(Exception ex)
        {
            foreach(var drink in request.Drinks)
                _logger.LogError("Error while add drink with id {id}, {@e}", drink.Id, ex);
        }
    }
}
