using ChatApplication.Dommain.Entities;

namespace ChatApplication.Dommain.Interfaces.UserFriend;

public interface IUserFriendRepositoryQuery
{
    Task<IEnumerable<Dommain.Entities.User>> GetFriendsByUserIdAsync(Guid userId);

    Task<Dommain.Entities.UserFriend> GetUserFriend(Guid userId, Guid friendId);

    Task<bool> AreFriendsAsync(Guid userId, Guid friendId);
}
