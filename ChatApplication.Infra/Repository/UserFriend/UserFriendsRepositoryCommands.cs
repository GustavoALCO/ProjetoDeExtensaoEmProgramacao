using ChatApplication.Dommain.Entities;
using ChatApplication.Dommain.Interfaces.UserFriend;
using ChatApplication.Infra.Context;
using Microsoft.Extensions.Logging;

namespace ChatApplication.Infra.Repository.UserFriend;

public class UserFriendsRepositoryCommands : IUserFriendRepositoryCommands
{
    private readonly ContextDB _db;

    private readonly UserFriendsRepositoryQuery _query;

    private readonly ILogger<UserFriendsRepositoryCommands> _logger;

    public UserFriendsRepositoryCommands(
        ILogger<UserFriendsRepositoryCommands> logger,
        ContextDB db,
        UserFriendsRepositoryQuery query)
    {
        _logger = logger;
        _db = db;
        _query = query;
    }

    public async Task RequestFriendshipAsync(Guid userId, Guid friendId, bool? request)
    {
        var userfriend = new Dommain.Entities.UserFriend
        {
            UserId = userId,
            FriendId = friendId,
            IsAccepted = request,
            CreatedAt = DateTime.UtcNow,
        };

        _db.UserFriend.Update(userfriend);

        await _db.SaveChangesAsync();

        _logger.LogInformation($"Convite de Amizade enviado do Usuario {userId}, para o {friendId}. \n A resposta do Amigo foi de {request}");
    }

    public async Task RemoveFriendAsync(Guid userId, Guid friendId)
    {
        var query = await _query.GetUserFriend(userId, friendId);

        if (query == null)
        {
            _logger.LogInformation("Os Usuarios nao sao amigos. entao a operacao nao sera possivel");
            throw new Exception("Os Usuarios nao sao amigos. entao a operacao nao sera possivel");
        }

        var friend = _db.Remove(query);

        await _db.SaveChangesAsync();

        _logger.LogInformation($"Convite de Amizade enviado do Usuario {userId}, para o {friendId}. \n A resposta do Amigo foi de ");
    }

    public async Task RequestFriendshipAsync(Guid userId, Guid friendId)
    {
        var userfriend = new Dommain.Entities.UserFriend
        {
            UserId = userId,
            FriendId = friendId,
            IsRequest = true,
            CreatedAt = DateTime.UtcNow,
        };

        var friend = await _db.UserFriend.AddAsync(userfriend);

        await _db.SaveChangesAsync();
    }

}
