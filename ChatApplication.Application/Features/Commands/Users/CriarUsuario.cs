using MediatR;

namespace ChatApplication.Aplication.Features.Commands.Users;

public class CriarUsuario : IRequest
{
    public required string Username { get; set; }

    public required string Password { get; set; }

    public string? Description { get; set; }

    public string? Image { get; set; }
}
