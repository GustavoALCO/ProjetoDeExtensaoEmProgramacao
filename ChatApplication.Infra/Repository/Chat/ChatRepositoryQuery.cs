using ChatApplication.Dommain.Interfaces.Chat;
using ChatApplication.Infra.Context;
using Microsoft.EntityFrameworkCore;

namespace ChatApplication.Infra.Repository.Chat;

public class ChatRepositoryQuery : IChatRepositoryQuery
{
    private readonly ContextDB _db;

    public ChatRepositoryQuery(ContextDB db)
    {
        _db = db;
    }

    public async Task<(IEnumerable<Dommain.Entities.Chat>, int totalItens)> GetAllChats(Guid IdUser, int Page, int PageSize, int TakeMensages)
    {

       
        var chatusers = await _db.chatUsers
        .Where(cu => cu.UserId == IdUser)
        .Select(c => c.ChatId)
        //Remove dados que podem vir duplicados
        .Distinct()
        .ToListAsync();

        if (chatusers.Count() == 0)
            throw new Exception("Não foi encontrado nenhum chat em que o Usuario participa");
         
        var chats = _db.Chat.Where(c => chatusers.Contains(c.ChatId))
                                    .Include(c => c.ChatUsers)
                                    .Select(x => new Dommain.Entities.Chat
                                    {
                                        ChatId = x.ChatId,
                                        ChatUsers = x.ChatUsers,
                                        Description = x.Description,
                                        Image = x.Image,
                                        IsGroup = x.IsGroup,
                                        Name = x.Name,
                                        Mensages = x.Mensages.OrderByDescending(m => m.SendMensage)
                                        .Take(TakeMensages).ToList()
                                    })
                                    .OrderByDescending(c => c.Mensages.Max(m => m.SendMensage)) // ordena pelos mais recentes
                                    .Skip((Page - 1) * PageSize)
                                    .Take(PageSize)
                                    .ToListAsync();

        int totalitens = chatusers.Count();

        return (await chats, totalitens);
    }

    public async Task<Dommain.Entities.Chat> GetChatId(Guid IdChat, int TakeMensages)
    {
        // Busca o chat junto com as mensagens
        var chat = await _db.Chat
            .Include(c => c.Mensages)
            .Include(c => c.ChatUsers)
            .FirstOrDefaultAsync(x => x.ChatId == IdChat);

        if (chat == null)
            throw new Exception("Id de Chat não encontrado");

        // Ordena e pega as últimas mensagens
        chat.Mensages = chat.Mensages
            .OrderByDescending(m => m.SendMensage)
            .Take(TakeMensages)
            .ToList();

        return chat;
    }

    public async Task<(IEnumerable<Dommain.Entities.Chat>, int totalItens)> SearchNameChat(Guid iduser, string chats, int Page, int PageSize, int TakeMensages)
    {
        //Adiciona query para a busca dos chats do usuario
        var query = _db.Chat.AsQueryable();

        //Busca os chats que o usuario participa, se Passar a string do chat ele faz uma busca pelo nome, se não ele busca todos
        query = query.Where(c => (c.Name.ToUpper().Contains(chats.ToUpper()))
                                  && c.ChatUsers.Any(cu => cu.UserId == iduser));
            
        //Organiza pela data das ultimas mensagens enviadas
        query = query.Select(x => new Dommain.Entities.Chat
        {
            ChatId = x.ChatId,
            ChatUsers = x.ChatUsers,
            Description = x.Description,
            Image = x.Image,
            IsGroup = x.IsGroup,
            Name = x.Name,
            Mensages = x.Mensages.OrderByDescending(m => m.SendMensage)
            .Take(TakeMensages).ToList()
        });

        if (query == null)
            throw new Exception("Nao foi encontrado nenhum chat com este nome");

        //Verifica quantos chats existem com o usuario
        int totalitens = await query.CountAsync(); 

        var Chats = query
                        .Skip((Page - 1) * PageSize)
                        .Take(PageSize)
                        .ToListAsync();

        return (await Chats, totalitens);
    }
}
