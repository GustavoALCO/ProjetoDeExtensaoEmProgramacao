namespace ChatApplication.Aplication.Interfaces;

public interface IValidateBase64
{
    public bool ListIsValidBase64String(List<string> base64String);

    public bool IsValidBase64String(string base64String);
}
