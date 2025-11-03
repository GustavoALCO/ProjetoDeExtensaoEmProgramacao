using System.ComponentModel.DataAnnotations;

namespace ChatApplication.Dommain.Entities;

public class MensageStatus
{
    public Guid MensageID { get; set; }

    public Guid RecibeUserId { get; set; }

    public bool IsReceived { get; set; }

    public DateTime? ReaAt { get; set; }
}
