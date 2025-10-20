using ChatApplication.Dommain.Entities;
using ChatApplication.Dommain.Interfaces.Mensage;
using ChatApplication.Infra.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace ChatApplication.Infra.Repository.Mensage;

public class ChatRepositoryQuery : IchatRepositoryQuery
{

    private readonly ILogger<ChatRepositoryQuery> _logger;

    private readonly ContextDB _db;

    public ChatRepositoryQuery(ContextDB db, ILogger<ChatRepositoryQuery> logger)
    {
        _db = db;
        _logger = logger;
    }

    public async Task<IEnumerable<Dommain.Entities.Mensage>> FindMensage(string mensage)
    {
        var mensagebd = await _db.Mensage.Where(x => x.Content.ToUpper()
                                                                            .Contains(mensage.ToUpper()))
                                                                            .ToListAsync();
        if (mensage.Count() <= 0)
        {
            _logger.LogError($"Nao foi possivel encontrar a mensagem com os parametros de {mensage}");
            throw new Exception($"Nao foi possivel encontrar a mensagem com os parametros de {mensage}");
        }
             

        return mensagebd;

    }

    public async Task<IEnumerable<Dommain.Entities.Chat>> GetAllMensages(Guid idChat)
    {
        var mensagebd = await _db.Chat
            .Where(m => m.ChatId == idChat)
            .Include(cu => cu.Mensages)
            .ThenInclude(m => m.SendMensage)
            .ToListAsync();

                                                                   
        if (mensagebd.Count() <= 0)
        {
            _logger.LogError($"Nao foi possivel encontrar as mensagens com o id : {idChat}, Possivelmente o chat nao existe");
            throw new Exception($"Nao foi possivel encontrar as mensagens com o id : {idChat}, Possivelmente o chat nao existe");
        }

        return mensagebd;
    }
}
