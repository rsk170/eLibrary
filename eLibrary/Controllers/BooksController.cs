﻿using eLibrary.Entities.Models;
using eLibrary.Services;
using eLibrary.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.IO;
using System.Threading.Tasks;

namespace eLibrary.Controllers
{
    public class BooksController : Controller
    {
        private readonly BookService _books;

        public BooksController(BookService books)
        {
            _books = books;
        }

        public IActionResult Index()
        {
            return View();
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
        public async Task<IActionResult> Save(Book book, IFormFile image)
        {
            if (!ModelState.IsValid)
            {
                BookFormViewModel viewModel = InitializeViewModel(book);

                return View("BookForm", viewModel);
            }

            if (image != null && image.Length > 0)
            {
                var fileName = Path.GetFileName(image.FileName);
                var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\images\\books", fileName);
                using (var fileSteam = new FileStream(filePath, FileMode.Create))
                {
                    await image.CopyToAsync(fileSteam);
                }
                book.BookImage = fileName;
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
