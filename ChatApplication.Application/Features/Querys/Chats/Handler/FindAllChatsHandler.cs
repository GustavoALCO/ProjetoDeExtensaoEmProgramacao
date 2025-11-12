using ChatApplication.Aplication.DTOs;
using ChatApplication.Aplication.Features.Querys.Chats;
using ChatApplication.Dommain.Entities;
using ChatApplication.Dommain.Interfaces.Chat;
using MediatR;

namespace ChatApplication.Aplication.Features.Querys.Chats.Handler;

public class FindAllChatsHandler : IRequestHandler<FindAllChats, FilterDTO<ChatDTO>>
{
    private readonly IChatRepositoryQuery _context;

    public FindAllChatsHandler(IChatRepositoryQuery context)
    {
        _context = context;
    }

    public async Task<FilterDTO<ChatDTO>> Handle(FindAllChats request, CancellationToken cancellationToken)
    {
        var(chats, totalusers) = await _context.GetAllChats(request.IdUser,request.Page, request.PageSize, request.TakeMensages);

        //Calcula o total de paginas existentes de chats 
        double totalpages = totalusers / request.PageSize;

        //Mascara Algumas variaveis para o retorno da resposta
        var chatsDTO = chats.Select(x => new ChatDTO
        {
            ChatId = x.ChatId,
            Description = x.Description,
            Image = x.Image,
            IsGroup = x.IsGroup,
            Mensages = x.Mensages,
            Name = x.Name,
        });

        //passa os parametros com paginação de volta como resposta 
        var filter = new FilterDTO<ChatDTO>()
        {
            Page = request.Page,
            PageSize = request.PageSize,
            TotalItems = totalusers,

            //Arredonda sempre para cima, dando a opção sempre de criar mais uma pagina.
            TotalPages = (int)Math.Ceiling(totalpages),
            Data = chatsDTO

        };

        return filter;
    }
}
