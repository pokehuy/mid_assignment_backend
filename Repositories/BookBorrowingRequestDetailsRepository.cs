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

        public async Task<BookBorrowingRequestDetails> GetBookBorrowingRequestDetailsById(int id)
        {
            return await _context.BookBorrowingRequestDetailsList.FindAsync(id);
        }

        public async Task<List<BookBorrowingRequestDetails>> GetAllBookBorrowingRequestDetails()
        {
            return await _context.BookBorrowingRequestDetailsList.ToListAsync();
        }

        // public async Task<BookBorrowingRequestDetails> CreateBookBorrowingRequestDetails(BookBorrowingRequestDetails bookBorrowingRequestDetails)
        // {
        //     if(bookBorrowingRequestDetails == null) throw new ArgumentNullException(nameof(bookBorrowingRequestDetails));
        //     await _context.BookBorrowingRequestDetailsList.AddAsync(bookBorrowingRequestDetails);
        //     await _context.SaveChangesAsync();
        //     return bookBorrowingRequestDetails;
        // }

        // create bookborrowing request details with condition: maximum 5 books per borrowing
        public async Task<BookBorrowingRequestDetails> CreateBookBorrowingRequestDetails(BookBorrowingRequestDetails bookBorrowingRequestDetails)
        {
            if (bookBorrowingRequestDetails == null) throw new ArgumentNullException(nameof(bookBorrowingRequestDetails));
            var listRequestByUser = await _context.BookBorrowingRequestDetailsList.Where(x => x.BookBorrowingRequestId == bookBorrowingRequestDetails.BookBorrowingRequestId).ToListAsync();
            if (listRequestByUser.Count < 5)
            {
                await _context.BookBorrowingRequestDetailsList.AddAsync(bookBorrowingRequestDetails);
                await _context.SaveChangesAsync();
                return bookBorrowingRequestDetails;
            }
            else
            {
                return null;
            }
        }

        public async Task<BookBorrowingRequestDetails> UpdateBookBorrowingRequestDetails(BookBorrowingRequestDetails bookBorrowingRequestDetails)
        {
            if (bookBorrowingRequestDetails == null) throw new ArgumentNullException(nameof(bookBorrowingRequestDetails));
            _context.BookBorrowingRequestDetailsList.Update(bookBorrowingRequestDetails);
            await _context.SaveChangesAsync();
            return bookBorrowingRequestDetails;
        }

        public async Task<BookBorrowingRequestDetails> DeleteBookBorrowingRequestDetails(int id)
        {
            var bookBorrowingRequestDetails = await _context.BookBorrowingRequestDetailsList.FindAsync(id);
            if (bookBorrowingRequestDetails == null) throw new ArgumentNullException(nameof(bookBorrowingRequestDetails));
            _context.BookBorrowingRequestDetailsList.Remove(bookBorrowingRequestDetails);
            await _context.SaveChangesAsync();
            return bookBorrowingRequestDetails;
        }

    }
}