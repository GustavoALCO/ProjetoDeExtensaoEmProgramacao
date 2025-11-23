using ChatApplication.Dommain.Interfaces.ChatUser;
using ChatApplication.Infra.Context;
using Microsoft.EntityFrameworkCore;

namespace ChatApplication.Infra.Repository.ChatUser;

public class ChatUserQuery : IChatUserRepositoryQuery
{
    private readonly ContextDB _context;

    public ChatUserQuery(ContextDB context)
    {
        _context = context;
    }

    public async Task<bool> IsUserInChat(Guid chatId, Guid userId)
    {
        var isInChat =  await _context.chatUsers.FirstOrDefaultAsync(x => x.ChatId == chatId && x.UserId == userId);

        if (isInChat == null)
            throw new Exception("Usuario nao Esta no chat");

        return true;
    }
}
