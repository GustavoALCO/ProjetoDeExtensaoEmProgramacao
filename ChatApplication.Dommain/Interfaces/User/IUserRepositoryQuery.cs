using ChatApplication.Dommain.Entities;

namespace ChatApplication.Dommain.Interfaces.User;

public interface IUserRepositoryQuery
{
    public Task<Dommain.Entities.User> GetUserById(Guid userId);

    public Task<Dommain.Entities.User> GetUserByUsername(string username);

    public Task<(IEnumerable<Dommain.Entities.User>, int totalItens)> GetUsers(string Username, int numberPage, int takeUsers);
}
