using Azure.Core;
using ChatApplication.Aplication.Features.Querys.Users;
using ChatApplication.Application.Features.Commands.Users;
using ChatApplication.Application.Features.Querys.Users;
using ChatApplication.Dommain.Entities;
using ChatApplication.webApi.Dtos;
using ChatApplication.webApi.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using static System.Net.Mime.MediaTypeNames;

namespace ChatApplication.webApi.Controllers;

[ApiController]
[Route("user/[controller]")]
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

    [HttpPost]
    public async Task<IActionResult> CreateUser([FromBody] CreateUserDTO createUser)
    {
        var user = new User
        {
            UserId = Guid.NewGuid(),
            Username = createUser.Username,
            Password = createUser.Password,
            Description = createUser.Description,
            Image = createUser.Image,
            IsValid = true,
            CreateData = DateTime.UtcNow.AddHours(-3)
        };

        user.Password = _hash.Hash(user, createUser.Password);

        await _mediator.Send(new CriarUsuario { User = user});

        return Ok();
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login([FromQuery]string username, [FromBody] string password)
    {
        var user = await _mediator.Send(new FindUserName { UserName =  username});

        var verify = _hash.Verify(user, user.Password, password);

        if (!verify)
            throw new Exception("Senha Incorreta");

        var token = _jwt.GenerateToken(user.UserId, user.Username);

        return Ok(token);
    }

    [HttpPut("image")]
    public async Task<IActionResult> UpdateImage([FromBody] AlterarImagem alterarImagem)
    {
        await _mediator.Send(alterarImagem);
        return Ok();
    }

    [HttpGet("Findusername")]
    public async Task<IActionResult> FindByUsername([FromQuery] string username)
    {
        var user = await _mediator.Send(new FindUserName { UserName = username });
        return Ok(user);
    }

    [HttpGet("finduser")]
    public async Task<IActionResult> FindById([FromQuery] FindUsers users)
    {
        var user = await _mediator.Send(users);
        return Ok(user);
    }
}
