using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace PolyBook.Models
{
    public class RegisterViewModel
    {
        [Required(ErrorMessage = "Введите имя")]
        [RegularExpression(@"[А-аЯ-я]+", ErrorMessage = "Используйте русские буквы")]
        [StringLength(20, MinimumLength = 2, ErrorMessage = "Поле <Имя> должно содержать от 2 до 20 символов")]
        [Display(Name = "Имя")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Введите фамилию")]
        [RegularExpression(@"[А-аЯ-я]+", ErrorMessage = "Используйте русские буквы")]
        [StringLength(20, MinimumLength = 2, ErrorMessage = "Поле <Фамилия> должно содержать от 2 до 20 символов")]
        [Display(Name = "Фамилия")]
        public string Surname { get; set; }

        [Required(ErrorMessage = "Введите E-mail")]
        [EmailAddress]
        [RegularExpression(@"[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,4}", ErrorMessage = "Некорректный адрес почты")]
        [Display(Name = "E-mail")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Введите пароль")]
        [UIHint("password")]
        [StringLength(20, MinimumLength = 6, ErrorMessage = "Пароль должен быть не короче 6 символов")]
        [DataType (DataType.Password)]
        [Display(Name = "Пароль")]
        public string Password { get; set; }

        [Display(Name = "Подтвердите пароль")]
        [UIHint("password")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Пароли не совпадают")]
        public string ConfirmPassword { get; set; }
    }
}
