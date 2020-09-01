using eLibrary.Data;
using eLibrary.Entities.Models;
using System;
using System.Linq;
using Microsoft.AspNetCore.Http;
using System.Runtime.InteropServices.WindowsRuntime;

namespace eLibrary.Services
{
    public class BorrowedBooksService
    {
        private readonly ApplicationDbContext _context;
        private readonly IHttpContextAccessor _httpContext;

        public BorrowedBooksService(ApplicationDbContext context, IHttpContextAccessor httpContext)
        {
            _context = context;
            _httpContext = httpContext;
        }

        public BorrowResult Borrow(int id)
        {

            var username = _httpContext.HttpContext.User.Identity.Name;
            Book book = _context.Books.Single(
               b => b.Id == id);
            User user = _context.Users.Single(
               u => u.Username == username);

            if (!book.Availability)
            {
                return BorrowResult.NotAvailable;
            }

            book.Availability = false;

            var newBorrow = new BorrowedBook
            {
                User = user,
                Book = book,
                DateBorrowed = DateTime.Now,
                DateReturned = DateTime.Now.AddDays(30),
            };

            _context.BorrowedBooks.Add(newBorrow);


            _context.SaveChanges();

            return BorrowResult.Success;
        }

        public Result Return(int id)
        {
            var username = _httpContext.HttpContext.User.Identity.Name;
            Book book = _context.Books.Single(b => b.Id == id);
            User user = _context.Users.Single(u => u.Username == username);
            var borrowedBook = _context.BorrowedBooks.FirstOrDefault(b => b.Book.Id == id);

            if(book == null || borrowedBook == null)
            {
                return Result.NotFound;
            }

            if (borrowedBook.User == user)
            {
                book.Availability = true;
                _context.BorrowedBooks.Remove(borrowedBook);
                _context.SaveChanges();
                return Result.Success;
            }
            else
            {
                return Result.NoPermission;
            }
        }
    }
}