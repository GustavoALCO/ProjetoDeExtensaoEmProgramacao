using MediatR;

namespace ChatApplication.Application.Features.Querys.ChatsUser;

public class BuscarAmigos : IRequest<IEnumerable<Dommain.Entities.User>>
{
    public Guid UserId { get; set; }
}
