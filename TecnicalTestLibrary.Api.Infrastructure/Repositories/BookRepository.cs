using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TecnicalTestLibrary.Api.Infrastructure.Context;
using TecnicalTestLibrary.Api.Infrastructure.Entities;
using TecnicalTestLibrary.Api.Infrastructure.Repositories.IRepositories;

namespace TecnicalTestLibrary.Api.Infrastructure.Repositories
{
    public class BookRepository : IBookRepository
    {
        private readonly ApplicationDbContext context;
        private const int maximumAllowed = 100;

        public BookRepository(ApplicationDbContext context)
        {
            this.context = context;
        }

        public async Task Delete(int id)
        {
            Book book = await context.Books.FindAsync(id);

            if (book == null)
            {
                throw new Exception("The book is null.");
            }

            context.Books.Remove(book);

            await context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Book>> GetAll()
        {
            return await context.Books
                .ToListAsync();
        }

        public async Task<Book> GetById(int id)
        {
            return await context.Books.FindAsync(id);
        }

        public async Task<Book> CreateBook(Book book)
        {
            bool bookExist = await context.Books.AnyAsync(p => p.Id == book.Id);

            if (bookExist)
            {
                throw new Exception("The book already exist.");
            }

            int numberOfBooks = await context.Books.CountAsync();

            if (numberOfBooks >= maximumAllowed)
            {
                throw new Exception("Unable to register the book, the maximum allowed has been reached");
            }

            await context.Books.AddAsync(book);

            await context.SaveChangesAsync();

            return book;
        }

        public async Task<Book> Update(Book book)
        {
            bool bookExist = await context.Books.AnyAsync(p => p.Id == book.Id);

            if (!bookExist)
            {
                throw new Exception("The book don't exist.");
            }

            context.Update(book);

            await context.SaveChangesAsync();

            return book;
        }
    }
}
