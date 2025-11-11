using ChatApplication.Dommain.Entities;

namespace ChatApplication.Aplication.DTOs;

public class ChatDTO
{
    public Guid ChatId { get; set; }

    public bool IsGroup { get; set; }

    public string Name { get; set; }

    public string? Description { get; set; }

    public string? Image { get; set; }

    public List<Mensage> Mensages { get; set; }
}
