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

        public async Task<User> CreateUser(User user){
            if(user == null) throw new ArgumentNullException(nameof(user));
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();
            return user;
        }
        public async Task<User> UpdateUser(User user){
            if(user == null) throw new ArgumentNullException(nameof(user));
            _context.Users.Update(user);
            await _context.SaveChangesAsync();
            return user;
        }
        public async Task<User> DeleteUser(int id){
            var user = await _context.Users.FindAsync(id);
            if(user == null) throw new ArgumentNullException(nameof(user));
            _context.Users.Remove(user);
            await _context.SaveChangesAsync();
            return user;
        }
    }
}