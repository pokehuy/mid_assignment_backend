using Microsoft.EntityFrameworkCore;
using mid_assignment_backend.Entities;

namespace mid_assignment_backend.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext _context;

        public UserRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<User> GetUserById(int Id)
        {
            return await _context.Users.FindAsync(Id);
        }

        public async Task<List<User>> GetAllUsers()
        {
           return await _context.Users.ToListAsync();
        }

        public async Task<bool> CheckUser(string username, string password)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Username == username && u.Password == password);
            if (user == null)
            {
                return false;
            }
            return true;
        }
    }
}