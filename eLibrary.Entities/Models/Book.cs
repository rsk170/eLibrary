using System;
using System.ComponentModel.DataAnnotations;

namespace eLibrary.Entities.Models
{
    public class Book
    {
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Title { get; set; }

        public string Author { get; set; }

        public Category Category { get; set; }

        [Display(Name = "Category")]
        [Required]
        public int CategoryId { get; set; }

        public string? Location { get; set; }

        [Display(Name = "Publish Date")]
        public DateTime? PublishDate { get; set; }

        public string Description { get; set; }

        public string Type { get; set; }

        public bool Availability { get; set; }
    }
}
