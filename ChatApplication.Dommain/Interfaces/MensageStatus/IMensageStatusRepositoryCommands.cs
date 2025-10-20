namespace ChatApplication.Dommain.Interfaces.MensageStatus;

public interface IMensageStatusRepositoryCommands
{
    public Task PostMensageStatus();

    public Task UpdateStatus();
}
