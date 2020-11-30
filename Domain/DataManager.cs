using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PolyBook.Domain.Repositories.Abstract;

namespace PolyBook.Domain
{
    public class DataManager
    {
        public IBooksRepository Books { get; set; }
        public INotesRepository Notes { get; set; }

        public DataManager(IBooksRepository booksRepository, INotesRepository notesRepository)
        {
            Books = booksRepository;
            Notes = notesRepository;
        }
    }
}
