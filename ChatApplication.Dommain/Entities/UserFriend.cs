﻿using System.ComponentModel.DataAnnotations;

namespace ChatApplication.Dommain.Entities;

public class UserFriend
{
    [Key]
    public Guid Id { get; set; }

    public Guid UserId { get; set; }
    public Guid FriendId { get; set; }

    public bool IsAccepted { get; set; } = false; 

    public DateTime CreatedAt { get; set; } 
}
