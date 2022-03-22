using mid_assignment_backend.Repositories;
using mid_assignment_backend.Entities;

namespace mid_assignment_backend.Services
{
    public class BookBorrowingRequestService : IBookBorrowingRequestService
    {
        private readonly IBookBorrowingRequestRepository _bookBorrowingRequestRepository;

        public BookBorrowingRequestService(IBookBorrowingRequestRepository bookBorrowingRequestRepository)
        {
            _bookBorrowingRequestRepository = bookBorrowingRequestRepository;
        }

        public async Task<List<BookBorrowingRequest>> GetAllBookBorrowingRequests()
        {
            return await _bookBorrowingRequestRepository.GetAllBookBorrowingRequests();
        }

        public async Task<BookBorrowingRequest> GetBookBorrowingRequestById(int id)
        {
            return await _bookBorrowingRequestRepository.GetBookBorrowingRequestById(id);
        }

        public async Task<BookBorrowingRequest> CreateBookBorrowingRequest(BookBorrowingRequest bookBorrowingRequest, List<BookBorrowingRequestDetails> bookBorrowingRequestDetails)
        {
            if(bookBorrowingRequest == null && bookBorrowingRequestDetails == null) return null;
            return await _bookBorrowingRequestRepository.CreateBookBorrowingRequest(bookBorrowingRequest, bookBorrowingRequestDetails);
        }

        public async Task<BookBorrowingRequest> UpdateBookBorrowingRequest(BookBorrowingRequest bookBorrowingRequest)
        {
            if(bookBorrowingRequest == null) return null;
            return await _bookBorrowingRequestRepository.UpdateBookBorrowingRequest(bookBorrowingRequest);
        }

        public async Task<BookBorrowingRequest> DeleteBookBorrowingRequest(int id)
        {
            return await _bookBorrowingRequestRepository.DeleteBookBorrowingRequest(id);
        }
    }
}