using MediatR;

namespace ChatApplication.Application.Features.Commands.Chat;

public class CreateChat : IRequest
{

    public bool IsGroup { get; set; }

    public string? Name { get; set; }

    public string? Description { get; set; }

    public string? Image { get; set; }

   public List<Guid> UsersIds { get; set; }
}
