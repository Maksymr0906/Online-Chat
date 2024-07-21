using OnlineChat.Models.Domain;

namespace OnlineChat.Services.Interface
{
    public interface IUserService
    {
        Task CreateUserAsync(User user);
        Task<ICollection<User>> GetUsersAsync();
        Task<User?> GetUserByIdAsync(Guid id);
        Task<User?> UpdateUserAsync(User user);
        Task<User?> DeleteUserAsync(User user);
        Task<User?> DeleteUserByIdAsync(Guid id);
    }
}
