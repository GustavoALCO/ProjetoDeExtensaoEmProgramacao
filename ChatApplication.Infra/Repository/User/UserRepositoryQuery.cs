using ChatApplication.Dommain.Entities;
using ChatApplication.Dommain.Interfaces.User;
using ChatApplication.Infra.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
namespace ChatApplication.Infra.Repository.User;

public class UserRepositoryQuery : IUserRepositoryQuery
{

    private readonly ILogger<UserRepositoryQuery> _logger;

    private readonly ContextDB _db;

    public UserRepositoryQuery(ContextDB db, ILogger<UserRepositoryQuery> logger)
    {
        _db = db;
        _logger = logger;
    }

    public async Task<Dommain.Entities.User> GetUserById(Guid userId)
    {
        var user = await _db.User.FirstOrDefaultAsync(x => x.UserId == userId);

        if (user == null)
        {
            _logger.LogError($"Nao foi possivel encontrar o Usuario com o ID : {userId}");
            throw new Exception($"Nao foi possivel encontrar o Usuario com o ID : {userId}");
        }

        return user;
    }

    public async Task<(IEnumerable<Dommain.Entities.User>,int totalItens)> GetUsers(string Username, int numberPage, int takeUsers)
    {

        var query = _db.User.AsQueryable();

        query = query.Where(x => x.Username.ToUpper().Contains(Username.ToUpper()) || x.IsValid == true);
                                                        

        int totalitens = await query.CountAsync();

        if (query == null)
        {
            _logger.LogError($"Nao foi possivel encontrar o Usuario com o nome : {Username}");
            throw new Exception($"Nao foi possivel encontrar o Usuario com o ID : {Username}");
        }

        var User = query
                        .OrderBy(x => x.Username)
                        .Skip((numberPage - 1) * takeUsers)
                        .Take(takeUsers)
                        .ToListAsync(); 

        return (await User, totalitens);
    }

    public async Task<int>TotalPages (string? Username, int takeUsers)
    {
        var totalUsers = await _db.User.Where(x => x.Username.ToUpper()
                                                        .Contains(Username.ToUpper()))
                                                        .CountAsync();

        return (int)Math.Ceiling((double)totalUsers / takeUsers);
    }
}
