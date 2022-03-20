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
    
    [HttpGet, Authorize(Roles = "Admin,User")]
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

    [HttpGet("{id}"), Authorize(Roles = "Admin,User")]
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

    [HttpPost, Authorize(Roles = "Admin")]
    public async Task<IActionResult> CreateBook([FromBody] BookModel book)
    {
        var data = new Book
        {
            //Id = data.Id,
            Title = book.Title,
            Author = book.Author,
            CategoryId = book.CategoryId,
        };
        var resultProduct = await _bookService.CreateBook(data);
        return new JsonResult(resultProduct);
    }

    [HttpPut("{id}"), Authorize(Roles = "Admin")]
    public async Task<IActionResult> UpdateBook(int id, [FromBody] BookModel book)
    {
        var data = new Book
        {
            Id = id,
            Title = book.Title,
            Author = book.Author,
            CategoryId = book.CategoryId,
        };
        var resultProduct = await _bookService.UpdateBook(data);
        return new JsonResult(resultProduct);
    }

    [HttpDelete("{id}"), Authorize(Roles = "Admin")]
    public async Task<IActionResult> DeleteBook(int id)
    {
        var data = await _bookService.DeleteBook(id);
        return new JsonResult(data);
    }
}