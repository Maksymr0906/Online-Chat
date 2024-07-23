using AutoMapper;
using OnlineChat.Models.Domain;
using OnlineChat.Models.Dto.Message;
using OnlineChat.Repositories.Interface;
using OnlineChat.Services.Interface;

namespace OnlineChat.Services.Implementation
{
    public class MessageService : IMessageService
    {
        private readonly IMessageRepository _repository;
        private readonly IMapper _mapper;

        public MessageService(IMessageRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<MessageDto> CreateMessageAsync(CreateMessageRequestDto request)
        {
            var message = _mapper.Map<Message>(request);
            message = await _repository.CreateAsync(message);
            return _mapper.Map<MessageDto>(message);
        }

        public async Task<ICollection<MessageDto>> GetMessagesAsync()
        {
            var messages = await _repository.GetAllAsync();
            return _mapper.Map<ICollection<MessageDto>>(messages);
        }
        public async Task<MessageDto?> GetMessageByIdAsync(Guid id)
        {
            var message = await _repository.GetByIdAsync(id);
            return message != null? _mapper.Map<MessageDto>(message) : null;
        }

        public async Task<MessageDto?> UpdateMessageAsync(Guid id, UpdateMessageRequestDto request)
        {
            var message = await _repository.GetByIdAsync(id);
            if (message == null)
            {
                throw new KeyNotFoundException($"Message with ID {id} was not found.");
            }

            _mapper.Map(request, message);
            message = await _repository.UpdateAsync(message);

            return _mapper.Map<MessageDto>(message);
        }

        public async Task<MessageDto?> DeleteMessageByIdAsync(Guid id)
        {
            var message = await _repository.DeleteByIdAsync(id);
            return _mapper.Map<MessageDto>(message);
        }
    }
}
