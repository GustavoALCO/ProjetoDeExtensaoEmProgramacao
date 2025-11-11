using ChatApplication.Dommain.Entities;
using ChatApplication.Dommain.Interfaces.MensageStatus;
using ChatApplication.Dommain.Interfaces.User;
using ChatApplication.Infra.Context;
using Microsoft.EntityFrameworkCore;

namespace ChatApplication.Infra.Repository.MensageStatus;

public class MensageStatusRepositoryQuery : IMensageStatusRepositoryQuery
{
    private readonly ContextDB _context;

    public MensageStatusRepositoryQuery(ContextDB context)
    {
        _context = context;
    }

    public async Task<Dommain.Entities.MensageStatus> GetMensageStatusID(Guid idMensage)
    {
        var mensageStatus = await _context.MensageStatus.FirstOrDefaultAsync(x => x.MensageID == idMensage); 

        if (mensageStatus == null) {
            throw new Exception("Id da mensagem nao encontrada");
        }

        return mensageStatus;
    }
}
