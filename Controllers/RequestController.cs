using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
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
    
    [HttpGet]
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
}