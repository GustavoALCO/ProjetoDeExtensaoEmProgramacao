using ChatApplication.Application.DTOs;
using ChatApplication.Dommain.Entities;
using MediatR;

namespace ChatApplication.Application.Features.Querys.Mensage;

public class BuscarMensagens : IRequest<FilterDTO<Dommain.Entities.Mensage>>
{
    public Guid IdChat { get; set; }

    public string Mensage { get; set; }

    public int MensageLoading { get; set; }

    public int TakeMensages { get; set; }
}
