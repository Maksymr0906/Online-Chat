using Microsoft.EntityFrameworkCore;
using OnlineChat.Data;
using OnlineChat.Models.Domain;
using OnlineChat.Repositories.Interface;
using System;

namespace OnlineChat.Repositories.Implementation
{
    public class ChatRepository : IChatRepository
    {
        private readonly ChatDbContext _context;
        private readonly DbSet<Chat> _chats;

        public ChatRepository(ChatDbContext context)
        {
            _context = context;
            _chats = _context.Set<Chat>();
        }

        public async Task<Chat> CreateAsync(Chat chat)
        {
            await _chats.AddAsync(chat);
            await _context.SaveChangesAsync();
            return chat;
        }

        public async Task<ICollection<Chat>> GetAllAsync()
        {
            return await _chats
                .Include(x => x.Participants)
                .Include(x => x.Messages)
                .ToListAsync();
        }

        public async Task<Chat?> GetByIdAsync(Guid id)
        {
            return await _chats
                .Include(x => x.Participants)
                .Include(x => x.Messages)
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Chat?> UpdateAsync(Chat chat)
        {
            var existingChat = await _chats.Include(x => x.Participants).Include(x => x.Messages).FirstOrDefaultAsync(x => x.Id == chat.Id);
            if (existingChat == null)
            {
                throw new KeyNotFoundException($"Chat with ID {chat.Id} not found.");
            }

            _context.Entry(existingChat).CurrentValues.SetValues(chat);
            await _context.SaveChangesAsync();
            return existingChat;
        }

        public async Task<Chat?> DeleteByIdAsync(Guid id)
        {
            var existingChat = await _chats.Include(x => x.Participants).Include(x => x.Messages).FirstOrDefaultAsync(x => x.Id == id);
            if (existingChat == null)
            {
                throw new KeyNotFoundException($"Chat with ID {id} not found.");
            }

            _chats.Remove(existingChat);
            await _context.SaveChangesAsync();
            return existingChat;
        }
    }
}
