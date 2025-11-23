using MediatR;

namespace ChatApplication.Application.Features.Querys.Users;

public class FindUserName : IRequest<string>
{
    public string UserName { get; set; }
}
