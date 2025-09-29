using ChatApplication.Dommain.Entities;
using System.Security.Cryptography.X509Certificates;

namespace ChatApplication.Dommain.Interfaces.Chat;

public interface IChatRepositoryQuery
{
    public Task<Dommain.Entities.Chat> GetChatId(Guid IdChat);

    public Task<IEnumerable<Dommain.Entities.Chat>> GetAllChats(Guid IdUser);

    public Task<IEnumerable<Dommain.Entities.Chat>> SearchNameChat(Guid iduser, string chats);

}
