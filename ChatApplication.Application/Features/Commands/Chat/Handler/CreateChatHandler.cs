using ChatApplication.Dommain.Entities;
using ChatApplication.Infra.Repository.Chat;
using MediatR;

namespace ChatApplication.Application.Features.Commands.Chat.Handler;

public class CreateChatHandler : IRequestHandler<CreateChat>
{
    private readonly IChatRepositoryCommands _command;

    public CreateChatHandler(IChatRepositoryCommands command)
    {
        _command = command;
    }

    public async Task Handle(CreateChat request, CancellationToken cancellationToken)
    {
        // Adiciona um Id para o chat
        Guid chatId = Guid.NewGuid();

        // Criar Variavel para armazenar os usuarios do chat
        List<ChatUsers> chat = new List<ChatUsers>();

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
            Name = request.Name,
            Description = request.Description,
            Image = request.Image,
            IsGroup = request.IsGroup,
            ChatUsers = chat,
        };

        await _command.CreateChatAsync(newChat);

    }
}
