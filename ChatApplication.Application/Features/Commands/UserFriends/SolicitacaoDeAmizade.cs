using MediatR;

namespace ChatApplication.Application.Features.Commands.UserFriends;

public class SolicitacaoDeAmizade : IRequest
{
    public Guid userId { get; set; }

    public Guid FriendId { get; set; }
}
