namespace ChatApplication.Dommain.Interfaces.User;

public interface IUserRepositoryQuery
{
    public Task GetUserById(Guid userId);

    public Task GetUsers(string? Username);
}
