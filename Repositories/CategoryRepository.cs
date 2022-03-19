using Microsoft.EntityFrameworkCore;
using mid_assignment_backend.Entities;

namespace mid_assignment_backend.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly ApplicationDbContext _context;
        //public DbSet<CategoryModel> _categories { get; set; } 

        public CategoryRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Category>> GetAllCategories()
        {
            return await _context.Categories.ToListAsync();
        }

        public async Task<Category> GetCategoryById(int id)
        {
            return await _context.Categories.FindAsync(id);
        }

        public async Task<Category> CreateCategory(Category category)
        {
            if (category == null) throw new ArgumentNullException(nameof(category));
            await _context.Categories.AddAsync(category);
            await _context.SaveChangesAsync();
            return category;
        }

        public async Task<Category> UpdateCategory(Category category)
        {
            if (category == null) throw new ArgumentNullException(nameof(category));
            _context.Categories.Update(category);
            await _context.SaveChangesAsync();
            return category;
        }

        public async Task<Category> DeleteCategory(int id)
        {
            var category = await _context.Categories.FindAsync(id);
            if (category == null) throw new ArgumentNullException(nameof(category));
            _context.Categories.Remove(category);
            await _context.SaveChangesAsync();
            return category;
        }
    }
}