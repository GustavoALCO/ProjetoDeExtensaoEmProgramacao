using ChatApplication.Aplication.DTOs;
using ChatApplication.Dommain.Entities;
using MediatR;

namespace ChatApplication.Aplication.Querys.Users;

public class FindUsers : IRequest<FilterDTO<User>>
{
    public string Username { get; set; }

    public int Page { get; set; }

    public int PageSize { get; set; }
}
