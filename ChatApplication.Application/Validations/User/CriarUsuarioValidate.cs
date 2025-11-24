using ChatApplication.Application.Interfaces;
using ChatApplication.Application.Features.Commands.Users;
using ChatApplication.Dommain.Interfaces.User;
using FluentValidation;

namespace ChatApplication.Application.Validations.User;

public class CriarUsuarioValidate : AbstractValidator<CriarUsuario>
{

    public CriarUsuarioValidate(IValidateBase64 validateBase64, IUserValidations userValidations)
    {

        RuleFor(x => x.Username)
            .MustAsync(async (x, cancellationToken) =>
            {
                return await userValidations.NomeDisponivel(x);
            })
            .WithMessage("Usuario com este nome já existente");
        
        RuleFor(x => x.Password)
            .NotEmpty().WithMessage("É obrigatorio passar uma senha")
            .MinimumLength(12).WithMessage("A senha deve conter no minimo 12 caracteres")
            .Matches(@"[A-Z]").WithMessage("A senha deve conter pelo menos uma letra maiúscula.")
            .Matches(@"[a-z]").WithMessage("A senha deve conter pelo menos uma letra minúscula.")
            .Matches(@"\d").WithMessage("A senha deve conter pelo menos um número.")
            .Matches(@"[\!\?\*\.\@\#\$\%\^\&\+\=]").WithMessage("A senha deve conter pelo menos um caractere especial");

        RuleFor(x => x.Image)
            .Must(x => validateBase64.IsValidBase64String(x)).WithMessage("Formato de imagem invalido");

    }


}
