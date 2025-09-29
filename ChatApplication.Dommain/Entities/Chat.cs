using System.ComponentModel.DataAnnotations;

namespace ChatApplication.Dommain.Entities;

public class Chat
{
    [Key]
    public Guid ChatId { get; set; }

    public bool IsGroup { get; set; }

    public string? Name { get; set; }

    public string? Description { get; set; }

    public List<string> Image { get; set; }

    public List<Mensage> Mensages { get; set; } 

    public ICollection<ChatUsers> ChatUsers { get; set; }
}
