namespace ChatApplication.Application.Interfaces;

public interface ISignalRServices
{
    public Task SendMensageToUserAsync(Guid chatid, Guid userId, string content, List<string> images);
}
