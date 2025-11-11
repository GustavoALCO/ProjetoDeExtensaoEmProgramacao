using ChatApplication.Dommain.Interfaces.Mensage;
using ChatApplication.Infra.Context;
using Microsoft.EntityFrameworkCore;

namespace ChatApplication.Infra.Repository.Mensage;

public class MensageRepositoryQuery : IMensageRepositoryQuery
{
    private readonly ContextDB _contextDB;

    public MensageRepositoryQuery(ContextDB contextDB)
    {
        _contextDB = contextDB;
    }

    public async Task<(List<Dommain.Entities.Mensage>, int totalitens)> BuscarMensagem(Guid IdChat, string content, int MensagesLoading, int TakeMensages)
    {
        var query = _contextDB.Mensage.AsQueryable();

        query = query
            .Where(m => m.ChatId == IdChat && 
            m.Content.ToUpper()
            .Contains(content.ToUpper()));

        if (query is null || query.Count() == 0)
            throw new Exception($"Não foi encontrado mensagens com o parametro :{content}.");

        var totalitens = query.Count();

        var result = await query.Skip(MensagesLoading)
                                    .Take(TakeMensages)
                                    .ToListAsync();

        return (result, totalitens);
    }

    public Task<Dommain.Entities.Mensage> BuscarMensagemId(Guid IdMensage)
    {
        var mensage = _contextDB.Mensage.FirstOrDefaultAsync(x=> x.MensageId == IdMensage);

        if (mensage == null)
            throw new Exception("Id de mensagem não encontrado");

        return mensage;
    }

    public async Task<(List<Dommain.Entities.Mensage>, int totalItens)> CarregarMensagens(Guid IdChat, int MensagesLoading , int TakeMensages)
    {
        var query = _contextDB.Mensage.AsQueryable();

        query = query.Where(m => m.ChatId == IdChat);
                                                                                      
        int totalItens = query.Count();

        if (query.Count() == 0)
            throw new Exception("Não há mais mensagens para carregar");

        var resultFilter =  await query.Skip(MensagesLoading)
                                    .Take(TakeMensages)
                                    .ToListAsync();

        return (resultFilter, totalItens);
    }
}
