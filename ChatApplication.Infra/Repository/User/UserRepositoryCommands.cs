using ChatApplication.Dommain.Entities;
using ChatApplication.Dommain.Interfaces.User;
using ChatApplication.Infra.Context;
using Microsoft.Extensions.Logging;
using System;

namespace ChatApplication.Infra.Repository.User;

public class UserRepositoryCommands : IUserRepositoryCommands
{

    private readonly ILogger<UserRepositoryCommands> _logger;

    private readonly ContextDB _db;

    public UserRepositoryCommands(ContextDB db, ILogger<UserRepositoryCommands> logger)
    {
        _db = db;
        _logger = logger;
    }

    public async Task CreateUser(Dommain.Entities.User user)
    {
        await _db.User.AddAsync(user);

        await _db.SaveChangesAsync();

        _logger.LogInformation($"Usuario Criado com o Id {user.UserId} as {DateTime.Now}");
    }

    public async Task UpdateUser(Dommain.Entities.User user)
    {
        await _db.User.AddAsync(user);

        await _db.SaveChangesAsync();

        _logger.LogInformation($"Usuario com o Id {user.UserId} \n Atualizado com o Id  as {DateTime.Now}");
    }
}
