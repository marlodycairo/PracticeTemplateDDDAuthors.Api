using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using TecnicalTestLibrary.Api.Infrastructure.Context;
using TecnicalTestLibrary.Api.Infrastructure.Entities;
using TecnicalTestLibrary.Api.Infrastructure.Repositories.IRepositories;

namespace TecnicalTestLibrary.Api.Infrastructure.Repositories
{
    public class BookRepository : IBookRepository //BaseRepository<Book>, IBookRepository
    {
        private readonly ApplicationDbContext context;
        private const int maximumAllowed = 5;

        public BookRepository(ApplicationDbContext context) // : base(context)
        {
            this.context = context;
        }

        public async Task DeleteEntityAsync(int id)
        {
            var book = await context.Books.FindAsync(id);

            //if (book == null)
            //{
            //    throw new BusinessException("The book is null.");
            //}

            context.Remove(book);

            await context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Book>> GetAllEntitiesAsync()
        {
            return await context.Books.ToListAsync();
        }

        public async Task<Book> GetEntityByIdAsync(int id)
        {
            return await context.Books.FindAsync(id);
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

            await context.Books.AddAsync(book);

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

            context.ChangeTracker.Clear();
            context.Update(book);

            await context.SaveChangesAsync();

            return book;
        }
    }
}
