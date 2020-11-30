using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PolyBook.Domain.Entities
{
    public class Gallery
    {
        [Required]
        public Guid Id { get; set; }

        [Display(Name = "Название галереи")]
        public string GalleryTitle { get; set; }

        [Display(Name = "Контент галереи")]
        public string GalleryContent { get; set; }

    }
}
