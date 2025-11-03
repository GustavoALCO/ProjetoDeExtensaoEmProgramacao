using ChatApplication.Dommain.Interfaces.Mensage;
using ChatApplication.Infra.Context;

namespace ChatApplication.Infra.Repository.Mensage;

public class MensageRepositoryCommands : IMensageRepositoryCommands
{
    private readonly ContextDB _contextDB;

    public MensageRepositoryCommands(ContextDB contextDB)
    {
        _contextDB = contextDB;
    }

    public async Task CreateMensageAsync(Dommain.Entities.Mensage mensage)
    {
        await _contextDB.Mensage.AddAsync(mensage);

        await _contextDB.SaveChangesAsync();
    }

    public async Task UpdateMensageAsync(Dommain.Entities.Mensage mensage)
    {
        _contextDB.Mensage.Update(mensage);

        await _contextDB.SaveChangesAsync();
    }
}
