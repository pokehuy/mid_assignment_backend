using mid_assignment_backend.Repositories;
using mid_assignment_backend.Entities;

namespace mid_assignment_backend.Services
{
    public class BookBorrowingRequestDetailsService : IBookBorrowingRequestDetailsService 
    {
        private readonly IBookBorrowingRequestDetailsRepository _bookBorrowingRequestDetailsRepository;

        public BookBorrowingRequestDetailsService(IBookBorrowingRequestDetailsRepository bookBorrowingRequestDetailsRepository)
        {
            _bookBorrowingRequestDetailsRepository = bookBorrowingRequestDetailsRepository;
        }

        public async Task<BookBorrowingRequestDetails> GetBookBorrowingRequestDetailsById(int requestId,int bookId)
        {
            return await _bookBorrowingRequestDetailsRepository.GetBookBorrowingRequestDetailsById(requestId, bookId);
        }

        public async Task<List<BookBorrowingRequestDetails>> GetAllBookBorrowingRequestDetails()
        {
            return await _bookBorrowingRequestDetailsRepository.GetAllBookBorrowingRequestDetails();
        }

/*
        public async Task<BookBorrowingRequestDetails> CreateBookBorrowingRequestDetails(BookBorrowingRequestDetails bookBorrowingRequestDetails)
        {
            if(bookBorrowingRequestDetails == null) return null;
            return await _bookBorrowingRequestDetailsRepository.CreateBookBorrowingRequestDetails(bookBorrowingRequestDetails);
        }
*/
        public async Task<BookBorrowingRequestDetails> UpdateBookBorrowingRequestDetails(BookBorrowingRequestDetails bookBorrowingRequestDetails)
        {
            if(bookBorrowingRequestDetails == null) return null;
            return await _bookBorrowingRequestDetailsRepository.UpdateBookBorrowingRequestDetails(bookBorrowingRequestDetails);
        }

        public async Task<BookBorrowingRequestDetails> DeleteBookBorrowingRequestDetails(int id)
        {
            return await _bookBorrowingRequestDetailsRepository.DeleteBookBorrowingRequestDetails(id);
        }
    }
}