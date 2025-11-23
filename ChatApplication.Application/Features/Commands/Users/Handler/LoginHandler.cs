using ChatApplication.Aplication.Features.Commands.Users;
using ChatApplication.Application.Interfaces;
using ChatApplication.Dommain.Interfaces.User;
using MediatR;
using Microsoft.Extensions.Logging;

namespace ChatApplication.Application.Features.Commands.Users.Handler;

public class LoginHandler : IRequestHandler<Login, string>
{
    private readonly ILogger<LoginHandler> _logger;

    private readonly IUserRepositoryQuery _query;

    private readonly IUserRepositoryCommands _command;

    private readonly IHashPassword _hashPassword;

    private readonly IJWTService _jwtservice;

    public LoginHandler(IUserRepositoryCommands command, IUserRepositoryQuery query, ILogger<LoginHandler> logger, IHashPassword hashPassword, IJWTService jwtservice)
    {
        _command = command;
        _query = query;
        _logger = logger;
        _hashPassword = hashPassword;
        _jwtservice = jwtservice;
    }

    async Task<string> IRequestHandler<Login, string>.Handle(Login request, CancellationToken cancellationToken)
    {
        var user = await _query.GetUserByUsername(request.UserName);

        var isvalid = _hashPassword.Verify(user, user.Password, request.Password);

        if (isvalid != false)
        {
            var token = _jwtservice.GenerateToken(user.UserId, user.Username);

            return token;
        }

        throw new Exception("Username or password is incorrect");
    }
}
