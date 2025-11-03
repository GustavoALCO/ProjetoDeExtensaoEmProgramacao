namespace ChatApplication.Dommain.Interfaces.Mensage;

public interface IMensageRepositoryQuery
{
    public Task<List<Entities.Mensage>> BuscarMensagem(string content);
}
