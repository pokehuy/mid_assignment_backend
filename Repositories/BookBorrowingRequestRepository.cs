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

        public async Task<BookBorrowingRequest> GetBookBorrowingRequestById(int id)
        {
            return await _context.BookBorrowingRequests.FindAsync(id);
        }

        public async Task<List<BookBorrowingRequest>> GetAllBookBorrowingRequests()
        {
            return await _context.BookBorrowingRequests.ToListAsync();
        }

        // public async Task<BookBorrowingRequest> CreateBookBorrowingRequest(BookBorrowingRequest bookBorrowingRequest)
        // {
        //     if(bookBorrowingRequest == null) throw new ArgumentNullException(nameof(bookBorrowingRequest));
        //     await _context.BookBorrowingRequests.AddAsync(bookBorrowingRequest);
        //     await _context.SaveChangesAsync();
        //     return bookBorrowingRequest;
        // }

        //create bookborrowing request with condition: maximum 3 requests per moth for 1 user
        public async Task<BookBorrowingRequest> CreateBookBorrowingRequest(BookBorrowingRequest bookBorrowingRequest, List<BookBorrowingRequestDetails> bookBorrowingRequestDetails)
        {
            if (bookBorrowingRequest == null) throw new ArgumentNullException(nameof(bookBorrowingRequest));
            var listRequestByUser = await _context.BookBorrowingRequests.Where(x => (x.RequestByUserId == bookBorrowingRequest.RequestByUserId) && (x.Date.Month.Equals(bookBorrowingRequest.Date.Month))).ToListAsync();
            if (listRequestByUser.Count >= 3)
            {
                return null;
            }
            else
            {
                if (bookBorrowingRequestDetails.Count() >= 5)
                {
                    return null;
                }
                else
                {
                    await _context.BookBorrowingRequests.AddAsync(bookBorrowingRequest);
                    await _context.SaveChangesAsync();
                    foreach (var item in bookBorrowingRequestDetails)
                    {
                        await _context.BookBorrowingRequestDetailsList.AddAsync(new BookBorrowingRequestDetails{
                            BookBorrowingRequestId = bookBorrowingRequest.Id,
                            BookId = item.BookId
                        });
                        await _context.SaveChangesAsync();
                    }

                    return bookBorrowingRequest;
                }
            }
        }

        public async Task<BookBorrowingRequest> UpdateBookBorrowingRequest(BookBorrowingRequest bookBorrowingRequest)
        {
            if (bookBorrowingRequest == null) throw new ArgumentNullException(nameof(bookBorrowingRequest));
            _context.BookBorrowingRequests.Update(bookBorrowingRequest);
            await _context.SaveChangesAsync();
            return bookBorrowingRequest;
        }


        public async Task<BookBorrowingRequest> DeleteBookBorrowingRequest(int id)
        {
            var bookBorrowingRequest = await _context.BookBorrowingRequests.FindAsync(id);
            if (bookBorrowingRequest == null) throw new ArgumentNullException(nameof(bookBorrowingRequest));
            _context.BookBorrowingRequests.Remove(bookBorrowingRequest);
            await _context.SaveChangesAsync();
            return bookBorrowingRequest;
        }
    }
}