using eLibrary.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace eLibrary.Services
{
    public class CategoryService
    {
        private ApplicationDbContext _context;

        public CategoryService(ApplicationDbContext context)
        {
            _context = context;
        }
    }
}
