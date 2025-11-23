using ChatApplication.Dommain.Entities;
using MediatR;

namespace ChatApplication.Application.Features.Commands.Mensage;

public class SendMensage : IRequest
{
    public Guid ChatId { get; set; }

    public Guid UserId { get; set; }

    public string? Content { get; set; }

    public List<string>? ImageMensage { get; set; } = new List<string>();

    public DateTime Mensage { get; set; }

    public List<Guid> Users { get; set; }

}
