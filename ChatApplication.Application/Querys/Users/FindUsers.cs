using ChatApplication.Aplication.DTOs;
using MediatR;

namespace ChatApplication.Aplication.Querys.Users;

public class FindUsers : IRequest<FilterDTO<UsersDTO>>
{
    public string Username { get; set; }

    public int Page { get; set; }

    public int PageSize { get; set; }
}
