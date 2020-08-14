using eLibrary.Data;
using eLibrary.Entities.Models;
using eLibrary.Services;
using eLibrary.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace eLibrary.Controllers
{
    public class BooksController : Controller
    {
        private BookService _books;

        private ApplicationDbContext _context;

        public BooksController(ApplicationDbContext context)
        {
            _context = context;
            _books = new BookService(_context);
        }

        public IActionResult Index()
        {
            return View("List");
        }

        public IActionResult Details(int id)
        {
            Book book = _books.GetBook(id);

            if (book == null)
                return NotFound();

            return View(book);
        }

        public IActionResult New()
        {
            var viewModel = new BookFormViewModel
            {
                Categories = _books.GetCategories()
            };

            return View("BookForm", viewModel);
        }

        public IActionResult Edit(int id)
        {
            var book = _books.GetBook(id);

            if (book == null)
                return NotFound();

            var viewModel = InitializeViewModel(book);

            return View("BookForm", viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Save(Book book)
        {
            if (!ModelState.IsValid)
            {
                BookFormViewModel viewModel = InitializeViewModel(book);

                return View("BookForm", viewModel);
            }

            _books.SaveBook(book);

            return RedirectToAction("Index", "Books");
        }

        private BookFormViewModel InitializeViewModel(Book book)
        {
            return new BookFormViewModel(book)
            {
                Categories = _books.GetCategories()
            };
        }
    }
}
