namespace ChatApplication.Dommain.Interfaces.ChatUser;

public interface IChatUserRepositoryQuery
{
    public Task<bool> IsUserInChat(Guid chatId, Guid userId);
}
