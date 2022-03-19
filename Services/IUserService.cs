using mid_assignment_backend.Entities;

namespace mid_assignment_backend.Services
{
    public interface IUserService
    {
        Task<User> GetUserById(int id);
        Task<List<User>> GetAllUsers();

        Task<bool> CheckUser(string username, string password);
    }
}