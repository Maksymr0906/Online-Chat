using OnlineChat.Models.Domain;

namespace OnlineChat.Services.Interface
{
    public interface IChatService
    {
        Task CreateChatAsync(Chat chat);
        Task<ICollection<Chat>> GetChatsAsync();
        Task<Chat?> GetChatByIdAsync(Guid id);
        Task<Chat?> UpdateChatAsync(Chat chat);
        Task<Chat?> DeleteChatAsync(Chat chat);
        Task<Chat?> DeleteChatByIdAsync(Guid id);
    }
}
