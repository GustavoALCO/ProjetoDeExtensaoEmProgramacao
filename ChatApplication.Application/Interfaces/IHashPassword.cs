using ChatApplication.Dommain.Entities;

namespace ChatApplication.Application.Interfaces;

public interface IHashPassword
{
    string Hash(User user, string password);

    bool Verify(User user, string Hashpassword, string requestPassword);
}
