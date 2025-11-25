using ChatApplication.Aplication.Features.Querys.Chats;
using ChatApplication.Application.Features.Commands.Chat;
using MediatR;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("chat/[controller]")]
public class ChatController : ControllerBase
{
    private readonly IMediator _mediator;

    public ChatController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost("create")]
    public async Task<IActionResult> CreateChat(CreateChat command)
    {
        await _mediator.Send(command);
        return Ok();
    }

    [HttpGet("findall")]
    public async Task<IActionResult> GetChats([FromQuery]FindAllChats findAllChats)
    {
        var result = await _mediator.Send(findAllChats);
        return Ok(result);
    }

    [HttpGet("findbyid/{id}")]
    public async Task<IActionResult> GetChatById([FromQuery] FindChatID query)
    {

        var result = await _mediator.Send(query);
        return Ok(result);
    }

    [HttpGet("findname")]
    public async Task<IActionResult> GetChatsByUserId([FromQuery] FindNameChats query)
    {
        var result = await _mediator.Send(query);
        return Ok(result);
    }
}
