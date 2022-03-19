using mid_assignment_backend.Repositories;
using mid_assignment_backend.Entities;

namespace mid_assignment_backend.Services
{
    public class BookService : IBookService
    {
        private readonly IBookRepository _bookRepository;

        public BookService(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }
    
    public async Task<List<Book>> GetAllBooks()
    {
        return await _bookRepository.GetAllBooks();

    }

    public async Task<Book> GetBookById(int id)
    {
        return await _bookRepository.GetBookById(id);
    }

    public async Task<Book> CreateBook(Book book)
    {
        if(book == null) return null;
        return await _bookRepository.CreateBook(book);
    }

    public async Task<Book> UpdateBook(Book book)
    {
        if(book == null) return null;
        return await _bookRepository.UpdateBook(book);
    }

    public async Task<Book> DeleteBook(int id)
    {
        return await _bookRepository.DeleteBook(id);
    }
    }
}