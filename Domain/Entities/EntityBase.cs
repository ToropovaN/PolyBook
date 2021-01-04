using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PolyBook.Domain.Entities
{
    public class EntityBase
    {
        protected EntityBase() => Date = DateTime.Now.ToString();

        [Required]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Заполните название")]
        [StringLength(40, MinimumLength = 3, ErrorMessage = "Поле <Название> должно содержать от 3 до 40 символов")]
        [Display(Name = "Название:")]
        public string Title { get; set; }

        [Display(Name = "Картинка:")]
        public string ImagePath { get; set; }

        [Required(ErrorMessage = "Объявление не может быть пустым")]
        [Display(Name = "Текст:")]
        public string Text { get; set; }

        [Display(Name = "Дата:")]
        public string Date { get; set; }

        [Required]
        public Guid OwnerID { get; set; }

        public string OwnerName { get; set; }
    }
}
