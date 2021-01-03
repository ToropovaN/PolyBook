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
        [Display(Name = "Раздел:")]
        public int BookGallery { get; set; }

        [Required(ErrorMessage = "Укажите автора")]
        [RegularExpression(@"[А-аЯ-я. ]+", ErrorMessage = "Введите автора русскими буквами")]
        [StringLength(20, MinimumLength = 3, ErrorMessage = "Поле <Автор> должно содержать от 3 до 20 символов")]
        [Display(Name = "Автор:")]
        public string Author { get; set; }

        [Required(ErrorMessage = "Укажите год")]
        [Range(1800, 2038, ErrorMessage = "Некорректный год")]
        [Display(Name = "Год:")]
        public int Year { get; set; }

        [Required(ErrorMessage = "Укажите тематику")]
        [Display(Name = "Тематика:")]
        public string Subject { get; set; }
    }
}
