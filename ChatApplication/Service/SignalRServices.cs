using Microsoft.AspNetCore.SignalR;

namespace ChatApplication.webApi.Service;

public class SignalRServices : Hub
{
   
    public async Task SendMensageToUserAsync(Guid chatid, Guid userId, string? content, List<string>? images)
    {
        await Clients.Group(chatid.ToString())
            .SendAsync("ReceiveMensage", new
            {
                ChatId = chatid,
                UserId = userId,
                Content = content,
                Images = images
            });
    }
}
