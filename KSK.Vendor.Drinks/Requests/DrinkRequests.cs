using KSK.Vendor.Drinks.Domain.Domain.Aggregates.Drink;
using KSK.Vendor.Drinks.Domain.Domain.Aggregates.Drink.Commands;
using KSK.Vendor.Drinks.Domain.Domain.Aggregates.Drink.Enums;
using KSK.Vendor.Drinks.Domain.Domain.Aggregates.Drink.Values;
using KSK.Vendor.Drinks.Domain.Domain.Aggregates.Drink.Values.Commands;
using MediatR;
using Newtonsoft.Json;

namespace KSK.Vendor.Drinks.Requests;
public record PushDrinksRequest(
    [JsonProperty("drinks")] IReadOnlyCollection<PushDrinkModelRequest> Drinks)
: IRequest;

public record PushDrinkModelRequest( 
    [JsonProperty("id")] Guid Id,
    [JsonProperty("name")] string Name,
    [JsonProperty("price")] double Price,
    [JsonProperty("image")] string Image,
    [JsonProperty("cup")] CupModelRequest Cup) 
: IAddDrinkCommand
{
    IAddCupCommand IAddDrinkCommand.Cup => Cup;
}

public record SetDrinksRequest(
    [JsonProperty("drinks")] IReadOnlyCollection<PushDrinkModelRequest> Drinks)
: IRequest;

public record SetDrinkModelRequest(
    [JsonProperty("id")] Guid Id,
    [JsonProperty("name")] string Name,
    [JsonProperty("price")] double Price,
    [JsonProperty("image")] string Image,
    [JsonProperty("cup")] CupModelRequest Cup)
: IAddDrinkCommand
{
    IAddCupCommand IAddDrinkCommand.Cup => Cup;
}

public record CupModelRequest(
    [JsonProperty("material")] string Material,
    [JsonProperty("size")] double Size) 
: IAddCupCommand;

public record BlockDrinksRequest([JsonProperty("ids")] IReadOnlyCollection<Guid> Ids) : IRequest;
public record UnBlockDrinksRequest([JsonProperty("ids")] IReadOnlyCollection<Guid> Ids) : IRequest;

public record GetBlockIdsDrinkRequest([JsonProperty("ids")] IReadOnlyCollection<Guid> Ids) 
: IRequest<GetBlockIdsDrinkResponse>;

//GetBlockDrinksResponse