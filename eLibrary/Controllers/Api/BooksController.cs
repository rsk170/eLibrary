using eLibrary.Services;
using Microsoft.AspNetCore.Mvc;

namespace eLibrary.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private BookService _books;

        public BooksController(BookService books)
        {
            _books = books;
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
