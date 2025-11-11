using ChatApplication.Aplication.DTOs;
using ChatApplication.Dommain.Entities;
using ChatApplication.Dommain.Interfaces.Mensage;
using MediatR;

namespace ChatApplication.Aplication.Querys.Mensage.Handler;

public class BuscarMensagensHandler : IRequestHandler<BuscarMensagens, FilterDTO<Dommain.Entities.Mensage>>
{
    private readonly IMensageRepositoryQuery _context;

    public BuscarMensagensHandler(IMensageRepositoryQuery context)
    {
        _context = context;
    }

    public async Task<FilterDTO<Dommain.Entities.Mensage>> Handle(BuscarMensagens request, CancellationToken cancellationToken)
    {
        var (mensagens, totalitens) = await _context.BuscarMensagem(request.IdChat, request.Mensage, request.MensageLoading, request.TakeMensages);

        //CAlculando quantos refresh tem a mais
        double totalrefresh = totalitens / request.TakeMensages;

        // Adicionando os dados no DTO
        var filter = new FilterDTO<Dommain.Entities.Mensage>()
        {

            Page = request.MensageLoading,
            PageSize = request.TakeMensages,
            TotalItems = totalitens,

            //Arredonda sempre para cima, dando a opção sempre de criar mais uma pagina.
            TotalPages = (int)Math.Ceiling(totalrefresh),
            Data = mensagens
        };

        return filter;
    }
}
