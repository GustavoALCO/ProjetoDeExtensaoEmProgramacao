namespace ChatApplication.Dommain.Interfaces.Mensage;

public interface IChatsRepositoryCommands
{
    public Task PostMensage(Guid IDChat, string content);

    public Task AlterarMensagem(Guid IDChat, Guid mensage, string updatecontent);
}
