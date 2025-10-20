using ChatApplication.Dommain.Entities;
using System.Security.Cryptography.X509Certificates;

namespace ChatApplication.Dommain.Interfaces.Mensage;

public interface IchatRepositoryQuery
{
    public Task<IEnumerable<Dommain.Entities.Chat>> GetAllMensages(Guid idChat);

    public Task<IEnumerable<Dommain.Entities.Mensage>> FindMensage(string mensage);
}
