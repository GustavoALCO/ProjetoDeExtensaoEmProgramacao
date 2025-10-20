using ChatApplication.Infra.Context;
using ChatApplication.Infra.Repository.Chat;
using Microsoft.Extensions.Logging;

namespace ChatApplication.Infra.Repository.Mensage;

public class ChatRepositoryCommands : IChatRepositoryCommands
{

    private readonly ILogger<ChatRepositoryCommands> _logger;

    private readonly ContextDB _db;

    public ChatRepositoryCommands(ContextDB db, ILogger<ChatRepositoryCommands> logger)
    {
        _db = db;
        _logger = logger;
    }

    public async Task CreateChatAsync(Dommain.Entities.Chat chat)
    {
        await _db.Chat.AddAsync(chat);

        await _db.SaveChangesAsync();

        _logger.LogInformation($"Chat Criado com o Id {chat.ChatId} as {DateTime.Now}");
    }

    public async Task UpdateChatAsync(Dommain.Entities.Chat chat)
    {
        _db.Chat.Update(chat);

        await _db.SaveChangesAsync();

        _logger.LogInformation($"Chat com o Id {chat.ChatId} Atualizado as {DateTime.Now}");
    }
}
