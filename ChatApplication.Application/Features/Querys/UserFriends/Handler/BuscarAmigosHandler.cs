using ChatApplication.Application.DTOs;
using ChatApplication.Dommain.Entities;
using ChatApplication.Dommain.Interfaces.UserFriend;
using MediatR;
using Microsoft.Extensions.Logging;

namespace ChatApplication.Application.Features.Querys.ChatsUser.Handler;

public class BuscarAmigosHandler : IRequestHandler<BuscarAmigos, IEnumerable<UsersDTO>>
{
    private readonly ILogger<BuscarAmigosHandler> _logger;

    private readonly IUserFriendRepositoryQuery _query;

    public BuscarAmigosHandler(IUserFriendRepositoryQuery query, ILogger<BuscarAmigosHandler> logger)
    {
        _query = query;
        _logger = logger;
    }

    public async Task<IEnumerable<UsersDTO>> Handle(BuscarAmigos request, CancellationToken cancellationToken)
    {
        var result = await _query.GetFriendsByUserIdAsync(request.UserId);

        if (result == null)
        {
            _logger.LogWarning("No friends found for user with ID {UserId}", request.UserId);
            return Enumerable.Empty<UsersDTO>();
        }
    
        _logger.LogInformation("Found {FriendCount} friends for user with ID {UserId}", result.Count(), request.UserId);

        List<UsersDTO> Listuserdto = new List<UsersDTO>();

        foreach (var user in result) {
            UsersDTO userdto = new UsersDTO()
            { UserId = user.UserId,
              Description = user.Description,
              Image = user.Image,
              Username = user.Username
            };

            Listuserdto.Add(userdto);
        }
        
        return Listuserdto;
        
    }
}
