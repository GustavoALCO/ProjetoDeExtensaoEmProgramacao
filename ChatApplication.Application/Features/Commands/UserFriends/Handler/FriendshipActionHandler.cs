using ChatApplication.Dommain.Interfaces.UserFriend;
using MediatR;

namespace ChatApplication.Application.Features.Commands.UserFriends.Handler;

public class FriendshipActionHandler : IRequestHandler<FriendshipAction>
{
    private readonly IUserFriendRepositoryCommands _commands;

    private readonly IUserFriendRepositoryQuery _query;

    public FriendshipActionHandler(IUserFriendRepositoryQuery query, IUserFriendRepositoryCommands commands)
    {
        _query = query;
        _commands = commands;
    }

    public async Task Handle(FriendshipAction request, CancellationToken cancellationToken)
    {
        var friendship = await _query.AreFriendsAsync(request.UserId, request.FriendId);

        if (friendship != false)
        {
            throw new Exception("Usuarios ja sao amigos");
        }
        
        await _commands.RequestFriendshipAsync(request.UserId, request.FriendId, request.response);
    }
}
