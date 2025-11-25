using ChatApplication.Application.Interfaces;
using ChatApplication.Dommain.Entities;
using ChatApplication.Infra.Repository.Chat;
using MediatR;

namespace ChatApplication.Application.Features.Commands.Chat.Handler;

public class CreateChatHandler : IRequestHandler<CreateChat>
{
    private readonly IChatRepositoryCommands _command;

    private readonly ISavedImages _savedImages;

    public CreateChatHandler(IChatRepositoryCommands command, ISavedImages savedImages)
    {
        _command = command;
        _savedImages = savedImages;
    }

    public async Task Handle(CreateChat request, CancellationToken cancellationToken)
    {

        // Adiciona um Id para o chat
        Guid chatId = Guid.NewGuid();

        // Criar Variavel para armazenar os usuarios do chat
        List<ChatUsers> chat = new List<ChatUsers>();

        string imagePath = "";

        if(request.Image != null)
            imagePath = await _savedImages.UploadBase64ImagesAsync(request.Image, "chats");

        // Adiciona os usuarios ao chat
        foreach (var userId in request.UsersIds)
        {
            chat.Add(new ChatUsers
            {
                ChatId = chatId,
                UserId = userId,
            });
        }

        // Cria o novo chat
        var newChat = new Dommain.Entities.Chat
        {
            ChatId = chatId,
            Name = request.Name ?? "Novo Chat",
            Description = request.Description ?? "",
            Image = imagePath,
            IsGroup = request.IsGroup,
            ChatUsers = chat,
        };

        await _command.CreateChatAsync(newChat);

    }
}
