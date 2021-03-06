﻿using eLibrary.Entities.Models;
using eLibrary.Services;
using eLibrary.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace eLibrary.Controllers
{
    public class BooksController : Controller
    {
        private readonly BookService _books;
        private readonly BorrowedBookDetailsService _borrowedBookDetails;

        public BooksController(BookService books, BorrowedBookDetailsService borrowedBookDetails)
        {
            _books = books;
            _borrowedBookDetails = borrowedBookDetails;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Details(int id)
        {
            var bookDetails = _borrowedBookDetails.GetBorrowedBookDetails(id);
            if (bookDetails == null)
                return NotFound();

            return View(bookDetails);
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
        public async Task<IActionResult> SaveAsync(Book book, IFormFile bookImage, IFormFile pdfFile)
        {
            if (!ModelState.IsValid)
            {
                BookFormViewModel viewModel = InitializeViewModel(book);

                return View("BookForm", viewModel);
            }

            await _books.SaveBookAsync(book, bookImage, pdfFile);

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