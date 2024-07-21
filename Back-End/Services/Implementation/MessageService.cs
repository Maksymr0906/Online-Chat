using OnlineChat.Models.Domain;
using OnlineChat.Repositories.Interface;
using OnlineChat.Services.Interface;

namespace OnlineChat.Services.Implementation
{
    public class MessageService : IMessageService
    {
        private readonly IRepository<Message> _repository;

        public MessageService(IRepository<Message> repository)
        {
            _repository = repository;
        }

        public async Task CreateMessageAsync(Message message)
        {
            await _repository.CreateAsync(message);
        }

        public async Task<Message?> GetMessageByIdAsync(Guid id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public async Task<ICollection<Message>> GetMessagesAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<Message?> UpdateMessageAsync(Message message)
        {
            return await _repository.UpdateAsync(message);
        }

        public async Task<Message?> DeleteMessageAsync(Message message)
        {
            return await _repository.DeleteAsync(message);
        }

        public async Task<Message?> DeleteMessageByIdAsync(Guid id)
        {
            return await _repository.DeleteByIdAsync(id);
        }
    }
}
