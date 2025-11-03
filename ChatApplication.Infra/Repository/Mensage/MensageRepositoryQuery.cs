using ChatApplication.Dommain.Entities;
using ChatApplication.Dommain.Interfaces.Mensage;
using ChatApplication.Dommain.Interfaces.MensageStatus;
using ChatApplication.Infra.Context;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography.X509Certificates;

namespace ChatApplication.Infra.Repository.Mensage;

public class MensageRepositoryQuery : IMensageRepositoryQuery
{
    private readonly ContextDB _contextDB;

    public MensageRepositoryQuery(ContextDB contextDB)
    {
        _contextDB = contextDB;
    }

    public async Task<List<Dommain.Entities.Mensage>> BuscarMensagem(string content)
    {
        var result = await _contextDB.Mensage
            .Where(m => m.Content.
                        ToUpper()
                        .Contains(
                        content.ToUpper()))
            .ToListAsync();

        if (result is null || result.Count == 0)
            return new List<Dommain.Entities.Mensage>();

        return result;
    }
}
