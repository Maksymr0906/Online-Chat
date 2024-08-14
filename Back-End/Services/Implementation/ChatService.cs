using AutoMapper;
using OnlineChat.Models.Domain;
using OnlineChat.Models.Dto.Chat;
using OnlineChat.Repositories.Interface;
using OnlineChat.Services.Interface;

namespace OnlineChat.Services.Implementation
{
    public class ChatService : IChatService
    {
        private readonly IChatRepository _chatRepository;
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public ChatService(IChatRepository chatRepository, IUserRepository userRepository, IMapper mapper)
        {
            _chatRepository = chatRepository;
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<ChatDto> CreateChatAsync(CreateChatRequestDto request)
        {
            var chat = _mapper.Map<Chat>(request);
            chat = await _chatRepository.CreateAsync(chat);
            return _mapper.Map<ChatDto>(chat);
        }

        public async Task<ICollection<ChatDto>> GetChatsAsync()
        {
            var chats = await _chatRepository.GetAllAsync();
            return _mapper.Map<ICollection<ChatDto>>(chats);
        }

        public async Task<ChatDto?> GetChatByIdAsync(Guid id)
        {
            var chat = await _chatRepository.GetByIdAsync(id);
            return chat != null? _mapper.Map<ChatDto>(chat) : null;
        }

        public async Task<ChatDto?> UpdateChatAsync(Guid id, UpdateChatRequestDto request)
        {
            var chat = await _chatRepository.GetByIdAsync(id);
            if (chat == null)
            {
                throw new KeyNotFoundException($"Chat with ID {id} was not found.");
            }

            _mapper.Map(request, chat);
            chat = await _chatRepository.UpdateAsync(chat);
            return chat != null ? _mapper.Map<ChatDto>(chat) : null;
        }

        public async Task<ChatDto?> DeleteChatByIdAsync(Guid id)
        {
            var chat = await _chatRepository.DeleteByIdAsync(id);
            return chat != null ? _mapper.Map<ChatDto>(chat) : null;
        }

        // Consider create new service for 2 methods below.
        public async Task AddUserToChatAsync(Guid chatId, AddUserToChatRequestDto request)
        {
            var chat = await _chatRepository.GetByIdAsync(chatId);
            if (chat == null)
            {
                throw new KeyNotFoundException("Chat not found");
            }

            var user = await _userRepository.GetByIdAsync(request.UserId);
            if (user == null)
            {
                throw new KeyNotFoundException("User not found");
            }

            chat.Participants.Add(user);
            await _chatRepository.UpdateAsync(chat);
        }

        public async Task RemoveUserFromChatAsync(Guid chatId, RemoveUserFromChatRequestDto request)
        {
            var chat = await _chatRepository.GetByIdAsync(chatId);
            if (chat == null)
            {
                throw new KeyNotFoundException("Chat not found");
            }

            var user = await _userRepository.GetByIdAsync(request.UserId);
            if (user == null)
            {
                throw new KeyNotFoundException("User not found");
            }

            chat.Participants.Remove(user);
            await _chatRepository.UpdateAsync(chat);
        }
    }
}
