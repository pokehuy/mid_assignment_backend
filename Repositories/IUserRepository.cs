using mid_assignment_backend.Entities;

namespace mid_assignment_backend.Repositories
{
    public interface IUserRepository
    {
        Task<User> GetUserById(int id);
        Task<List<User>> GetAllUsers();
        Task<User> CreateUser(User user);
        Task<User> UpdateUser(User user);
        Task<User> DeleteUser(int id);
    }
}