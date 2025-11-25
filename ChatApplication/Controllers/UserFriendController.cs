using ChatApplication.Application.Features.Commands.UserFriends;
using ChatApplication.Application.Features.Querys.ChatsUser;
using MediatR;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("userfriend/[controller]")]
public class UserFriendController : ControllerBase
{
    private readonly IMediator _mediator;

    public UserFriendController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost("request")]
    public async Task<IActionResult> AddFriend(SolicitacaoDeAmizade addFriendCommand)
    {
        await _mediator.Send(addFriendCommand);
        return Ok();
    }

    [HttpPost("accept")]
    public async Task<IActionResult> AcceptFriendRequest(FriendshipAction acceptFriendCommand)
    {
        await _mediator.Send(acceptFriendCommand);
        return Ok();
    }

    [HttpGet("listfriend")]
    public async Task<IActionResult> ListFriends([FromQuery] BuscarAmigos listUserFriends)
    {
        var friends = await _mediator.Send(listUserFriends);
        return Ok(friends);
    }

    [HttpDelete("remove")]
    public async Task<IActionResult> RemoveFriend(RemoverAmizade removeFriendCommand)
    {
        await _mediator.Send(removeFriendCommand);
        return Ok();
    }

}
