using OnlineChat.Models.Domain;
using OnlineChat.Models.Dto.User;
using OnlineChat.Repositories.Interface;
using OnlineChat.Services.Interface;
using AutoMapper;

namespace OnlineChat.Services.Implementation
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _repository;
        private readonly IMapper _mapper;

        public UserService(IUserRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<UserDto> CreateUserAsync(CreateUserRequestDto request)
        {
            var user = _mapper.Map<User>(request);
            user = await _repository.CreateAsync(user);
            return _mapper.Map<UserDto>(user);
        }

        public async Task<ICollection<UserDto>> GetUsersAsync()
        {
            var users = await _repository.GetAllAsync();
            return _mapper.Map<ICollection<UserDto>>(users);
        }

        public async Task<UserDto?> GetUserByIdAsync(Guid id)
        {
            var user = await _repository.GetByIdAsync(id);
            return user != null ? _mapper.Map<UserDto>(user) : null;
        }

        public async Task<UserDto?> UpdateUserAsync(Guid id, UpdateUserRequestDto request)
        {
            var user = await _repository.GetByIdAsync(id);
            if (user == null)
            {
                throw new KeyNotFoundException($"User with ID {id} was not found.");
            }

            _mapper.Map(request, user);
            user = await _repository.UpdateAsync(user);

            return _mapper.Map<UserDto>(user);
        }

        public async Task<UserDto?> DeleteUserByIdAsync(Guid id)
        {
            var user = await _repository.DeleteByIdAsync(id);
            return _mapper.Map<UserDto>(user);
        }
    }
}
