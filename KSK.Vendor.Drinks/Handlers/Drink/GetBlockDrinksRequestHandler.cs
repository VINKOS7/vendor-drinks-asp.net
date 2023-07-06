using KSK.Vendor.Drinks.Domain.Domain.Aggregates.Drink;
using KSK.Vendor.Drinks.Domain.Domain.Aggregates.Drink.Enums;
using KSK.Vendor.Drinks.Requests;
using MediatR;

namespace KSK.Vendor.Drinks.Handlers.DrinkHandlers;

public class GetBlockDrinksRequestHandler : IRequestHandler<GetBlockIdsDrinkRequest, GetBlockIdsDrinkResponse>
{
    private readonly IDrinkRepo _drinkRepo;
    private readonly ILogger<BlockDrinkRequestHandler> _logger;

    public GetBlockDrinksRequestHandler(IDrinkRepo drinkRepo, ILogger<BlockDrinkRequestHandler> logger)
    {
        _drinkRepo = drinkRepo;
        _logger = logger;
    }

    public async Task<GetBlockIdsDrinkResponse> Handle(GetBlockIdsDrinkRequest request, CancellationToken cancellationToken)
    {
        try
        {
            if (request is null)
            {
                _logger.LogError("Error while  blocked ids drinks. Ids is null");
                throw new Exception("Error while  blocked ids drinks. Ids is null");
            }
            else if (request.Ids is null || request.Ids.Count == 0)
            {
                _logger.LogError("Error while  blocked ids drinks. Ids is null");
                throw new Exception("Error while  blocked ids drinks. Ids is null");
            }

            List<Drink> drinks = new();

            foreach (var id in request.Ids)
            {
                var drink = await _drinkRepo.FindDrinkByIdAsync(id);

                if (drink is null)
                {
                    _logger.LogError("Error while  blocked ids drinks. Ids is null");
                    throw new Exception("Error while  blocked ids drinks. Ids is null");
                }

                if (drink.Status == Status.Stopped) drinks.Add(await _drinkRepo.FindDrinkByIdAsync(id));
            }

            return new GetBlockIdsDrinkResponse(drinks);
        }
        catch (Exception ex)
        {
            foreach (var id in request.Ids)
                _logger.LogError("Error while get blocked ids drinks with id {id}, {@e}", id, ex);
            throw;
        }
    }
}
