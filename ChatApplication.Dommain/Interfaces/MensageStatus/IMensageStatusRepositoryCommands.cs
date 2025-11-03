namespace ChatApplication.Dommain.Interfaces.MensageStatus;

public interface IMensageStatusRepositoryCommands
{
    public Task PostMensageStatus(Entities.MensageStatus mensageStatus);

    public Task UpdateStatus(Entities.MensageStatus mensageStatus);
}
