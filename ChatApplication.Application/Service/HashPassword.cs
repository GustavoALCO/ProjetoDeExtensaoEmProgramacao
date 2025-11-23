using ChatApplication.Application.Interfaces;
using ChatApplication.Dommain.Entities;
using Microsoft.AspNetCore.Identity;

namespace ChatApplication.Application.Service;

public class HashPassword : IHashPassword
{

    private readonly PasswordHasher<object> _passwordHasher = new PasswordHasher<object>();

    public string Hash(User user, string password)
    {
        return _passwordHasher.HashPassword(user, password);
    }

    public bool Verify(User user, string Hashpassword, string requestPassword)
    {
        var isvalid = _passwordHasher.VerifyHashedPassword(user, Hashpassword, requestPassword);

        return isvalid == PasswordVerificationResult.Success;
    }
}
