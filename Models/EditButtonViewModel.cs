using PolyBook.Domain.Entities;
using System;
using System.Collections;
using System.Collections.Generic;

namespace PolyBook.Models
{
    public class EditButtonViewModel
    {
        public EditButtonViewModel(Book _book, bool _isOwner) {
            book = _book;
            isOwner = _isOwner;
        }

        public Book book { get; set; }
        public bool isOwner { get; set; }
    }
}
