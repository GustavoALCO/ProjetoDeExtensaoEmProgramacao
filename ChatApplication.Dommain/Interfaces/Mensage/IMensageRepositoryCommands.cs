using ChatApplication.Dommain.Entities;

namespace ChatApplication.Dommain.Interfaces.Mensage;

public interface IMensageRepositoryCommands
{
    public Task CreateMensageAsync(Entities.Mensage mensage);

    public Task UpdateMensageAsync(Entities.Mensage mensage);
}
