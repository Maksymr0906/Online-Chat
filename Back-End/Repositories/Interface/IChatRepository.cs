using OnlineChat.Models.Domain;

namespace OnlineChat.Repositories.Interface
{
    public interface IChatRepository
    {
        Task<Chat> CreateAsync(Chat chat);
        Task<ICollection<Chat>> GetAllAsync();
        Task<Chat?> GetByIdAsync(Guid id);
        Task<Chat?> UpdateAsync(Chat chat);
        Task<Chat?> DeleteByIdAsync(Guid id);
    }
}
