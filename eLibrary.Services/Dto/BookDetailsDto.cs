using eLibrary.Entities.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace eLibrary.Services.Dto
{
    public class BookDetailsDto
    {
        public int BookId { get; set; }

        public string Title { get; set; }

        public string Author { get; set; }

        [Display(Name = "Category")]
        public Category Category { get; set; }

        public string Location { get; set; }

        [Display(Name = "Publish Date")]
        public DateTime? PublishDate { get; set; }

        public string Description { get; set; }

        [Display(Name = "Type")]
        public BookTypes BookType { get; set; }

        public bool Availability { get; set; }
            
        public BorrowedBookDto BorrowedBook { get; set; }
    }
}
