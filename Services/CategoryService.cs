
using mid_assignment_backend.Entities;
using mid_assignment_backend.Repositories;

namespace mid_assignment_backend.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;
        public CategoryService(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public async Task<List<Category>> GetAllCategories()
        {
            return await _categoryRepository.GetAllCategories();
        }

        public async Task<Category> GetCategoryById(int id)
        {
            return await _categoryRepository.GetCategoryById(id);
        }

        public async Task<Category> CreateCategory(Category category)
        {
            if (category == null) return null;
            return await _categoryRepository.CreateCategory(category);
        }

        public async Task<Category> UpdateCategory(Category category)
        {
            if (category == null) return null;
            return await _categoryRepository.UpdateCategory(category);
        }

        public async Task<Category> DeleteCategory(int id)
        {
            return await _categoryRepository.DeleteCategory(id);
        }
    }
}