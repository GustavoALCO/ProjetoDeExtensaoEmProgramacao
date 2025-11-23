using ChatApplication.Application.Interfaces;
using ChatApplication.Dommain.Entities;
using ChatApplication.Dommain.Interfaces.Mensage;
using MediatR;

namespace ChatApplication.Application.Features.Commands.Mensage.Handler;

public class SendMensageHandler : IRequestHandler<SendMensage>
{
    private readonly IMensageRepositoryCommands _commands;

    private readonly ISavedImages _savedImages;

    private readonly ISignalRServices _signalRServices;

    public SendMensageHandler(IMensageRepositoryCommands commands, ISavedImages savedImages, ISignalRServices signalRServices)
    {
        _commands = commands;
        _savedImages = savedImages;
        _signalRServices = signalRServices;
    }

    public async Task Handle(SendMensage request, CancellationToken cancellationToken)
    {
        // Cria um Id para a mensagem
        Guid id = Guid.NewGuid();

        // Cria a lista de status da mensagem para cada usuário
        List<MensageStatus> status = new List<MensageStatus>();

        // Salva as imagens e obtém as URLs
        List<string> images = new List<string>();

        if (request.ImageMensage != null)
            images = await _savedImages.UploadListBase64ImagesAsync(request.ImageMensage, 1);

        // Adiciona os usuarios por meio de um loop 
        foreach (var item in request.Users)
        {
            status.Add(new MensageStatus
            {
                MensageID = id,
                RecibeUserId = item,
                IsReceived = false,
                ReaAt = null
            });
        }

        Dommain.Entities.Mensage mensage = new Dommain.Entities.Mensage()
        {
            MensageId = id,
            ChatId = request.ChatId,
            UserId = request.UserId,
            Content = request.Content,
            ImageMensage = images ?? new List<string>(),
            SendMensage = DateTime.UtcNow.AddHours(-3),
            MensageStatus = status
        };

        await _commands.CreateMensageAsync(mensage);

        await _signalRServices.SendMensageToUserAsync(mensage.ChatId, mensage.UserId, mensage.Content, mensage.ImageMensage);
    }
}
