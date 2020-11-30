using System;
using System.ComponentModel.DataAnnotations;

namespace PolyBook.Models
{
    public class Book
    {
        public Guid ID { get; set; }
        public string Title { get; set; }
        public int Year { get; set; }
        public string Text { get; set; }
        public string ImagePath { get; set; }

        [DataType(DataType.Date)]
        public DateTime ReleaseDate { get; set; }
        public string Genre { get; set; }
        public decimal Price { get; set; }
    }
}