using ChatApplication.Aplication.DTOs;
using MediatR;

namespace ChatApplication.Aplication.Querys.Mensage;

public class CarregarMensagens : IRequest<FilterDTO<Dommain.Entities.Mensage>>
{
    public Guid IdChat { get; set; }

    public int MensageLoading { get; set; }

    public int TakeMensages { get; set; }
}
