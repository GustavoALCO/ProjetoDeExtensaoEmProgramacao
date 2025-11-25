namespace ChatApplication.Dommain.Interfaces.UserFriend;

public interface IUserFriendRepositoryCommands
{
    public Task RequestFriendshipAsync(Guid userId, Guid friendId, bool? request);

  

    public  Task RequestFriendshipAsync(Guid userId, Guid friendId);


    public Task RemoveFriendAsync (Guid userId, Guid friendId);
}
