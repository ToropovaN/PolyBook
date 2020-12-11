using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PolyBook.Domain.Entities
{
    public class Book : EntityBase
    {
        [Required(ErrorMessage = "Выберите раздел")]
        [Display(Name = "Раздел")]
        public int BookGallery { get; set; }

        [Required(ErrorMessage = "Укажите автора")]
        [Display(Name = "Автор")]
        public string Author { get; set; }

        [Required(ErrorMessage = "Укажите год")]
        [Display(Name = "Год")]
        public int Year { get; set; }

        [Required(ErrorMessage = "Укажите тематику")]
        [Display(Name = "Тематика")]
        public string Subject { get; set; }
    }
}
