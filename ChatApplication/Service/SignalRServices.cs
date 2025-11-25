using Microsoft.AspNetCore.SignalR;

namespace ChatApplication.webApi.Service;

public class SignalRServices : Hub
{
    private readonly IHubContext<SignalRServices> _hubContext;

    public SignalRServices(IHubContext<SignalRServices> hubContext)
    {
        _hubContext = hubContext;
    }

    public async Task SendMessageToUserAsync(Guid chatId, Guid userId, string? content, List<string>? images)
    {
        // Evita null reference
        images ??= new List<string>();

        await _hubContext.Clients.Group(chatId.ToString())
            .SendAsync("ReceiveMessage", new
            {
                ChatId = chatId,
                UserId = userId,
                Content = content,
                Images = images
            });
    }
}
