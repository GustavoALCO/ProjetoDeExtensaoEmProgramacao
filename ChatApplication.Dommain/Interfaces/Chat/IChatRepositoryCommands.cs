namespace ChatApplication.Infra.Repository.Chat;

public interface IChatRepositoryCommands
{
    public Task CreateChatAsync(Dommain.Entities.Chat chat);

    public Task UpdateChatAsync(Dommain.Entities.Chat chat);

    public Task DeleteChatAsync(Dommain.Entities.Chat chat);

}
