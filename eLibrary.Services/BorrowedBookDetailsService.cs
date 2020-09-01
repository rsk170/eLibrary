using AutoMapper;
using eLibrary.Data;
using eLibrary.Entities.Models;
using eLibrary.Services.Dto;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using System.Linq;

namespace eLibrary.Services
{
    public class BorrowedBookDetailsService
    {
        private readonly ApplicationDbContext _context;

        public BorrowedBookDetailsService(ApplicationDbContext context)
        {
            _context = context;
        }

        public BookDetailsDto GetBorrowedBookDetails(int id)
        {
            var query =
                from book in _context.Books
                where book.Id == id
                let isBookBorrowed = !book.Availability && book.BookType == BookTypes.HardCopy
                let borrowedBook = isBookBorrowed
                    ? (from borrowedBook in _context.BorrowedBooks
                       where borrowedBook.Book.Id == id
                       select new BorrowedBookDto()
                       {
                           Username = borrowedBook.User.Username,
                           DateBorrowed = borrowedBook.DateBorrowed,
                           DateReturned = borrowedBook.DateReturned,
                       }).FirstOrDefault()
                    : null
                select new BookDetailsDto()
                {
                    BookId = book.Id,
                    Title = book.Title,
                    Author = book.Author,
                    Category = book.Category,
                    PublishDate = book.PublishDate,
                    Description = book.Description,
                    BookType = book.BookType,
                    Location = book.Location,
                    Availability = book.Availability,
                    BorrowedBook = borrowedBook,
                };

            return query.FirstOrDefault();
        }
    }
}
