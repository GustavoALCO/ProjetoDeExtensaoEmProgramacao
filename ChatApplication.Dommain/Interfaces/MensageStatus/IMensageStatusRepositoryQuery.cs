using ChatApplication.Dommain.Entities;

namespace ChatApplication.Dommain.Interfaces.MensageStatus;

public interface IMensageStatusRepositoryQuery
{

    public Task<Dommain.Entities.MensageStatus> GetMensageStatusID();

}
