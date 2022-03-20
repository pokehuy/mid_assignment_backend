using mid_assignment_backend.Entities;

namespace mid_assignment_backend.Services
{
    public interface IBookBorrowingRequestService
    {
        Task<BookBorrowingRequest> GetBookBorrowingRequestById(int id);
        Task<List<BookBorrowingRequest>> GetAllBookBorrowingRequests();
        Task<BookBorrowingRequest> CreateBookBorrowingRequest(BookBorrowingRequest bookBorrowingRequest);
        Task<BookBorrowingRequest> UpdateBookBorrowingRequest(BookBorrowingRequest bookBorrowingRequest);
        Task<BookBorrowingRequest> DeleteBookBorrowingRequest(int id);
    }
}