using ChatApplication.Dommain.Interfaces.Chat;
using ChatApplication.Dommain.Interfaces.ChatUser;

namespace ChatApplication.Application.Service;

public class ChatValidation
{
    private readonly IChatRepositoryQuery _chatRepositoryQuery;

    private readonly IChatUserRepositoryQuery _chatUserRepositoryQuery;

    public ChatValidation(IChatRepositoryQuery chatRepositoryQuery, IChatUserRepositoryQuery chatUserRepositoryQuery)
    {
        _chatRepositoryQuery = chatRepositoryQuery;
        _chatUserRepositoryQuery = chatUserRepositoryQuery;
    }

    public async Task<bool> IsUserInChat(Guid chatId, Guid userId)
    {

        var isInChat = await _chatUserRepositoryQuery.IsUserInChat(chatId, userId);

        return isInChat; 
    }

    public async Task<bool> ChatExists(Guid chatId)
    {
        var chatExists = await _chatRepositoryQuery.GetChatId(chatId, 0);

        if (chatExists == null) 
            return false;

        return true;
    }
}
