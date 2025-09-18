using System.ComponentModel.DataAnnotations;

namespace ChatApplication.Dommain.Entities;

public class MensageStatus
{
    [Key]
    public Guid UserId { get; set; }

    public bool IsReceived { get; set; }

    public DateTime? ReaAt { get; set; }

    public bool ReadMensage { get; set; }
}
