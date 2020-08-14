using eLibrary.Data;
using eLibrary.Services;
using Microsoft.AspNetCore.Mvc;

namespace eLibrary.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private ApplicationDbContext _context;

        private BookService _books;

        public BooksController(ApplicationDbContext context)
        {
            _context = context;
            _books = new BookService(_context);
        }

        public IActionResult GetBooks(string query = null)
        {
            var items = _books.GetAllBooks(query);
            return Ok(items);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteBook(int id)
        {
            if (_books.DeleteBook(id) == Result.NotFound)
            {
                return NotFound();
            }
            else
            {
                return Ok();
            }
        }
    }
}
