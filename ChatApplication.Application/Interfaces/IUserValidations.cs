namespace ChatApplication.Application.Interfaces;

public interface IUserValidations
{
    public Task<bool> NomeDisponivel(string nome);
}
