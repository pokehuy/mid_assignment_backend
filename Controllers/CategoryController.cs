using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using mid_assignment_backend.Models;
using mid_assignment_backend.Services;

namespace mid_assignment_backend.Controllers;

[ApiController]
[Route("[controller]")]
public class CategoryController : ControllerBase
{
    private readonly ILogger<CategoryController> _logger;
    private readonly ICategoryService _categoryService;

    public CategoryController(ILogger<CategoryController> logger, ICategoryService categoryService)
    {
        _logger = logger;
        _categoryService = categoryService;
    }
    
    [HttpGet]
    public async Task<IActionResult> GetAllCategories()
    {
        var data = await _categoryService.GetAllCategories();
        var resultProduct = from item in data
                            select new CategoryModel
                            {
                                Id = item.Id,
                                Name = item.Name
                            };
        return new JsonResult(resultProduct);
    }
}
