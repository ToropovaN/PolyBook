using PolyBook.Domain.Entities;
using System;
using System.Collections;
using System.Collections.Generic;

namespace PolyBook.Models
{
    public class GalleryViewModel
    {
        public GalleryViewModel(int num, string name, IEnumerable<Book> content)
        {
            GalleryNum = num;
            GalleryName = name;
            GalleryContentBooks = content;
            GalleryContentNotes = null;
        }

        public GalleryViewModel(int num, string name, IEnumerable<Note> content)
        {
            GalleryNum = num;
            GalleryName = name;
            GalleryContentNotes = content;
            GalleryContentBooks = null;
        }

        public int GalleryNum { get; set; }
        public string GalleryName { get; set; }
        public IEnumerable<Book> GalleryContentBooks { get; set; }
        public IEnumerable<Note> GalleryContentNotes { get; set; }
    }
}
