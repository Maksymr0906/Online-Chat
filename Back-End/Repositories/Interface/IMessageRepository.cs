using OnlineChat.Models.Domain;

namespace OnlineChat.Repositories.Interface
{
    public interface IMessageRepository
    {
        Task<Message> CreateAsync(Message message);
        Task<ICollection<Message>> GetAllAsync();
        Task<Message?> GetByIdAsync(Guid id);
        Task<Message?> UpdateAsync(Message message);
        Task<Message?> DeleteByIdAsync(Guid id);
    }
}
