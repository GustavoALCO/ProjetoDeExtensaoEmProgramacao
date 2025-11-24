using ChatApplication.Application.DTOs;
using MediatR;

namespace ChatApplication.Application.Features.Querys.Mensage;

public class BuscarMensagemInfo : IRequest<MensageDTO>
{
    public Guid Id { get; set; }

}
