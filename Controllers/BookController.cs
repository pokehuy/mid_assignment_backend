using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using mid_assignment_backend.Models;
using mid_assignment_backend.Services;
using mid_assignment_backend.Entities;

namespace mid_assignment_backend.Controllers;

[ApiController]
[Route("[controller]")]
public class BookController : ControllerBase
{
    private readonly ILogger<BookController> _logger;
    private readonly IBookService _bookService;

    public BookController(ILogger<BookController> logger, IBookService bookService)
    {
        _logger = logger;
        _bookService = bookService;
    }
    
    [HttpGet]
    public async Task<IActionResult> GetAllBooks()
    {
        var data = await _bookService.GetAllBooks();
        var resultProduct = from item in data
                            select new BookModel
                            {
                                Id = item.Id,
                                Title = item.Title,
                                Author = item.Author,
                                CategoryId = item.CategoryId,
                            };
        return new JsonResult(resultProduct);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetBookById(int id)
    {
        var data = await _bookService.GetBookById(id);
        var resultProduct = new BookModel
        {
            Id = data.Id,
            Title = data.Title,
            Author = data.Author,
            CategoryId = data.CategoryId,
        };
        return new JsonResult(resultProduct);
    }

    [HttpPost]
    public async Task<IActionResult> CreateBook([FromBody] BookModel book)
    {
        var resultProduct = new Book
        {
            //Id = data.Id,
            Title = book.Title,
            Author = book.Author,
            CategoryId = book.CategoryId,
        };
        var data = await _bookService.CreateBook(resultProduct);
        return new JsonResult(data);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateBook(int id, [FromBody] BookModel book)
    {
        var resultProduct = new Book
        {
            Id = id,
            Title = book.Title,
            Author = book.Author,
            CategoryId = book.CategoryId,
        };
        var data = await _bookService.UpdateBook(resultProduct);
        return new JsonResult(data);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteBook(int id)
    {
        var data = await _bookService.DeleteBook(id);
        return new JsonResult(data);
    }
}