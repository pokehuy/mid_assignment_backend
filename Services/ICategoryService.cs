using mid_assignment_backend.Entities;

namespace mid_assignment_backend.Services
{
    public interface ICategoryService
    {
        Task<List<Category>> GetAllCategories();
        Task<Category> GetCategoryById(int id);
        Task<Category> CreateCategory(Category category);
        Task<Category> UpdateCategory(Category category);
        Task<Category> DeleteCategory(int id);
    }
}