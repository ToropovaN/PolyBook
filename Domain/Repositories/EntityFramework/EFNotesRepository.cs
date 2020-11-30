using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PolyBook.Domain.Entities;
using PolyBook.Domain.Repositories.Abstract;

namespace PolyBook.Domain.Repositories.EntityFramework
{
    public class EFNotesRepository : INotesRepository
    {
        private readonly AppDbContext context;
        public EFNotesRepository(AppDbContext context)
        {
            this.context = context;
        }

        public IQueryable<Note> GetNotes()
        {
            return context.Notes;
        }

        public Note GetNoteById(Guid id)
        {
            return context.Notes.FirstOrDefault(x => x.Id == id);
        }

        public void SaveNote(Note entity)
        {
            if (entity.Id == default)
                context.Entry(entity).State = EntityState.Added;
            else
                context.Entry(entity).State = EntityState.Modified;
            context.SaveChanges();
        }

        public void DeleteNote(Guid id)
        {
            context.Notes.Remove(new Note() { Id = id });
            context.SaveChanges();
        }
    }
}
