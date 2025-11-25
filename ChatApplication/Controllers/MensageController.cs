using ChatApplication.Application.Features.Commands.Mensage;
using ChatApplication.Application.Features.Querys.Mensage;
using ChatApplication.webApi.Service;
using MediatR;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("mensage/[controller]")]
public class MensageController : ControllerBase
{
    private readonly IMediator _mediator;
    private readonly SignalRServices _signalRServices;

    public MensageController(IMediator mediator, SignalRServices signalRServices)
    {
        _mediator = mediator;
        _signalRServices = signalRServices;
    }

    [HttpPost("send")]
    public async Task<IActionResult> SendMessage(SendMensage sendMensage)
    {
        var images = await _mediator.Send(sendMensage);
        await _signalRServices.SendMessageToUserAsync(sendMensage.ChatId, sendMensage.UserId, sendMensage.Content, images);
        return Ok();
    }

    [HttpGet("findmensageinfo")]
    public async Task<IActionResult> FindMensageInfo([FromQuery] BuscarMensagemInfo findMensageInfo)
    {
        var result = await _mediator.Send(findMensageInfo);
        return Ok(result);
    }

    [HttpGet("mensage")]
    public async Task<IActionResult> GetMensages([FromQuery] BuscarMensagens getMensages)
    {
        var result = await _mediator.Send(getMensages);
        return Ok(result);
    }

    [HttpGet("loadmensage")]
    public async Task<IActionResult> LoadMensage([FromQuery] CarregarMensagens loadMensage)
    {
        var result = await _mediator.Send(loadMensage);
        return Ok(result);
    }
}
