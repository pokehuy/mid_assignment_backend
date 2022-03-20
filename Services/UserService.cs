using mid_assignment_backend.Repositories;
using mid_assignment_backend.Entities;

namespace mid_assignment_backend.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<User> GetUserById(int id)
        {
            return await _userRepository.GetUserById(id);
        }

        public async Task<List<User>> GetAllUsers()
        {
            return await _userRepository.GetAllUsers();
        }

        public async Task<User> CreateUser(User user)
        {
            if (user == null) return null;
            return await _userRepository.CreateUser(user);
        }

        public async Task<User> UpdateUser(User user)
        {
            if (user == null) return null;
            return await _userRepository.UpdateUser(user);
        }

        public async Task<User> DeleteUser(int id)
        {
            return await _userRepository.DeleteUser(id);
        }
    }
}