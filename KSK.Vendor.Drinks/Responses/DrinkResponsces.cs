using KSK.Vendor.Drinks.Domain.Domain.Aggregates.Drink;
using Newtonsoft.Json;

public class GetBlockIdsDrinkResponse
{
    public GetBlockIdsDrinkResponse(IReadOnlyCollection<Drink> drinks)
    {
        Ids = drinks.Select(d => d.Id).ToList();
    }
    
    [JsonProperty("ids")] public IReadOnlyCollection<Guid> Ids { get; init; }
}