using ChatApplication.Dommain.Entities;
using ChatApplication.Dommain.Interfaces.Chat;
using ChatApplication.Infra.Context;
using Microsoft.EntityFrameworkCore;

namespace ChatApplication.Infra.Repository.Chat;

public class ChatRepositoryQuery : IChatRepositoryQuery
{
    private readonly ContextDB _db;

    public ChatRepositoryQuery(ContextDB db)
    {
        _db = db;
    }

    public async Task<IEnumerable<Dommain.Entities.Chat>> GetAllChats(Guid IdUser)
    {
        var chats = await _db.chatUsers
        .Include(cu => cu.Chat)
            .ThenInclude(c => c.Mensages).Take(1) //pega a ultima mensagem do chat
        .Include(cu => cu.Chat)
            .ThenInclude(c => c.ChatUsers)
                .ThenInclude(cu2 => cu2.User) // todos os participantes do chat
        .Where(cu => cu.UserId == IdUser)
        .Select(cu => cu.Chat) // pega só o chat
        .ToListAsync();

        if (chats.Count() < 1)
            throw new Exception("Nenhum Chat encontrado para o usuario");

        return chats;
    }

    public async Task<Dommain.Entities.Chat> GetChatId(Guid IdChat)
    {
        var chat = await _db.Chat.FirstOrDefaultAsync(x => x.ChatId == IdChat);

        if(chat == null)
            throw new Exception("Id De Chat nao encontrado");

        return chat;
    }

    public async Task<IEnumerable<Dommain.Entities.Chat>> SearchNameChat(Guid iduser,string chats)
    {
        var chat = await _db.Chat
    .Where(c => c.Name.ToUpper().Contains(chats.ToUpper()) 
                && c.ChatUsers.Any(cu => cu.UserId == iduser)) 
    .ToListAsync();

        if (chat.Count() <= 1)
            throw new Exception("Nao foi encontrado nenhum chat com este nome");

        return chat;
    }
}
