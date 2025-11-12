using ChatApplication.Aplication.DTOs;
using MediatR;

namespace ChatApplication.Aplication.Features.Querys.Chats;

public class FindChatID : IRequest<ChatDTO>
{
    public Guid IdChat {  get; set; }

    public int TakeMensages { get; set; }
}
