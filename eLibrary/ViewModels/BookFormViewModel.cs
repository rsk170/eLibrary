﻿using eLibrary.Entities.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

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
        [Display(Name = "Type")]
        public BookTypes? BookType { get; set; }

        public bool Availability { get; set; }

        [Display(Name = "Upload Photo")]
        public byte[] BookImage { get; set; }

        [Display(Name = "Upload PDF File")]
        public byte[] PdfFile { get; set; }

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
            BookType = book.BookType;
            Availability = book.Availability;
            BookImage = book.BookImage;
            PdfFile = book.PdfFile;
        }
    }
}
