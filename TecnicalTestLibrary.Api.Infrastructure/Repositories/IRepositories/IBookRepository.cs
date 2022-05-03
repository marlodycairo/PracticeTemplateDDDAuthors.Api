using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TecnicalTestLibrary.Api.Infrastructure.Entities;

namespace TecnicalTestLibrary.Api.Infrastructure.Repositories.IRepositories
{
    public interface IBookRepository : IBaseRepository<Book>
    {
        Task<IEnumerable<Book>> GetAllEntitiesAsync();
        Task<Book> GetEntityByIdAsync(int id);
        Task<Book> CreateEntityAsync(Book book);
        Task<Book> UpdateEntityAsync(Book book);
        Task DeleteEntityAsync(int id);
    }
}
