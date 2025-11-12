using ChatApplication.Aplication.DTOs;
using ChatApplication.Aplication.Features.Querys.Mensage;
using ChatApplication.Dommain.Interfaces.Mensage;
using MediatR;

namespace ChatApplication.Aplication.Features.Querys.Mensage.Handler;

public class CarregarMensagensHandler : IRequestHandler<CarregarMensagens, FilterDTO<Dommain.Entities.Mensage>>
{
    private readonly IMensageRepositoryQuery _context;

    public CarregarMensagensHandler(IMensageRepositoryQuery context)
    {
        _context = context;
    }

    public async Task<FilterDTO<Dommain.Entities.Mensage>> Handle(CarregarMensagens request, CancellationToken cancellationToken)
    {
        var (mensage, totalitens) = await _context.CarregarMensagens(request.IdChat, request.MensageLoading, request.TakeMensages);

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
            Data = mensage
        };

        return filter;
    }
}
