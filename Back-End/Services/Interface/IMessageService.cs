using OnlineChat.Models.Domain;

namespace OnlineChat.Services.Interface
{
    public interface IMessageService
    {
        Task CreateMessageAsync(Message message);
        Task<ICollection<Message>> GetMessagesAsync();
        Task<Message?> GetMessageByIdAsync(Guid id);
        Task<Message?> UpdateMessageAsync(Message message);
        Task<Message?> DeleteMessageByIdAsync(Guid id);
    }
}
