using Microsoft.EntityFrameworkCore;
using mid_assignment_backend.Entities;

namespace mid_assignment_backend.Repositories
{
    public class BookRepository : IBookRepository
    
    {
        private readonly ApplicationDbContext _context;

        public BookRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Book>> GetAllBooks(){
            return await _context.Books.ToListAsync();
        }
        public async Task<Book> GetBookById(int id){
            return await _context.Books.FindAsync(id);
        }
        public async Task<Book> CreateBook(Book book){
            if(book == null) throw new ArgumentNullException(nameof(book));
            await _context.Books.AddAsync(book);
            await _context.SaveChangesAsync();
            return book;
        }
        public async Task<Book> UpdateBook(Book book) {
            if(book == null) throw new ArgumentNullException(nameof(book));
            _context.Books.Update(book);
            await _context.SaveChangesAsync();
            return book;
        }
        public async Task<Book> DeleteBook(int id) {
            var book = await _context.Books.FindAsync(id);
            if(book == null) throw new ArgumentNullException(nameof(book));
            _context.Books.Remove(book);
            await _context.SaveChangesAsync();
            return book;
        }
    }
}