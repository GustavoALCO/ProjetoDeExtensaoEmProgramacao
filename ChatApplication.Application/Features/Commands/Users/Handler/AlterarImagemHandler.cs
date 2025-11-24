using ChatApplication.Application.Interfaces;
using ChatApplication.Dommain.Interfaces.User;
using MediatR;

namespace ChatApplication.Application.Features.Commands.Users.Handler;

public class AlterarImagemHandler : IRequestHandler<AlterarImagem>
{
    private readonly IUserRepositoryCommands _commands;

    private readonly IUserRepositoryQuery _query;

    private readonly ISavedImages _Image;

    public AlterarImagemHandler(IUserRepositoryCommands commands, IUserRepositoryQuery query, ISavedImages image)
    {
        _commands = commands;
        _query = query;
        _Image = image;
    }

    public async Task Handle(AlterarImagem request, CancellationToken cancellationToken)
    {
        var user = await _query.GetUserById(request.IdUser) ?? throw new Exception("Usuário não encontrado");

        if(user.Image != null)
            await _Image.DeleteImagesAsync(user.Image, 0);

        var imagePath = await _Image.UploadBase64ImagesAsync(request.Base64Image, 0);

        user.Image = imagePath;

        await _commands.UpdateUser(user);
    }
}
