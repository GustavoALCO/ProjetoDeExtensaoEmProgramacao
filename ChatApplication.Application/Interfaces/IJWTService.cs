namespace ChatApplication.Application.Interfaces;

public interface IJWTService
{
    string GenerateToken(Guid userId, string userName);
}
