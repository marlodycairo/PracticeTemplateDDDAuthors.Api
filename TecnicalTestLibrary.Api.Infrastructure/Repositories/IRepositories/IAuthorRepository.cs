using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TecnicalTestLibrary.Api.Infrastructure.Entities;

namespace TecnicalTestLibrary.Api.Infrastructure.Repositories.IRepositories
{
    public interface IAuthorRepository
    {
        Task<IEnumerable<Author>> GetAllEntitiesAsync();
        Task<Author> GetEntityByIdAsync(int id);
        Task<Author> CreateEntityAsync(Author author);
        Task<Author> UpdateEntityAsync(Author author);
        Task DeleteEntityAsync(int id);
    }
}
