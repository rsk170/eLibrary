using eLibrary.Entities.Models;
using System.ComponentModel.DataAnnotations;

namespace eLibrary.ViewModels
{
    public class CategoryFormViewModel
    {
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        public string PageTitle
        {
            get
            {
                return Id != 0 ? "Edit Category" : "New Category";
            }
        }

        public CategoryFormViewModel()
        {
            Id = 0;
        }

        public CategoryFormViewModel(Category category)
        {
            Id = category.Id;
            Name = category.Name;
        }
    }
}
