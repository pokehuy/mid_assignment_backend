using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using mid_assignment_backend.Models;
using mid_assignment_backend.Services;
using mid_assignment_backend.Entities;

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

    [Authorize(Roles = "Admin,User")]
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

    [Authorize(Roles = "Admin,User")]
    [HttpGet("{id}")]
    public async Task<IActionResult> GetCategoryById(int id)
    {
        var data = await _categoryService.GetCategoryById(id);
        var resultProduct = new CategoryModel
        {
            Id = data.Id,
            Name = data.Name,
        };
        return new JsonResult(resultProduct);
    }

    [Authorize(Roles = "Admin")]
    [HttpPost]
    public async Task<IActionResult> CreateCategory([FromBody] CategoryModel category)
    {
        var resultProduct = new Category
        {
            //Id = data.Id,
            Name = category.Name,
        };
        var data = await _categoryService.CreateCategory(resultProduct);
        return new JsonResult(data);
    }

    [Authorize(Roles = "Admin")]
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateCategory(int id, [FromBody] CategoryModel category)
    {
        var resultProduct = new Category
        {
            Id = id,
            Name = category.Name,
        };
        var data = await _categoryService.UpdateCategory(resultProduct);
        return new JsonResult(data);
    }

    [Authorize(Roles = "Admin")]
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteCategory(int id)
    {
        var data = await _categoryService.DeleteCategory(id);
        return new JsonResult(data);
    }
}
