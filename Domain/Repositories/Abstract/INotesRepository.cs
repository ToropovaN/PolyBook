using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PolyBook.Domain.Entities;

namespace PolyBook.Domain.Repositories.Abstract
{
    public interface INotesRepository
    {
        IQueryable<Note> GetNotes();
        Note GetNoteById(Guid id);
        void SaveNote(Note entity);
        void DeleteNote(Guid id);
    }
}
