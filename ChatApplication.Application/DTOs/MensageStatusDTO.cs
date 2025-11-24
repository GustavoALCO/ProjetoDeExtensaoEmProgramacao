namespace ChatApplication.Application.DTOs;

public class MensageStatusDTO
{
    public UsersDTO User { get; set; }

    public bool IsReceived { get; set; }

    public DateTime? ReaAt { get; set; }
}
