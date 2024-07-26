using AutoMapper;
using OnlineChat.Models.Domain;
using OnlineChat.Models.Dto.Chat;
using OnlineChat.Repositories.Interface;
using OnlineChat.Services.Interface;

namespace OnlineChat.Services.Implementation
{
    public class ChatService : IChatService
    {
        private readonly IChatRepository _repository;
        private readonly IMapper _mapper;

        public ChatService(IChatRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<ChatDto> CreateChatAsync(CreateChatRequestDto request)
        {
            var chat = _mapper.Map<Chat>(request);
            chat = await _repository.CreateAsync(chat);
            return _mapper.Map<ChatDto>(chat);
        }

        public async Task<ICollection<ChatDto>> GetChatsAsync()
        {
            var chats = await _repository.GetAllAsync();
            return _mapper.Map<ICollection<ChatDto>>(chats);
        }

        public async Task<ChatDto?> GetChatByIdAsync(Guid id)
        {
            var chat = await _repository.GetByIdAsync(id);
            return chat != null? _mapper.Map<ChatDto>(chat) : null;
        }

        public async Task<ChatDto?> UpdateChatAsync(Guid id, UpdateChatRequestDto request)
        {
            var chat = await _repository.GetByIdAsync(id);
            if (chat == null)
            {
                throw new KeyNotFoundException($"Chat with ID {id} was not found.");
            }

            _mapper.Map(request, chat);
            chat = await _repository.UpdateAsync(chat);
            return chat != null ? _mapper.Map<ChatDto>(chat) : null;
        }

        public async Task<ChatDto?> DeleteChatByIdAsync(Guid id)
        {
            var chat = await _repository.DeleteByIdAsync(id);
            return chat != null ? _mapper.Map<ChatDto>(chat) : null;
        }

        public async Task<ICollection<ChatWithCreatorDto>> GetChatsWithCreatorAsync()
        {
            var chats = await _repository.GetAllAsync();
            return _mapper.Map<ICollection<ChatWithCreatorDto>>(chats);
        }
    }
}
