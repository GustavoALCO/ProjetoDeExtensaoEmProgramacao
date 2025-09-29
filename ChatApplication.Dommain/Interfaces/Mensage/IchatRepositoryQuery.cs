using ChatApplication.Dommain.Entities;
using System.Security.Cryptography.X509Certificates;

namespace ChatApplication.Dommain.Interfaces.Mensage;

public interface IchatRepositoryQuery
{
    public Task<Dommain.Entities.Mensage> GetAllMensages(Guid idChat);
}
