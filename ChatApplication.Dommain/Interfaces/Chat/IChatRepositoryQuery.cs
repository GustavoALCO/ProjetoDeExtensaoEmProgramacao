using ChatApplication.Dommain.Entities;
using System.Security.Cryptography.X509Certificates;

namespace ChatApplication.Dommain.Interfaces.Chat;

public interface IChatRepositoryQuery
{
    public Task<Dommain.Entities.Chat> GetChatId(Guid IdChat, int TakeMensages);

    public Task<(IEnumerable<Dommain.Entities.Chat>, int totalItens)> GetAllChats(Guid IdUser, int Page, int PageSize,int TakeMensages);

    public Task<(IEnumerable<Entities.Chat>, int totalItens)> SearchNameChat(Guid iduser, string chats, int Page, int PageSize, int TakeMensages);

}
