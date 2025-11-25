
using ChatApplication.Infra.Context;

namespace ChatApplication.Infra.Repository.Chat;

public class ChatRepositoryCommands : IChatRepositoryCommands
{

    private readonly ContextDB _context;

    public ChatRepositoryCommands(ContextDB contextDB)
    {
        _context = contextDB;
    }

    public async Task CreateChatAsync(Dommain.Entities.Chat chat)
    {
        await _context.Chat.AddAsync(chat);

        await _context.SaveChangesAsync();

    }

    public async Task DeleteChatAsync(Dommain.Entities.Chat chat)
    {
        _context.Chat.Remove(chat);

        await _context.SaveChangesAsync();
    }

    public async Task UpdateChatAsync(Dommain.Entities.Chat chat)
    {
        _context.Chat.Update(chat);

        await _context.SaveChangesAsync();
    }
}
