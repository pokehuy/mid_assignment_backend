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

        public async Task<BookBorrowingRequestDetails> GetBookBorrowingRequestDetails(int id)
        {
            return await _bookBorrowingRequestDetailsRepository.GetBookBorrowingRequestDetails(id);
        }

        public async Task<List<BookBorrowingRequestDetails>> GetAllBookBorrowingRequestDetails()
        {
            return await _bookBorrowingRequestDetailsRepository.GetAllBookBorrowingRequestDetails();
        }

        public async Task<BookBorrowingRequestDetails> CreateBookBorrowingRequestDetails(BookBorrowingRequestDetails bookBorrowingRequestDetails)
        {
            if(bookBorrowingRequestDetails == null) return null;
            return await _bookBorrowingRequestDetailsRepository.CreateBookBorrowingRequestDetails(bookBorrowingRequestDetails);
        }

        public async Task<BookBorrowingRequestDetails> UpdateBookBorrowingRequestDetails(BookBorrowingRequestDetails bookBorrowingRequestDetails)
        {
            if(bookBorrowingRequestDetails == null) return null;
            return await _bookBorrowingRequestDetailsRepository.UpdateBookBorrowingRequestDetails(bookBorrowingRequestDetails);
        }
    }
}