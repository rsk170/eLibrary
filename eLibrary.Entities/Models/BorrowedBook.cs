using System;
using System.ComponentModel.DataAnnotations;

namespace eLibrary.Entities.Models
{
    public class BorrowedBook
    {
        public int Id { get; set; }

        [Required]
        public User User { get; set; }

        [Required]
        public Book Book { get; set; }

        public DateTime DateBorrowed { get; set; }

        public DateTime? DateReturned { get; set; }
    }
}
