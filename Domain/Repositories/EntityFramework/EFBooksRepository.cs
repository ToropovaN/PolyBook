﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PolyBook.Domain.Entities;
using PolyBook.Domain.Repositories.Abstract;

namespace PolyBook.Domain.Repositories.EntityFramework
{
    public class EFBooksRepository : IBooksRepository 
    {
        private readonly AppDbContext context;
        public EFBooksRepository(AppDbContext context)
        {
            this.context = context;
        }

        public IQueryable<Book> GetBooks()
        {
            return context.Books;
        }

        public Book GetBookById(Guid id)
        {
            return context.Books.FirstOrDefault(x => x.Id == id);
        }
        public IQueryable<Book> GetBooksByOwnerId(Guid ownerid)
        {
            return context.Books.Where(p => p.OwnerID == ownerid);
        }

        public void SaveBook(Book entity)
        {
            if (entity.Id == default)
                context.Entry(entity).State = EntityState.Added;
            else
                context.Entry(entity).State = EntityState.Modified;
            context.SaveChanges();
        }

        public void DeleteBook(Book book)
        {
            context.Books.Remove(book);
            context.SaveChanges();
        }
    }
}
