using eLibrary.Services;
using Microsoft.AspNetCore.Mvc;

namespace eLibrary.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly CategoryService _categories;

        public CategoriesController(CategoryService categories)
        {
            _categories = categories;
        }

        public IActionResult GetCategories(string query = null)
        {
            var items = _categories.GetAllCategories(query);
            return Ok(items);
        }

        public IActionResult DeleteCategory(int id)
        {
            if (_categories.DeleteCategory(id) == Result.NotFound)
            {
                return NotFound();
            }
            else
            {
                return Ok();
            }
        }
    }
}
