using Microsoft.EntityFrameworkCore;
using OnlineChat.Data;
using OnlineChat.Models.Domain;
using OnlineChat.Repositories.Interface;

namespace OnlineChat.Repositories.Implementation
{
    public class GenericRepository<TEntity> : IRepository<TEntity> where TEntity : BaseEntity
    {
        private readonly ChatDbContext _context;
        private readonly DbSet<TEntity> _entities;

        public GenericRepository(ChatDbContext context)
        {
            _context = context;
            _entities = _context.Set<TEntity>();
        }

        public async Task CreateAsync(TEntity entity)
        {
            ArgumentNullException.ThrowIfNull(entity);

            await _entities.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<ICollection<TEntity>> GetAllAsync()
        {
            return await _entities.ToListAsync();
        }

        public async Task<TEntity?> GetByIdAsync(Guid id)
        {
            return await _entities.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<TEntity?> UpdateAsync(TEntity entity)
        {
            ArgumentNullException.ThrowIfNull(entity);

            var existingEntity = await _entities.FirstOrDefaultAsync(x => x.Id == entity.Id);
            if (existingEntity == null)
            {
                throw new KeyNotFoundException($"Entity with ID {entity.Id} was not found.");
            }

            _context.Entry(existingEntity).CurrentValues.SetValues(entity);
            await _context.SaveChangesAsync();
            return existingEntity;
        }

        public async Task<TEntity?> DeleteAsync(TEntity entity)
        {
            ArgumentNullException.ThrowIfNull(entity);
            _context.Remove(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<TEntity?> DeleteByIdAsync(Guid id)
        {
            var entity = await _entities.FirstOrDefaultAsync(x => x.Id == id);
            if (entity == null)
            {
                throw new KeyNotFoundException($"Entity with ID {id} was not found.");
            }

            _context.Remove(entity);
            await _context.SaveChangesAsync();
            return entity;
        }
    }
}
