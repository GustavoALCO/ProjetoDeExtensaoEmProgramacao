namespace ChatApplication.Application.DTOs;

public class MensageDTO
{
    public Guid MensageId { get; set; }

    public Guid ChatId { get; set; }

    public Guid UserId { get; set; }

    public string? Content { get; set; }

    public List<string> ImageMensage { get; set; } = new List<string>();

    public DateTime SendMensage { get; set; }

    public List<MensageStatusDTO> MensageStatus { get; set; }
}
