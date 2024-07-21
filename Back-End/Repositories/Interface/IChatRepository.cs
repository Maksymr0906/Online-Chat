using OnlineChat.Models.Domain;

namespace OnlineChat.Repositories.Interface
{
    public interface IChatRepository : IRepository<Chat>
    {
        Task<ICollection<Chat>> GetAllAsync();
        Task<Chat?> GetByIdAsync(Guid id);
    }
}
