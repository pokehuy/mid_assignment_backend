using mid_assignment_backend.Entities;

namespace mid_assignment_backend.Services
{
    public interface IBookService
    {
        Task<List<Book>> GetAllBooks();
        Task<Book> GetBookById(int id);
        Task<Book> CreateBook(Book book);
        Task<Book> UpdateBook(Book book);
        Task<Book> DeleteBook(int id);
    }
}