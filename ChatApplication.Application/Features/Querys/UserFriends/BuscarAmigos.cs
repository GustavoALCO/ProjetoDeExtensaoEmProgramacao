using ChatApplication.Application.DTOs;
using MediatR;

namespace ChatApplication.Application.Features.Querys.ChatsUser;

public class BuscarAmigos : IRequest<IEnumerable<UsersDTO>>
{
    public Guid UserId { get; set; }
}
