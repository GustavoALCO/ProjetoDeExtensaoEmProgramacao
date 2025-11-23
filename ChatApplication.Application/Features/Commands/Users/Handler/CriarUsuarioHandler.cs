using ChatApplication.Application.Interfaces;
using ChatApplication.Dommain.Entities;
using ChatApplication.Dommain.Interfaces.User;
using MediatR;
using Microsoft.Extensions.Logging;

namespace ChatApplication.Application.Features.Commands.Users.Handler;

public class CriarUsuarioHandler : IRequestHandler<CriarUsuario>
{
    private readonly ILogger<CriarUsuarioHandler> _logger;

    private readonly IUserRepositoryCommands _commands;

    private readonly IHashPassword _hashPassword;

    private readonly ISavedImages _savedImages;

    public CriarUsuarioHandler(IUserRepositoryCommands commands, ILogger<CriarUsuarioHandler> logger, IHashPassword hashPassword, ISavedImages savedImages)
    {
        _commands = commands;
        _logger = logger;
        _hashPassword = hashPassword;
        _savedImages = savedImages;
    }

    public async Task Handle(CriarUsuario request, CancellationToken cancellationToken)
    {
        var user = new User
        {
            UserId = Guid.NewGuid(),
            Username = request.Username,
            Password = "",
            Description = request.Description,
            Image = await _savedImages.UploadBase64ImagesAsync(request.Image,  0),
            IsValid = true,
            CreateData = DateTime.UtcNow.AddHours(-3)
        };

        user.Password = _hashPassword.Hash(user, request.Password);

        _logger.LogInformation("Usuário criado com sucesso");

        await _commands.CreateUser(user);
    }
}
