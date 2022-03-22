using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using mid_assignment_backend.Entities;
using mid_assignment_backend.Models;
using mid_assignment_backend.Services;

namespace mid_assignment_backend.Controllers;

[ApiController]
[Route("[controller]")]
public class DetailsController : ControllerBase
{
    private readonly ILogger<DetailsController> _logger;
    private readonly IBookBorrowingRequestDetailsService _bookBorrowingRequestDetailsService;

    public DetailsController(ILogger<DetailsController> logger, IBookBorrowingRequestDetailsService bookBorrowingRequestDetailsService)
    {
        _logger = logger;
        _bookBorrowingRequestDetailsService = bookBorrowingRequestDetailsService;
    }

    [HttpGet, Authorize(Roles = "Admin")]
    public async Task<IActionResult> GetAllBookBorrowingRequestDetails()
    {
        var data = await _bookBorrowingRequestDetailsService.GetAllBookBorrowingRequestDetails();
        var resultProduct = from item in data
                            select new BookBorrowingRequestDetailsModel
                            {
                                BookBorrowingRequestId = item.BookBorrowingRequestId,
                                BookId = item.BookId,
                            };
        return new JsonResult(resultProduct);
    }

    [HttpGet("{requestId}&{bookId}"), Authorize(Roles = "Admin,User")]
    public async Task<IActionResult> GetBookBorrowingRequestDetailsById(int requestId,int bookId)
    {
        var data = await _bookBorrowingRequestDetailsService.GetBookBorrowingRequestDetailsById(requestId, bookId);
        var resultProduct = new BookBorrowingRequestDetailsModel
        {
            BookBorrowingRequestId = data.BookBorrowingRequestId,
            BookId = data.BookId,
        };
        return new JsonResult(resultProduct);
    }
    /*
    [HttpPost, Authorize(Roles = "Admin,User")]
    public async Task<IActionResult> CreateBookBorrowingRequestDetails(BookBorrowingRequestDetailsModel bookBorrowingRequestDetails)
    {
        var data = new BookBorrowingRequestDetails
        {
            BookBorrowingRequestId = bookBorrowingRequestDetails.BookBorrowingRequestId,
            BookId = bookBorrowingRequestDetails.BookId,
        };
        var resultProduct = await _bookBorrowingRequestDetailsService.CreateBookBorrowingRequestDetails(data);
        return new JsonResult(resultProduct);
    }
    */
}