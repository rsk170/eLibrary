using eLibrary.Services;
using Microsoft.AspNetCore.Mvc;

namespace eLibrary.Controllers
{
    public class PDFsController : Controller
    {
        private readonly BookService _books;

        public PDFsController(BookService books)
        {
            _books = books;
        }

        public ActionResult PDF(int id)
        {
            var book = _books.GetBook(id);
            if (book == null)
            {
                return NotFound();
            }

            var pdf = book.PDFFile;
            return File(pdf, "application/pdf");
        }
    }
}
