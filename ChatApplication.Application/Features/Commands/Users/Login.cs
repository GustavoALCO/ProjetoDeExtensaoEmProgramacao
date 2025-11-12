using MediatR;

namespace ChatApplication.Aplication.Features.Commands.Users;

public class Login : IRequest<bool>
{
    public string UserName { get; set; }

    public string Password { get; set; }

}
