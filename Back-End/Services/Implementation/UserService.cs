using OnlineChat.Models.Domain;
using OnlineChat.Repositories.Interface;
using OnlineChat.Services.Interface;

namespace OnlineChat.Services.Implementation
{
    public class UserService : IUserService
    {
        private readonly IRepository<User> _repository;

        public UserService(IRepository<User> repository)
        {
            _repository = repository;
        }

        public async Task CreateUserAsync(User user)
        {
            await _repository.CreateAsync(user);
        }
        
        public async Task<User?> GetUserByIdAsync(Guid id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public async Task<ICollection<User>> GetUsersAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<User?> UpdateUserAsync(User user)
        {
            return await _repository.UpdateAsync(user);
        }

        public async Task<User?> DeleteUserAsync(User user)
        {
            return await _repository.DeleteAsync(user);
        }

        public async Task<User?> DeleteUserByIdAsync(Guid id)
        {
            return await _repository.DeleteByIdAsync(id);
        }
    }
}
