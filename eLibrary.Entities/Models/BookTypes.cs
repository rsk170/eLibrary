using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Text;

namespace eLibrary.Entities.Models
{
    public enum BookTypes
    {
        [Display(Name = "hard copy")]
        HardCopy,
        [Display(Name = "e-book")]
        EBook,
    }
}
