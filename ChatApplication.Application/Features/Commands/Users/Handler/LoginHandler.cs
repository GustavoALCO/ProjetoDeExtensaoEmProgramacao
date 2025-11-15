using ChatApplication.Aplication.Features.Commands.Users;
using ChatApplication.Dommain.Interfaces.User;
using MediatR;
using Microsoft.Extensions.Logging;

namespace ChatApplication.Application.Features.Commands.Users.Handler;

public class LoginHandler : IRequestHandler<Login, bool>
{
    private readonly ILogger<LoginHandler> _logger;

    private readonly IUserRepositoryQuery _query;

    private readonly IUserRepositoryCommands _command;

    public LoginHandler(IUserRepositoryCommands command, IUserRepositoryQuery query, ILogger<LoginHandler> logger)
    {
        _command = command;
        _query = query;
        _logger = logger;
    }

    Task<bool> IRequestHandler<Login, bool>.Handle(Login request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
