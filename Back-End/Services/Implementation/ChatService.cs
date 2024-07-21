using OnlineChat.Models.Domain;
using OnlineChat.Repositories.Interface;
using OnlineChat.Services.Interface;

namespace OnlineChat.Services.Implementation
{
    public class ChatService : IChatService
    {
        private readonly IChatRepository _repository;

        public ChatService(IChatRepository repository)
        {
            _repository = repository;
        }

        public async Task CreateChatAsync(Chat chat)
        {
            await _repository.CreateAsync(chat);
        }

        public async Task<Chat?> GetChatByIdAsync(Guid id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public async Task<ICollection<Chat>> GetChatsAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<Chat?> UpdateChatAsync(Chat chat)
        {
            return await _repository.UpdateAsync(chat);
        }

        public async Task<Chat?> DeleteChatAsync(Chat chat)
        {
            return await _repository.DeleteAsync(chat);
        }

        public async Task<Chat?> DeleteChatByIdAsync(Guid id)
        {
            return await _repository.DeleteByIdAsync(id);
        }
    }
}
