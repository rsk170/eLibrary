﻿using eLibrary.Entities.Models;
using System;

namespace eLibrary.Dto.Services
{
    public class BookListingItem
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Author { get; set; }

        public string Category { get; set; }

        public string Location { get; set; }

        public DateTime? PublishDate { get; set; }

        public string Description { get; set; }

        public bool Availability { get; set; }

        public byte[] BookImage { get; set; }

        public BookTypes BookType { get; set; }
    }
}
