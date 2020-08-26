using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using Newtonsoft.Json.Converters;
using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace eLibrary.Entities.Models
{
    public class Book
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Please enter the book's title")]
        [StringLength(255)]
        public string Title { get; set; }

        public string Author { get; set; }

        [Display(Name = "Category")]
        public Category Category { get; set; }

        [Display(Name = "Category")]
        [Required]
        public int CategoryId { get; set; }

        public string Location { get; set; }

        [Display(Name = "Publish Date")]
        public DateTime? PublishDate { get; set; }

        public string Description { get; set; }

        [Required]
        [Display(Name = "Type")]
        public BookTypes BookType { get; set; }

        public bool Availability { get; set; }

        [Display(Name = "Upload Image")]
        public byte[] BookImage { get; set; }

        public string ImageType { get; set; }

        [Display(Name = "Upload PDF file")]
        public byte[] PdfFile { get; set; }
    }
}