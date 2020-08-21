using eLibrary.Data;
using eLibrary.Services;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mime;

namespace eLibrary.Controllers
{
    public class ImagesController : Controller
    {
        private readonly BookService _books;

        public ImagesController(BookService books)
        {
            _books = books;
        }

        public IActionResult Book(int id)
        {
            var book = _books.GetBook(id);
            if (book == null)
            {
                return NotFound();
            }

            var image = book.BookImage;
            if (image == null || book.ImageType == null)
            {
                return File("~/images/books/noBookImage.jpg", MediaTypeNames.Image.Jpeg);
            }

            return File(image, book.ImageType);
        }
    }
}
