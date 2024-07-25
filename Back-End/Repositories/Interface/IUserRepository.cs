using OnlineChat.Models.Domain;

namespace OnlineChat.Repositories.Interface
{
    public interface IUserRepository
    {
        Task<User> CreateAsync(User user);
        Task<ICollection<User>> GetAllAsync();
        Task<User?> GetByIdAsync(Guid id);
        Task<User?> UpdateAsync(User user);
        Task<User?> DeleteByIdAsync(Guid id);
        Task<User?> GetByName(string name);
    }
}
