using OnlineChat.Models.Domain;

namespace OnlineChat.Repositories.Interface
{
    public interface IRepository<TEntity> where TEntity : BaseEntity
    {
        Task<TEntity> CreateAsync(TEntity entity);
        Task<ICollection<TEntity>> GetAllAsync();
        Task<TEntity?> GetByIdAsync(Guid id);
        Task<TEntity?> UpdateAsync(TEntity entity);
        Task<TEntity?> DeleteByIdAsync(Guid id);
    }
}
