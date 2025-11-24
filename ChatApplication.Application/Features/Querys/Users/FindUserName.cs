using ChatApplication.Dommain.Entities;
using MediatR;

namespace ChatApplication.Application.Features.Querys.Users;

public class FindUserName : IRequest<User>
{
    public string UserName { get; set; }
}
