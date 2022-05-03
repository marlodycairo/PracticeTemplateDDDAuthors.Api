using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TecnicalTestLibrary.Api.Infrastructure.Context;
using TecnicalTestLibrary.Api.Infrastructure.Entities;
using TecnicalTestLibrary.Api.Infrastructure.Repositories.IRepositories;

namespace TecnicalTestLibrary.Api.Infrastructure.Repositories
{
    public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : BaseEntity
    {
        private readonly ApplicationDbContext context;

        protected DbSet<TEntity> _entities;

        public BaseRepository(ApplicationDbContext context)
        {
            this.context = context;

            _entities = context.Set<TEntity>();
        }

        public async Task<TEntity> CreateEntityAsync(TEntity entity)
        {
            await _entities.AddAsync(entity);

            await context.SaveChangesAsync();

            return entity;
        }

        public async Task DeleteEntityAsync(int idEntity)
        {
            var entity = await _entities.FindAsync(idEntity);

            _entities.Remove(entity);

            await context.SaveChangesAsync();
        }

        public async Task<IEnumerable<TEntity>> GetAllEntitiesAsync()
        {
            return await _entities.ToListAsync();
        }

        public async Task<TEntity> GetEntityByIdAsync(int idEntity)
        {
            return await _entities.FirstOrDefaultAsync();
        }

        public async Task<TEntity> UpdateEntityAsync(TEntity entity)
        {
            //var entityUpdate = await context.Set<TEntity>().FirstOrDefaultAsync();

            context.ChangeTracker.Clear();

            _entities.Update(entity);

            await context.SaveChangesAsync();

            return entity;
        }
    }
}
