using Microsoft.EntityFrameworkCore;
using mid_assignment_backend.Entities;

namespace mid_assignment_backend.Repositories
{
    public class BookBorrowingRequestDetailsRepository : IBookBorrowingRequestDetailsRepository
    {
        private readonly ApplicationDbContext _context;
        public BookBorrowingRequestDetailsRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<BookBorrowingRequestDetails> GetBookBorrowingRequestDetails(int id)
        {
            return await _context.BookBorrowingRequestDetails.FindAsync(id);
        }

        public async Task<List<BookBorrowingRequestDetails>> GetAllBookBorrowingRequestDetails()
        {
            return await _context.BookBorrowingRequestDetails.ToListAsync();
        }

        public async Task<BookBorrowingRequestDetails> CreateBookBorrowingRequestDetails(BookBorrowingRequestDetails bookBorrowingRequestDetails)
        {
            if(bookBorrowingRequestDetails == null) throw new ArgumentNullException(nameof(bookBorrowingRequestDetails));
            await _context.BookBorrowingRequestDetails.AddAsync(bookBorrowingRequestDetails);
            await _context.SaveChangesAsync();
            return bookBorrowingRequestDetails;
        }

        public async Task<BookBorrowingRequestDetails> UpdateBookBorrowingRequestDetails(BookBorrowingRequestDetails bookBorrowingRequestDetails)
        {
            if(bookBorrowingRequestDetails == null) throw new ArgumentNullException(nameof(bookBorrowingRequestDetails));
            _context.BookBorrowingRequestDetails.Update(bookBorrowingRequestDetails);
            await _context.SaveChangesAsync();
            return bookBorrowingRequestDetails;
        }
    }
}