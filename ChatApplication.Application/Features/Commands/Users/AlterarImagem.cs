using MediatR;

namespace ChatApplication.Application.Features.Commands.Users;

public class AlterarImagem : IRequest
{
    public required Guid IdUser { get; set; }

    public required string Base64Image { get; set; }

}
