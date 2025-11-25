using MediatR;

namespace ChatApplication.Application.Features.Commands.UserFriends;

public class RemoverAmizade : IRequest
{
    public Guid UserId { get; set; }

    public Guid FriendId { get; set; }
}
