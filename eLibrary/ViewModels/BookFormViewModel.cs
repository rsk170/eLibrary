using eLibrary.Entities.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace eLibrary.ViewModels
{
    public class BookFormViewModel
    {
        public IEnumerable<Category> Categories { get; set; }

        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Title { get; set; }

        public string Author { get; set; }

        [Display(Name = "Category")]
        [Required]
        public int CategoryId { get; set; }

        public string Location { get; set; }

        [Display(Name = "Publish Date")]
        public DateTime? PublishDate { get; set; }

        public string Description { get; set; }

        [Required]
        public string Type { get; set; }

        public bool Availability { get; set; }

        public string PageTitle
        {
            get
            {
                return Id != 0 ? "Edit Book" : "New Book";
            }
        }

        public BookFormViewModel()
        {
            Id = 0;
        }

        public BookFormViewModel(Book book)
        {
            Id = book.Id;
            Title = book.Title;
            Author = book.Author;
            CategoryId = book.CategoryId;
            Location = book.Location;
            PublishDate = book.PublishDate;
            Description = book.Description;
            Type = book.Type;
            Availability = book.Availability;
        }
    }
}
