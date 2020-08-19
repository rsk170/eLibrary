using eLibrary.Entities.Models;
using eLibrary.Services;
using eLibrary.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace eLibrary.Controllers
{
    public class CategoriesController : Controller
    {
        private readonly CategoryService _categories;

        public CategoriesController(CategoryService categories)
        {
            _categories = categories;
        }

        public IActionResult Index()
        {
            return View("CategoryList");
        }

        public IActionResult New()
        {
            var viewModel = new CategoryFormViewModel();
            return View("CategoryForm", viewModel);
        }

        public IActionResult Edit(int id)
        {
            var category = _categories.GetCategory(id);

            if (category == null)
                return NotFound();

            var viewModel = InitializeViewModel(category);

            return View("CategoryForm", viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Save(Category category)
        {
            if (!ModelState.IsValid)
            {
                CategoryFormViewModel viewModel = InitializeViewModel(category);

                return View("CategoryForm", viewModel);
            }

            _categories.SaveCategory(category);

            return RedirectToAction("Index", "Categories");
        }

        private CategoryFormViewModel InitializeViewModel(Category category)
        {
            return new CategoryFormViewModel(category);
        }
    }
}
