using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using mid_assignment_backend.Entities;
using mid_assignment_backend.Models;
using mid_assignment_backend.Services;

namespace mid_assignment_backend.Controllers;

[ApiController]
[Route("[controller]")]
public class RequestController : ControllerBase
{
    private readonly ILogger<RequestController> _logger;
    private readonly IBookBorrowingRequestService _bookBorrowingRequestService;

    public RequestController(ILogger<RequestController> logger, IBookBorrowingRequestService bookBorrowingRequestService)
    {
        _logger = logger;
        _bookBorrowingRequestService = bookBorrowingRequestService;
    }
    
    [HttpGet, Authorize(Roles = "Admin")]
    public async Task<IActionResult> GetAllBookBorrowingRequests()
    {
        var data = await _bookBorrowingRequestService.GetAllBookBorrowingRequests();
        var resultProduct = from item in data
                            select new BookBorrowingRequestModel
                            {
                                Id = item.Id,
                                RequestByUserId = item.RequestByUserId,
                                Date = item.Date,
                                Status = item.Status,
                                ProcessedByUserId = item.ProcessedByUserId,
                            };
        return new JsonResult(resultProduct);
    }

    [HttpGet("{id}"), Authorize(Roles = "Admin,User")]
    public async Task<IActionResult> GetBookBorrowingRequest(int id)
    {
        var data = await _bookBorrowingRequestService.GetBookBorrowingRequestById(id);
        var resultProduct = new BookBorrowingRequestModel
        {
            Id = data.Id,
            RequestByUserId = data.RequestByUserId,
            Date = data.Date,
            Status = data.Status,
            ProcessedByUserId = data.ProcessedByUserId,
        };
        return new JsonResult(resultProduct);
    }

    [HttpPost, Authorize(Roles = "Admin,User")]
    public async Task<IActionResult> CreateBookBorrowingRequest(BookBorrowingRequestModel bookBorrowingRequestModel)
    {
        var data = new BookBorrowingRequest
        {
            RequestByUserId = bookBorrowingRequestModel.RequestByUserId,
            Date = bookBorrowingRequestModel.Date,
            Status = bookBorrowingRequestModel.Status,
            ProcessedByUserId = bookBorrowingRequestModel.ProcessedByUserId,
        };
        var resultProduct = await _bookBorrowingRequestService.CreateBookBorrowingRequest(data);
        return new JsonResult(resultProduct);
    }

    [HttpPut("{id}"), Authorize(Roles = "Admin")]
    public async Task<IActionResult> UpdateBookBorrowingRequest(int id, BookBorrowingRequestModel bookBorrowingRequest)
    {
        var resultProduct = new BookBorrowingRequest
        {
            Id = id,
            RequestByUserId = bookBorrowingRequest.RequestByUserId,
            Date = bookBorrowingRequest.Date,
            Status = bookBorrowingRequest.Status,
            ProcessedByUserId = bookBorrowingRequest.ProcessedByUserId,
        };
        var data = await _bookBorrowingRequestService.UpdateBookBorrowingRequest(resultProduct);
        return new JsonResult(data);
    }
}