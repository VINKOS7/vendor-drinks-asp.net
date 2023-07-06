using KSK.Vendor.Drinks.Domain.Domain.Aggregates.Drink;
using KSK.Vendor.Drinks.Domain.Domain.Aggregates.Drink.Enums;
using KSK.Vendor.Drinks.Requests;
using MediatR;

namespace KSK.Vendor.Drinks.Handlers.DrinkHandlers;

public class BlockDrinkRequestHandler : IRequestHandler<BlockDrinksRequest>
{
    private readonly IDrinkRepo _drinkRepo;
    private readonly ILogger<BlockDrinkRequestHandler> _logger;

    public BlockDrinkRequestHandler (IDrinkRepo drinkRepo, ILogger<BlockDrinkRequestHandler> logger)
    {
        _drinkRepo = drinkRepo;
        _logger = logger;
    }

    public async Task Handle(BlockDrinksRequest request, CancellationToken cancellationToken)
    {
        try
        {
            var drinks = request.Ids
                .Select(async id => await _drinkRepo.FindDrinkByIdAsync(id))
                .Select(t => t.Result).ToList();

            if (drinks is null)
            {
                _logger.LogError("Error while  blocked ids drinks. Ids is null");
                throw new Exception("Error while  blocked ids drinks. Ids is null");
            }

            drinks.ForEach(drink => drink.Status = Status.Stopped);

            await _drinkRepo.UnitOfWork.SaveEntitiesAsync(cancellationToken);
        }
        catch (Exception ex)
        {
            foreach (var id in request.Ids)
                _logger.LogError("Error while block drink with id {id}, {@e}", id, ex);          
        }
    }
}
