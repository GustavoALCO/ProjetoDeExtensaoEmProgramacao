using ChatApplication.Dommain.Interfaces.UserFriend;
using MediatR;

namespace ChatApplication.Application.Features.Commands.UserFriends.Handler;

public class SolicitacaoDeAmizade : IRequestHandler<UserFriends.SolicitacaoDeAmizade>
{
    private readonly IUserFriendRepositoryCommands _commands;

    private readonly IUserFriendRepositoryQuery _query;

    public SolicitacaoDeAmizade(IUserFriendRepositoryCommands commands, IUserFriendRepositoryQuery query)
    {
        _commands = commands;
        _query = query;
    }

    public async Task Handle(UserFriends.SolicitacaoDeAmizade request, CancellationToken cancellationToken)
    {
        var amigos = await _query.AreFriendsAsync(request.userId, request.FriendId);

        if (amigos != false)
            throw new Exception("Vocês já são amigos.");

        await _commands.RequestFriendshipAsync(request.userId, request.FriendId);
    }
}
