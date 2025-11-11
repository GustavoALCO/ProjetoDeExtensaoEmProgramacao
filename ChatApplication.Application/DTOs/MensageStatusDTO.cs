using ChatApplication.Dommain.Entities;

namespace ChatApplication.Aplication.DTOs;

public class MensageStatusDTO
{
    public UsersDTO User { get; set; }

    public bool IsReceived { get; set; }

    public DateTime? ReaAt { get; set; }
}
