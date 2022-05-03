using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TecnicalTestLibrary.Api.Infrastructure.Context;
using TecnicalTestLibrary.Api.Infrastructure.Entities;
using TecnicalTestLibrary.Api.Infrastructure.Exceptions;
using TecnicalTestLibrary.Api.Infrastructure.Repositories.IRepositories;

namespace TecnicalTestLibrary.Api.Infrastructure.Repositories
{
    public class BookRepository : BaseRepository<Book>, IBookRepository
    {
        private readonly ApplicationDbContext context;
        private const int maximumAllowed = 5;

        public BookRepository(ApplicationDbContext context) : base(context)
        {
        }

        public async Task DeleteEntityAsync(int id)
        {
            var book = await _entities.FindAsync(id);

            //if (book == null)
            //{
            //    throw new BusinessException("The book is null.");
            //}

            _entities.Remove(book);

            await context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Book>> GetAllEntitiesAsync()
        {
            return await _entities.ToListAsync();
        }

        public async Task<Book> GetEntityByIdAsync(int id)
        {
            return await _entities.FindAsync(id);
        }

        public async Task<Book> CreateEntityAsync(Book book)
        {
            //bool bookExist = await context.Books.AnyAsync(p => p.Id == book.Id);

            //if (bookExist)
            //{
            //    throw new BusinessException("The book already exist.");
            //}

            //int numberOfBooks = await context.Books.CountAsync();

            //if (numberOfBooks >= maximumAllowed)
            //{
            //    throw new BusinessException("Unable to register the book, the maximum allowed has been reached");
            //}

            await _entities.AddAsync(book);

            await context.SaveChangesAsync();

            return book;
        }

        public async Task<Book> UpdateEntityAsync(Book book)
        {
            //bool bookExist = await context.Books.AnyAsync(p => p.Id == book.Id);

            //if (!bookExist)
            //{
            //    throw new BusinessException("The book don't exist.");
            //}

            _entities.Update(book);

            await context.SaveChangesAsync();

            return book;
        }
    }
}
