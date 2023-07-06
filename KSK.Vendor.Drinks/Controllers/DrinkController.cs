using KSK.Vendor.Drinks.Infrastructure.Options;
using KSK.Vendor.Drinks.Requests;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;

namespace KSK.Vendor.Drinks.Controllers;

[Route("drinks")]
[AllowAnonymous]
public class DrinkController : Controller
{
    public readonly IMediator _mediator;

    public DrinkController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost("block")]
    public async Task Block([FromBody] BlockDrinksRequest request)
    {
        await _mediator.Send(request);
    }

    [HttpPost("unblock")]
    public async Task UnBlock([FromBody] UnBlockDrinksRequest request)
    {
        await _mediator.Send(request);
    }


    [HttpPost("block/get/ids")]
    public async Task<GetBlockIdsDrinkResponse> Block([FromBody] GetBlockIdsDrinkRequest request)
    {
        return await _mediator.Send(request);
    }

    [HttpPost("push")]
    public async Task Push([FromBody] PushDrinksRequest request)
    { 
        await _mediator.Send(request);
    }

    [HttpPost("set")]
    public async Task Set([FromBody] SetDrinksRequest request)
    {
        await _mediator.Send(request);
    }

    [HttpPost("upload/get/url")]
    public async Task<string> GetUrlUpload([FromQuery] string filename)
    {
        return await _mediator.Send(new GetReadUrlRequest(filename));
    }

    [HttpGet("read/get/url")]
    public async Task<string> GetUrlRead([FromQuery] string filename)
    {
        return await _mediator.Send(new GetReadUrlRequest(filename));
    }

    [HttpGet("test")]
    public string Test()
    {
        return JsonConvert.SerializeObject("test");
    }
}
