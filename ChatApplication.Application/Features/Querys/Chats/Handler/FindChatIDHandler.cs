using ChatApplication.Application.DTOs;
using ChatApplication.Dommain.Interfaces.Chat;
using MediatR;

namespace ChatApplication.Aplication.Features.Querys.Chats.Handler;

public class FindChatIDHandler : IRequestHandler<FindChatID, ChatDTO>
{
    private readonly IChatRepositoryQuery _context;

    public FindChatIDHandler(IChatRepositoryQuery context)
    {
        _context = context;
    }

    public async Task<ChatDTO> Handle(FindChatID request, CancellationToken cancellationToken)
    {
        var chats = await _context.GetChatId(request.IdChat, request.TakeMensages);

        ChatDTO chat = new ChatDTO()
        {
            ChatId = chats.ChatId,
            Description = chats.Description,
            Image = chats.Image,
            IsGroup = chats.IsGroup,
            Mensages = chats.Mensages,
            Name = chats.Name
        };

        return chat;
    }
}
