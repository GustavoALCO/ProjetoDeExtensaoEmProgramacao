using ChatApplication.Dommain.Interfaces.MensageStatus;
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

    public Task<Dommain.Entities.MensageStatus> GetMensageStatusID(Guid idMensage)
    {
        var mensageStatus = _context.MensageStatus.FirstOrDefaultAsync(x => x.MensageID == idMensage);

        if (mensageStatus == null) {
            throw new Exception("Id da mensagem nao encontrada");
        }

        return mensageStatus;
    }
}
