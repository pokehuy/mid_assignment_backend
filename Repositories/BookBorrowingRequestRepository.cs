using Microsoft.EntityFrameworkCore;
using mid_assignment_backend.Entities;

namespace mid_assignment_backend.Repositories
{
    public class BookBorrowingRequestRepository : IBookBorrowingRequestRepository
    {
        private readonly ApplicationDbContext _context;
        public BookBorrowingRequestRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<BookBorrowingRequest> GetBookBorrowingRequest(int id)
        {
            return await _context.BookBorrowingRequests.FindAsync(id);
        }

        public async Task<List<BookBorrowingRequest>> GetAllBookBorrowingRequests()
        {
            return await _context.BookBorrowingRequests.ToListAsync();
        }

        public async Task<BookBorrowingRequest> CreateBookBorrowingRequest(BookBorrowingRequest bookBorrowingRequest)
        {
            if(bookBorrowingRequest == null) throw new ArgumentNullException(nameof(bookBorrowingRequest));
            await _context.BookBorrowingRequests.AddAsync(bookBorrowingRequest);
            await _context.SaveChangesAsync();
            return bookBorrowingRequest;
        }

        public async Task<BookBorrowingRequest> DeleteBookBorrowingRequest(int id)
        {
            var bookBorrowingRequest = await _context.BookBorrowingRequests.FindAsync(id);
            if(bookBorrowingRequest == null) throw new ArgumentNullException(nameof(bookBorrowingRequest));
            _context.BookBorrowingRequests.Remove(bookBorrowingRequest);
            await _context.SaveChangesAsync();
            return bookBorrowingRequest;
        }
    }
}