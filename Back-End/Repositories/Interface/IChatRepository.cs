using OnlineChat.Models.Domain;

namespace OnlineChat.Repositories.Interface
{
    public interface IChatRepository
    {
        Task<ICollection<Chat>> GetAllAsync();
        Task<Chat?> GetByIdAsync(Guid id);
    }
}
