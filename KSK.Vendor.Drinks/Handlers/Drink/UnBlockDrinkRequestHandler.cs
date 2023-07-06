using KSK.Vendor.Drinks.Domain.Domain.Aggregates.Drink;
using KSK.Vendor.Drinks.Domain.Domain.Aggregates.Drink.Enums;
using KSK.Vendor.Drinks.Requests;
using MediatR;

namespace KSK.Vendor.Drinks.Handlers.DrinkHandlers;

public class UnBlockDrinkRequestHandler : IRequestHandler<UnBlockDrinksRequest>
{
    private readonly IDrinkRepo _drinkRepo;
    private readonly ILogger<UnBlockDrinkRequestHandler> _logger;

    public UnBlockDrinkRequestHandler(IDrinkRepo drinkRepo, ILogger<UnBlockDrinkRequestHandler> logger)
    {
        _drinkRepo = drinkRepo;
        _logger = logger;
    }

    public async Task Handle(UnBlockDrinksRequest request, CancellationToken cancellationToken)
    {
        try
        {
            var drinks = request.Ids
                .Select(async id => await _drinkRepo.FindDrinkByIdAsync(id))
                .Select(t => t.Result).ToList();

            drinks.ForEach(drink => drink.Status = Status.Active);

            await _drinkRepo.UnitOfWork.SaveEntitiesAsync(cancellationToken);
        }
        catch (Exception ex)
        {
            foreach (var id in request.Ids)
                _logger.LogError("Error while block drink with id {id}, {@e}", id, ex);          
        }
    }
}
