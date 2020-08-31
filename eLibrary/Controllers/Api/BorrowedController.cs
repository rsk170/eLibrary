using eLibrary.Services;
using Microsoft.AspNetCore.Mvc;

namespace eLibrary.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class BorrowedController : ControllerBase
    {
        private readonly BorrowedBooksService _borrowedBooks;

        public BorrowedController(BorrowedBooksService borrowedBooks)
        {
            _borrowedBooks = borrowedBooks;
        }

        [HttpPost("{id}")]
        public IActionResult Index(int id)
        {
            if (_borrowedBooks.Borrow(id) == BorrowResult.NotAvailable)
            {
                return BadRequest("Book is not available.");
            }
            else
            {
                return Ok();
            }
        }
    }
}
