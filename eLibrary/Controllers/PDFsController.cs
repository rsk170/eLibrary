using eLibrary.Services;
using Microsoft.AspNetCore.Mvc;

namespace eLibrary.Controllers
{
    public class PdfsController : Controller
    {
        private readonly BookService _books;

        public PdfsController(BookService books)
        {
            _books = books;
        }

        public ActionResult Pdf(int id)
        {
            var book = _books.GetBook(id);
            if (book == null)
            {
                return NotFound();
            }

            var pdf = book.PdfFile;
            return File(pdf, System.Net.Mime.MediaTypeNames.Application.Pdf);
        }
    }
}
