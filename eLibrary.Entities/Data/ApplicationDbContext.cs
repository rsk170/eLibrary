using eLibrary.Entities.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace eLibrary.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public DbSet<Book> Books { get; set; }

        public DbSet<Category> Categories { get; set; }

        public  DbSet<User> Users { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<Category>().HasData(
                new Category { Id = 1, Name = "Management"},
                new Category { Id = 2, Name = "Popular Psychology"},
                new Category { Id = 3, Name = "Introducton to Programming"},
                new Category { Id = 4, Name = "Software Architecture"},
                new Category { Id = 5, Name = ".NET"},
                new Category { Id = 6, Name = "Design Pattern Programming"},
                new Category { Id = 7, Name = "Java"},
                new Category { Id = 8, Name = "Network Security"},
                new Category { Id = 9, Name = "MCSE"},
                new Category { Id = 10, Name = "iOS"}
                );
        }
    }
}
