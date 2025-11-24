using ChatApplication.Application.Interfaces;
using ChatApplication.Dommain.Interfaces.User;
using Microsoft.Extensions.Logging;

namespace ChatApplication.Application.Service;

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
        var user= await _user.GetUserByUsername(nome);

        if(user.Username != nome)
        {
            return false;
        }

        return true;
    }
}
