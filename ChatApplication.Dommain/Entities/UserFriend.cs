using System.ComponentModel.DataAnnotations;

namespace ChatApplication.Dommain.Entities;

public class UserFriend
{
    public Guid UserId { get; set; }

    public Guid FriendId { get; set; }

    public bool? IsAccepted { get; set; } 

    public bool? IsBlocked { get; set; }

    public bool? IsRequest { get; set; }

    public DateTime CreatedAt { get; set; } 

}
