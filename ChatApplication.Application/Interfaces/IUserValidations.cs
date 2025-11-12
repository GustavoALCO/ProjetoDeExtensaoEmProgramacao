namespace ChatApplication.Aplication.Interfaces;

public interface IUserValidations
{
    public Task<bool> NomeDisponivel(string nome);
}
