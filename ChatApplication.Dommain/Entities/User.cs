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

    public string? Image { get; set; }

    public bool IsValid { get; set; } = true;

    public DateTime CreateData { get; set; }

    public ICollection<ChatUsers> ChatUsers { get; set; }

    public ICollection<UserFriend> Friends { get; set; }

    // Solicitações recebidas
    public ICollection<UserFriend> FriendOf { get; set; }
}
