using ChatApplication.Dommain.Entities;
using MediatR;

namespace ChatApplication.Application.Features.Commands.Users;

public class CriarUsuario : IRequest
{
    public User User { get; set; }
}
