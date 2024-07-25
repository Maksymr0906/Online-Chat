using OnlineChat.Models.Dto.User;

namespace OnlineChat.Services.Interface
{
    public interface IUserService
    {
        Task<UserDto> CreateUserAsync(CreateUserRequestDto request);
        Task<ICollection<UserDto>> GetUsersAsync();
        Task<UserDto?> GetUserByIdAsync(Guid id);
        Task<UserDto?> UpdateUserAsync(Guid id, UpdateUserRequestDto request);
        Task<UserDto?> DeleteUserByIdAsync(Guid id);
        Task<UserDto?> GetUserByName(string name);
    }
}
