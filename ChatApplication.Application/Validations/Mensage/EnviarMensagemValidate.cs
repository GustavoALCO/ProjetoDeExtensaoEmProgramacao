using ChatApplication.Application.Features.Commands.Mensage;
using FluentValidation;

namespace ChatApplication.Application.Validations.Mensage;

public class EnviarMensagemValidate : AbstractValidator<SendMensage>
{
    public EnviarMensagemValidate()
    {
        RuleFor(x => x.ChatId)
            .NotEmpty().WithMessage("O ID do chat é obrigatório.");
    }
}
