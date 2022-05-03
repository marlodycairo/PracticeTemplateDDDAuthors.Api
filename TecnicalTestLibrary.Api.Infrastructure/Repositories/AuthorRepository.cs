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
    public class AuthorRepository : IAuthorRepository //IBaseRepository<Author>, IAuthorRepository
    {
        private readonly ApplicationDbContext context;

        public AuthorRepository(ApplicationDbContext context)
        {
            this.context = context;
        }

        public async Task DeleteEntityAsync(int id)
        {
            var author = await context.Authors.FindAsync(id);

            context.Authors.Remove(author);

            await context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Author>> GetAllEntitiesAsync()
        {
            return await context.Authors
                .ToListAsync();
        }

        public async Task<Author> GetEntityByIdAsync(int id)
        {
            return await context.Authors.FindAsync(id);
        }

        public async Task<Author> CreateEntityAsync(Author author)
        {
            await context.Authors.AddAsync(author);

            await context.SaveChangesAsync();

            return author;
        }

        public async Task<Author> UpdateEntityAsync(Author author)
        {
            context.ChangeTracker.Clear();
            context.Update(author);

            await context.SaveChangesAsync();

            return author;
        }
    }
}
