using ChatApplication.Dommain.Interfaces.MensageStatus;
using ChatApplication.Infra.Context;

namespace ChatApplication.Infra.Repository.MensageStatus;

public class MensageStatusRepositoryCommands : IMensageStatusRepositoryCommands
{
    private readonly ContextDB _context;


    public MensageStatusRepositoryCommands(ContextDB context)
    {
        _context = context;
    }

    public async Task PostMensageStatus(Dommain.Entities.MensageStatus mensageStatus)
    {
        await _context.MensageStatus.AddAsync(mensageStatus);

        await _context.SaveChangesAsync();
    }

    public async Task UpdateStatus(Dommain.Entities.MensageStatus mensageStatus)
    {
        _context.MensageStatus.Update(mensageStatus);

        await _context.SaveChangesAsync();
    }
}
