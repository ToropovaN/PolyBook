using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PolyBook.Domain.Entities;

namespace PolyBook.Domain.Repositories.Abstract
{
    public interface IBooksRepository
    {
        IQueryable<Book> GetBooks();

        IQueryable<Book> GetBooksByOwnerId(Guid ownerid);
        Book GetBookById(Guid id);
        void SaveBook(Book entity);
        void DeleteBook(Book book);
    }
}
