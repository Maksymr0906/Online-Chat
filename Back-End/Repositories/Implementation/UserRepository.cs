using Microsoft.EntityFrameworkCore;
using OnlineChat.Data;
using OnlineChat.Models.Domain;
using OnlineChat.Repositories.Interface;

namespace OnlineChat.Repositories.Implementation
{
    public class UserRepository : IUserRepository
    {
        private readonly ChatDbContext _context;
        private readonly DbSet<User> _users;

        public UserRepository(ChatDbContext context)
        {
            _context = context;
            _users = _context.Set<User>();
        }

        public async Task<User> CreateAsync(User user)
        {
            await _users.AddAsync(user);
            await _context.SaveChangesAsync();
            return user;
        }

        public async Task<ICollection<User>> GetAllAsync()
        {
            return await _users
                .Include(x => x.ParticipatingChats)
                .Include(x => x.CreatedChats)
                .Include(x => x.Messages)
                .ToListAsync();
        }

        public async Task<User?> GetByIdAsync(Guid id)
        {
            return await _users.FindAsync(id);
        }

        public async Task<User?> UpdateAsync(User user)
        {
            var existingUser = await _users.FindAsync(user.Id);
            if (existingUser == null)
            {
                throw new KeyNotFoundException($"User with ID {user.Id} not found.");
            }

            _context.Entry(existingUser).CurrentValues.SetValues(user);
            await _context.SaveChangesAsync();
            return existingUser;
        }

        public async Task<User?> DeleteByIdAsync(Guid id)
        {
            var existingUser = await _users.FindAsync(id);
            if (existingUser == null)
            {
                throw new KeyNotFoundException($"User with ID {id} not found.");
            }

            _users.Remove(existingUser);
            await _context.SaveChangesAsync();
            return existingUser;
        }
    }
}
