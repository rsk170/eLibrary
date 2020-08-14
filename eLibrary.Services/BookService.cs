using eLibrary.Data;
using eLibrary.Dto.Services;
using eLibrary.Entities.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace eLibrary.Services
{
    public class BookService
    {
        private ApplicationDbContext _context;

        public BookService(ApplicationDbContext context)
        {
            _context = context;
        }

        public Book GetBook(int id)
        {
            return _context.Books.Include(b => b.Category).FirstOrDefault(b => b.Id == id);
        }

        public List<Category> GetCategories()
        {
            return _context.Categories.ToList();
        }

        public void SaveBook(Book book)
        {
            if(book.Id == 0)
            {
                book.Availability = true;
                _context.Books.Add(book);
            }
            else
            {
                var bookInDb = GetBook(book.Id);
                bookInDb.Title = book.Title;
                bookInDb.Author = book.Author;
                bookInDb.Location = book.Location;
                bookInDb.PublishDate = book.PublishDate;
                bookInDb.CategoryId = book.CategoryId;
                bookInDb.Type = book.Type;
                bookInDb.Description = book.Description;
            }

            _context.SaveChanges();
        }

        public List<BookListingItem> GetAllBooks(string query = null)
        {
            IQueryable<Book> booksQuery = _context.Books
                .Include(b => b.Category);

            if (!string.IsNullOrWhiteSpace(query))
            {
                booksQuery = booksQuery.Where(b => b.Title.Contains(query));
            }

            var bookListingItem = booksQuery.Select(b => new BookListingItem()
            {
                Id = b.Id,
                Title = b.Title,
                Author = b.Author,
                Type = b.Type,
                PublishDate = b.PublishDate,
                Category = b.Category.Name,
                Location = b.Location,
                Description = b.Description,
                Availability = b.Availability,
            });

            return bookListingItem.ToList();
        }

        public Result DeleteBook(int id)
        {
            var book = GetBook(id);
            if(book == null)
            {
                return Result.NotFound;
            }

            _context.Books.Remove(book);
            _context.SaveChanges();
            return Result.Success;
        }
    }
}
