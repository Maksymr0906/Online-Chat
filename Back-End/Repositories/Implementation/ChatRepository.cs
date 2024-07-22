using Microsoft.EntityFrameworkCore;
using OnlineChat.Data;
using OnlineChat.Models.Domain;
using OnlineChat.Repositories.Interface;

namespace OnlineChat.Repositories.Implementation
{
    public class ChatRepository : GenericRepository<Chat>
    {
        public ChatRepository(ChatDbContext context) 
            : base(context)
        {
        }

        public new async Task<ICollection<Chat>> GetAllAsync()
        {
            return await _entities.Include(x => x.Participants).Include(x => x.Messages).ToListAsync();
        }

        public new async Task<Chat?> GetByIdAsync(Guid id)
        {
            return await _entities
                .Include(x => x.Participants)
                .Include(x => x.Messages)
                .FirstOrDefaultAsync(x => x.Id == id);
        }
    }
}
