using System.ComponentModel.DataAnnotations;
using System.Runtime.Intrinsics.X86;

namespace ChatApplication.Dommain.Entities;

public class User
{
      [Key]
    public required Guid UserId { get; set; }

    public required string Username { get; set; }

    public required string Password { get; set; }

    public string? Description { get; set; }

    public List<string> Image { get; set; }

    public bool IsValid { get; set; }

    public DateTime CreateData { get; set; }
}
