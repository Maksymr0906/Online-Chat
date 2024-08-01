using OnlineChat.Models.Dto.Message;

namespace OnlineChat.Services.Interface
{
    public interface IMessageService
    {
        Task<MessageDto> CreateMessageAsync(CreateMessageRequestDto request);
        Task<ICollection<MessageDto>> GetMessagesAsync();
        Task<MessageDto?> GetMessageByIdAsync(Guid id);
        Task<MessageDto?> UpdateMessageAsync(Guid id, UpdateMessageRequestDto request);
        Task<MessageDto?> DeleteMessageByIdAsync(Guid id);
        Task<ICollection<MessageDto>> GetAllChatMessages(Guid chatId);
    }
}
