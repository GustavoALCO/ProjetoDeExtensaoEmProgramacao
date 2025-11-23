using MediatR;

namespace ChatApplication.Aplication.Features.Commands.Users;

public class Login : IRequest<string>
{
    public string UserName { get; set; }

    public string Password { get; set; }

}
