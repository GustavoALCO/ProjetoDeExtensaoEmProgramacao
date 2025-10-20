using ChatApplication.Dommain.Entities;

namespace ChatApplication.Dommain.Interfaces.User;

public interface IUserRepositoryCommands
{
    public Task CreateUser(Dommain.Entities.User user);

    public Task UpdateUser(Dommain.Entities.User user);
}
