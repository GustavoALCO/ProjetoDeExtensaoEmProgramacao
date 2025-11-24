using ChatApplication.Application.Features.Querys.Users;
using ChatApplication.webApi.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ChatApplication.webApi.Controllers;

public class UserController : ControllerBase
{
    private readonly IMediator _mediator;

    private readonly IHashPassword _hash;

    private readonly IJWTService _jwt;
    public UserController(IMediator mediator, IHashPassword hash, IJWTService jwt)
    {
        _mediator = mediator;
        _hash = hash;
        _jwt = jwt;
    }

    public async Task<string> Login([FromBody]
                                            string username,
                                           [FromBody]
                                            string password)
    {
        var user = await _mediator.Send(new FindUserName() { UserName = username});

        var verify = _hash.Verify(user, user.Password, password);

        if (verify == false)
            throw new Exception("Senha Incorreata");

        var token = _jwt.GenerateToken(user.UserId, user.Username);

        return token;
    }

    public async Task<IActionResult> Get
}
