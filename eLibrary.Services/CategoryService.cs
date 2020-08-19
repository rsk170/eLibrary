using eLibrary.Data;
using eLibrary.Entities.Models;
using eLibrary.Services.Dto;
using System.Collections.Generic;
using System.Linq;

namespace eLibrary.Services
{
    public class CategoryService
    {
        private readonly ApplicationDbContext _context;

        public CategoryService(ApplicationDbContext context)
        {
            _context = context;
        }

        public Category GetCategory(int id)
        {
            return _context.Categories.FirstOrDefault(c => c.Id == id);
        }

        public List<CategoryListingItem> GetAllCategories(string query = null)
        {
            var categoriesQuery = _context.Categories.AsQueryable();

            if (!string.IsNullOrWhiteSpace(query))
            {
                categoriesQuery = categoriesQuery.Where(c => c.Name.Contains(query));
            }

            var categoryListingItemsQuery = categoriesQuery.Select(c => new CategoryListingItem()
            {
                Id = c.Id,
                Name = c.Name,
            });

            return categoryListingItemsQuery.ToList();
        }

        public void SaveCategory(Category category)
        {
            if (category.Id == 0)
            {
                _context.Categories.Add(category);
            }
            else
            {
                var categoryInDb = GetCategory(category.Id);
                categoryInDb.Name = category.Name;
            }

            _context.SaveChanges();
        }

        public Result DeleteCategory(int id)
        {
            var category = GetCategory(id);
            if (category == null)
            {
                return Result.NotFound;
            }

            _context.Categories.Remove(category);
            _context.SaveChanges();
            return Result.Success;
        }
    }
}
