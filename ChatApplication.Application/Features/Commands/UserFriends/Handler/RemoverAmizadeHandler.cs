using ChatApplication.Dommain.Interfaces.UserFriend;
using MediatR;

namespace ChatApplication.Application.Features.Commands.UserFriends.Handler;

public class RemoverAmizadeHandler : IRequestHandler<RemoverAmizade>
{
    private readonly IUserFriendRepositoryCommands _commands;

    private readonly IUserFriendRepositoryQuery _query;

    public RemoverAmizadeHandler(IUserFriendRepositoryQuery query, IUserFriendRepositoryCommands commands)
    {
        _query = query;
        _commands = commands;
    }

    public async Task Handle(RemoverAmizade request, CancellationToken cancellationToken)
    {
        var friendship = await _query.AreFriendsAsync(request.UserId, request.FriendId);

        if (friendship == false)
        {
            throw new Exception("Usuarios ja nao sao amigos");
        }

        await _commands.RemoveFriendAsync(request.UserId, request.FriendId);
    }
}

