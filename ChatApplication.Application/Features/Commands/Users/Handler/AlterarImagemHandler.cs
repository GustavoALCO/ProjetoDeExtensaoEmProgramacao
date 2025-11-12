using ChatApplication.Dommain.Interfaces.User;
using MediatR;

namespace ChatApplication.Aplication.Features.Commands.Users.Handler;

public class AlterarImagemHandler : IRequestHandler<AlterarImagem>
{
    private readonly IUserRepositoryCommands _commands;

    public AlterarImagemHandler(IUserRepositoryCommands commands)
    {
        _commands = commands;
    }

    public Task Handle(AlterarImagem request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
