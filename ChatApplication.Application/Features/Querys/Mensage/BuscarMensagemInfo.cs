using ChatApplication.Aplication.DTOs;
using ChatApplication.Dommain.Entities;
using MediatR;

namespace ChatApplication.Aplication.Features.Querys.Mensage;

public class BuscarMensagemInfo : IRequest<MensageDTO>
{
    public Guid Id { get; set; }

}
