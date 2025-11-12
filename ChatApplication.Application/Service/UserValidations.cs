using ChatApplication.Aplication.Interfaces;
using ChatApplication.Dommain.Interfaces.User;
using Microsoft.Extensions.Logging;

namespace ChatApplication.Aplication.Service;

public class UserValidations : IUserValidations
{

    private readonly ILogger<UserValidations> _logger;

    private readonly IUserRepositoryQuery _user;

    public UserValidations(ILogger<UserValidations> logger, IUserRepositoryQuery user)
    {
        _logger = logger;
        _user = user;
    }


    public async Task<bool> NomeDisponivel(string nome)
    {
        var (user,c )= await _user.GetUsers(nome, 1, 1);

        if(user.Count() > 0)
        {
            return false;
        }

        return true;
    }
}
