using ChatApplication.Aplication.DTOs;
using ChatApplication.Dommain.Entities;
using MediatR;

namespace ChatApplication.Aplication.Querys.Mensage;

public class BuscarMensagemInfo : IRequest<MensageDTO>
{
    public Guid Id { get; set; }

}
