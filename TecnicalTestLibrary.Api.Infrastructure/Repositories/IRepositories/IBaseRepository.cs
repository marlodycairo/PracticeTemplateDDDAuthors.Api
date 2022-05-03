 using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TecnicalTestLibrary.Api.Infrastructure.Entities;

namespace TecnicalTestLibrary.Api.Infrastructure.Repositories.IRepositories
{
    public interface IBaseRepository<T> where T : BaseEntity
    {
        Task<T> CreateEntityAsync(T entity);
        Task DeleteEntityAsync(int entity);
        Task<T> GetEntityByIdAsync(int idEntity);
        Task<IEnumerable<T>> GetAllEntitiesAsync();
        Task<T> UpdateEntityAsync(T entity);
    }
}
