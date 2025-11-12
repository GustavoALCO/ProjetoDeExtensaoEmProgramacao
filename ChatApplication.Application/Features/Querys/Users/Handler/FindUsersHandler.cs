using ChatApplication.Aplication.DTOs;
using ChatApplication.Aplication.Features.Querys.Users;
using ChatApplication.Dommain.Entities;
using ChatApplication.Dommain.Interfaces.User;
using MediatR;

namespace ChatApplication.Aplication.Features.Querys.Users.Handler;

public class FindUsersHandler : IRequestHandler<FindUsers, FilterDTO<UsersDTO>>
{

    private readonly IUserRepositoryQuery _context;

    public FindUsersHandler(IUserRepositoryQuery context)
    {
        _context = context;
    }

    public async Task<FilterDTO<UsersDTO>> Handle(FindUsers request, CancellationToken cancellationToken)
    {
        var (users, totalusers) = await _context.GetUsers(request.Username, request.Page, request.PageSize);

        double totalpages = totalusers / request.PageSize;


        var usersDto = users.Select(u => new UsersDTO
        {
            UserId = u.UserId,
            Username = u.Username,
            Description = u.Description,
            Image = u.Image
        }).ToList();

        var filter = new FilterDTO<UsersDTO>()
        {
            Page = request.Page,
            PageSize = request.PageSize,
            TotalItems = totalusers,

            //Arredonda sempre para cima, dando a opção sempre de criar mais uma pagina.
            TotalPages = (int)Math.Ceiling(totalpages),
            Data = usersDto
            
        };

        return filter;
    }
}
