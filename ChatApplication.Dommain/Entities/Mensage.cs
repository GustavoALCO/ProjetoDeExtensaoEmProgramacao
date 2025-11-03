using System.ComponentModel.DataAnnotations;

namespace ChatApplication.Dommain.Entities;

public class Mensage
{
    [Key]
    public Guid MensageId { get; set; }
    
    public Guid ChatId { get; set; }

    public Guid UserId { get; set; }

    public string? Content { get; set; }

    public List<string> ImageMensage { get; set; } = new List<string>();

    public DateTime SendMensage { get; set; }

    public List<MensageStatus> MensageStatus { get; set; }
}
