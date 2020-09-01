using System;

namespace eLibrary.Services.Dto
{
    public class BorrowedBookDto
    {
        public string Username { get; set; }

        public DateTime DateBorrowed { get; set; }

        public DateTime? DateReturned { get; set; }
    }
}
