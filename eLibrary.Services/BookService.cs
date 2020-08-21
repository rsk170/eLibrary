using eLibrary.Data;
using eLibrary.Dto.Services;
using eLibrary.Entities.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace eLibrary.Services
{
    public class BookService
    {
        private readonly ApplicationDbContext _context;

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

        public async Task SaveBookAsync(Book book, IFormFile bookImage)
        {
            if (bookImage != null && bookImage.Length > 0)
            {
                book.ImageType = bookImage.ContentType;
                using (var stream = new MemoryStream())
                {
                    await bookImage.CopyToAsync(stream);
                    book.BookImage = stream.ToArray();
                }
            }

            if (book.Id == 0)
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
                bookInDb.BookImage = book.BookImage;
                bookInDb.ImageType = book.ImageType;
            }

            await _context.SaveChangesAsync();
        }

        public List<BookListingItem> GetAllBooks(string query = null)
        {
            var booksQuery = _context.Books
                .Include(b => b.Category).AsQueryable();

            if (!string.IsNullOrWhiteSpace(query))
            {
                booksQuery = booksQuery.Where(b => b.Title.Contains(query));
            }

            var bookListingItemsQuery = booksQuery.Select(b => new BookListingItem()
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
                BookImage = b.BookImage,
            });

            return bookListingItemsQuery.ToList();
        }

        public Result DeleteBook(int id)
        {
            var book = GetBook(id);
            if (book == null)
            {
                return Result.NotFound;
            }

            _context.Books.Remove(book);
            _context.SaveChanges();
            return Result.Success;
        }
    }
}
