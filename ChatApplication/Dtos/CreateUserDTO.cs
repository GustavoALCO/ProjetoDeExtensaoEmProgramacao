namespace ChatApplication.webApi.Dtos;

public class CreateUserDTO
{
    public string Username { get; set; }
    public string Password { get; set; }
    public string Description { get; set; }
    public string Image { get; set; }
}
