using ChatApplication.Application.Hubs;
using ChatApplication.Application.Interfaces;
using Microsoft.AspNetCore.SignalR;

namespace ChatApplication.Application.Service;

public class SignalRServices : ISignalRServices
{
    private readonly IHubContext<ChatHubs> _hubContext;

    public SignalRServices(IHubContext<ChatHubs> hubContext)
    {
        _hubContext = hubContext;
    }

    public async Task SendMensageToUserAsync(Guid chatid, Guid userId, string content, List<string> images)
    {
        await _hubContext.Clients.Group(chatid.ToString())
            .SendAsync("ReceiveMensage", new
            {
                ChatId = chatid,
                UserId = userId,
                Content = content,
                Images = images
            });
    }
}
