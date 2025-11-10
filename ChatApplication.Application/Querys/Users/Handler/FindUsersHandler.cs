using ChatApplication.Aplication.DTOs;
using ChatApplication.Dommain.Entities;
using ChatApplication.Dommain.Interfaces.User;
using MediatR;

namespace ChatApplication.Aplication.Querys.Users.Handler;

public class FindUsersHandler : IRequestHandler<FindUsers, IEnumerable<User>>
{

    private readonly IUserRepositoryQuery _context;

    public FindUsersHandler(IUserRepositoryQuery context)
    {
        _context = context;
    }

    public Task<IEnumerable<User>> Handle(FindUsers request, CancellationToken cancellationToken)
    {
        var users = _context.GetUsers(request.Username);

        return users;
    }
}
