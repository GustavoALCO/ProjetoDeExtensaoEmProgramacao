using ChatApplication.Aplication.DTOs;
using ChatApplication.Dommain.Entities;
using MediatR;

namespace ChatApplication.Aplication.Querys.Chats;

public class FindNameChats : IRequest<FilterDTO<ChatDTO>>
{
    public Guid IdUser { get; set; }

    public string Name { get; set; }

    public int TakeMensages { get; set; }

    public int Page { get; set; }

    public int PageSize { get; set; }
}
