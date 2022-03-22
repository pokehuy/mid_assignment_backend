using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using mid_assignment_backend.Models;
using mid_assignment_backend.Services;
using mid_assignment_backend.Entities;
using Microsoft.AspNetCore.Cors;

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

    [EnableCors("AllowAll")]
    [Authorize(Roles = "Admin,User")]
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

    [EnableCors("AllowAll")]
    [Authorize(Roles = "Admin,User")]
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

    [EnableCors("AllowAll")]
    [Authorize(Roles = "Admin")]
    [HttpPost]
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

    [EnableCors("AllowAll")]
    [Authorize(Roles = "Admin")]
    [HttpPut("{id}")]
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

    [EnableCors("AllowAll")]
    [Authorize(Roles = "Admin")]
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteBook(int id)
    {
        var data = await _bookService.DeleteBook(id);
        return new JsonResult(data);
    }
}