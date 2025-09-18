using System.ComponentModel.DataAnnotations;

namespace ChatApplication.Dommain.Entities;

public class Mensage
{
    [Key]
    public int MensageId { get; set; }

    public Guid UserId { get; set; }

    public string? Content { get; set; }

    public List<string> ImageMensage { get; set; }

    public DateTime SendMensage { get; set; }

    public List<MensageStatus> MensageStatus { get; set; }
}
