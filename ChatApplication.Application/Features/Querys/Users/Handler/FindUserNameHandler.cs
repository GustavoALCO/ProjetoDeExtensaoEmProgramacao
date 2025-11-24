using ChatApplication.Dommain.Entities;
using ChatApplication.Dommain.Interfaces.User;
using MediatR;

namespace ChatApplication.Application.Features.Querys.Users.Handler;

public class FindUserNameHandler : IRequestHandler<FindUserName, User>
{
    private readonly IUserRepositoryQuery _query;

    public FindUserNameHandler(IUserRepositoryQuery query)
    {
        _query = query;
    }

    public async Task<User> Handle(FindUserName request, CancellationToken cancellationToken)
    {
        var user = await _query.GetUserByUsername(request.UserName);

        if (user == null)
            throw new Exception("Usuario não encontrado");

        return user;
    }
}
