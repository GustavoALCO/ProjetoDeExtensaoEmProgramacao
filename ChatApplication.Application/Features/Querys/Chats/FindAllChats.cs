using ChatApplication.Application.DTOs;
using MediatR;

namespace ChatApplication.Aplication.Features.Querys.Chats;

public class FindAllChats : IRequest<FilterDTO<ChatDTO>>
{
    public Guid IdUser { get; set; }

    public int TakeMensages { get; set; }

    public int Page { get; set; }

    public int PageSize { get; set; }
}
