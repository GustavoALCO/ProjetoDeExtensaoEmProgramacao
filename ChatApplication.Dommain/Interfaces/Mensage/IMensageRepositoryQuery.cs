namespace ChatApplication.Dommain.Interfaces.Mensage;

public interface IMensageRepositoryQuery
{
    public Task<(List<Entities.Mensage>, int totalitens)> BuscarMensagem(Guid IdChat, string content, int MensagesLoading, int TakeMensages);

    public Task<(List<Entities.Mensage>, int totalItens)> CarregarMensagens(Guid IdChat, int MensagesLoading, int TakeMensages);

    public Task<Entities.Mensage> BuscarMensagemId(Guid IdChat);
}
