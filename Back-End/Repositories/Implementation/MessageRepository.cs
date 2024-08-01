using Microsoft.EntityFrameworkCore;
using OnlineChat.Data;
using OnlineChat.Models.Domain;
using OnlineChat.Repositories.Interface;

namespace OnlineChat.Repositories.Implementation
{
    public class MessageRepository : IMessageRepository
    {
        private readonly ChatDbContext _context;
        private readonly DbSet<Message> _messages;

        public MessageRepository(ChatDbContext context)
        {
            _context = context;
            _messages = _context.Set<Message>();
        }

        public async Task<Message> CreateAsync(Message message)
        {
            await _messages.AddAsync(message);
            await _context.SaveChangesAsync();
            return message;
        }

        public async Task<ICollection<Message>> GetAllAsync()
        {
            return await _messages.ToListAsync();
        }

        public async Task<Message?> GetByIdAsync(Guid id)
        {
            return await _messages.FindAsync(id);
        }

        public async Task<Message?> UpdateAsync(Message message)
        {
            var existingMessage = await _messages.FindAsync(message.Id);
            if (existingMessage == null)
            {
                throw new KeyNotFoundException($"Message with ID {message.Id} not found.");
            }

            _context.Entry(existingMessage).CurrentValues.SetValues(message);
            await _context.SaveChangesAsync();
            return existingMessage;
        }

        public async Task<Message?> DeleteByIdAsync(Guid id)
        {
            var existingMessage = await _messages.FindAsync(id);
            if (existingMessage == null)
            {
                throw new KeyNotFoundException($"Message with ID {id} not found.");
            }

            _messages.Remove(existingMessage);
            await _context.SaveChangesAsync();
            return existingMessage;
        }

        public async Task<ICollection<Message>> GetAllChatMessagesAsync(Guid chatId)
        {
            return await _messages.Where(x => x.ChatId == chatId).ToListAsync();
        }
    }
}
