using ChatApplication.Dommain.Entities;
using ChatApplication.Dommain.Interfaces.UserFriend;
using ChatApplication.Infra.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace ChatApplication.Infra.Repository.UserFriend;

public class UserFriendsRepositoryQuery : IUserFriendRepositoryQuery
{
    private readonly ContextDB _db;

    private readonly Logger<UserFriendsRepositoryQuery> _logger;

    public UserFriendsRepositoryQuery(Logger<UserFriendsRepositoryQuery> logger, ContextDB db)
    {
        _logger = logger;
        _db = db;
    }

    public async Task<bool> AreFriendsAsync(Guid userId, Guid friendId)
    {
        var areFriends = await _db.UserFriend.AnyAsync(x =>
            ((x.UserId == userId && x.FriendId == friendId) && x.IsAccepted == true) ||
            ((x.UserId == friendId && x.FriendId == userId) && x.IsAccepted == true));

        if (areFriends == false)
        {
            _logger.LogInformation($"Usuario com o Id {userId} nao e amigo do Usuario {friendId}");
            return areFriends;
        }

        return areFriends;
    }

    public async Task<IEnumerable<Dommain.Entities.User>> GetFriendsByUserIdAsync(Guid userId)
    {
        //Busca todos os UserFriend em que o usuario e aceitou a amizade
        var friendships = await _db.UserFriend    
        .Where(x => (x.UserId == userId || x.FriendId == userId) && x.IsAccepted == true)
        //seleciona apenas os id que nao sao o mesmo do parametro passado
        .Select(x => x.UserId == userId ? x.FriendId : x.UserId)
        .ToListAsync();

       
        // Buscar os usuários correspondentes da busca acima 
        var friends = await _db.User
            .Where(u => friendships.Contains(u.UserId))
            .ToListAsync();

        //retorna apenas os ids encontrados
        return friends;
    }

    public async Task<Dommain.Entities.UserFriend> GetUserFriend(Guid userId, Guid friendId)
    {
        var areFriends = await _db.UserFriend.FirstOrDefaultAsync(x =>
            ((x.UserId == userId && x.FriendId == friendId) && x.IsAccepted == true) ||
            ((x.UserId == friendId && x.FriendId == userId) && x.IsAccepted == true));

        if (areFriends == null)
        {
            _logger.LogInformation($"Usuario com o Id {userId} nao e amigo do Usuario {friendId}");
            throw new Exception($"Usuario com o Id {userId} nao e amigo do Usuario {friendId}");
        }

        return areFriends;
    }
}
