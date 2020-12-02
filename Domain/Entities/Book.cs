using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PolyBook.Domain.Entities
{
    public class Book : EntityBase
    {
        [Required(ErrorMessage = "Укажите автора")]
        [Display(Name = "Автор")]
        public string Author { get; set; }

        [Required(ErrorMessage = "Укажите год")]
        [Display(Name = "Год")]
        public int Year { get; set; }
    }
}
