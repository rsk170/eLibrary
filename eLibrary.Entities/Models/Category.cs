using System.ComponentModel.DataAnnotations;

namespace eLibrary.Entities.Models
{
    public class Category
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(255)]
        public string Name { get; set; }
    }
}
