using Data.Entities;
using Data.Repositories;

namespace Data.Services
{
    public class UserService
    {
        private readonly UserRepository _userRepository;

        public UserService(UserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        // CREATE 
        public async Task<UserEntity> CreateUserAsync(UserEntity user)
        {
            return await _userRepository.CreateAsync(user);
        }

        // READ 
        public async Task<IEnumerable<UserEntity>> GetAllUsersAsync()
        {
            return await _userRepository.GetAllAsync();
        }

        
        public async Task<UserEntity?> GetUserByIdAsync(int id)
        {
            return await _userRepository.GetByIdAsync(id);
        }

        // UPDATE 
        public async Task<UserEntity?> UpdateUserAsync(UserEntity updatedUser)
        {
            return await _userRepository.UpdateAsync(updatedUser);
        }

        // DELETE 
        public async Task<bool> DeleteUserAsync(int id)
        {
            return await _userRepository.DeleteAsync(id);
        }
    }
}
