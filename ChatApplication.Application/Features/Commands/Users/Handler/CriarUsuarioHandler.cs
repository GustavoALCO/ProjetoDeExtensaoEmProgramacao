using ChatApplication.Dommain.Entities;
using ChatApplication.Dommain.Interfaces.User;
using MediatR;
using Microsoft.Extensions.Logging;

namespace ChatApplication.Application.Features.Commands.Users.Handler;

public class CriarUsuarioHandler : IRequestHandler<CriarUsuario>
{
    private readonly ILogger<CriarUsuarioHandler> _logger;

    private readonly IUserRepositoryCommands _commands;

    public CriarUsuarioHandler(IUserRepositoryCommands commands, ILogger<CriarUsuarioHandler> logger)
    {
        _commands = commands;
        _logger = logger;
    }

    public async Task Handle(CriarUsuario request, CancellationToken cancellationToken)
    {
        var user = new User
        {
            UserId = Guid.NewGuid(),
            Username = request.Username,
            Password = request.Password,
            Description = request.Description,
            Image = request.Image,
            IsValid = true,
            CreateData = DateTime.UtcNow.AddHours(-3)
        };

        _logger.LogInformation("Usuário criado: {@User}", user);

        await _commands.CreateUser(user);
    }
}
