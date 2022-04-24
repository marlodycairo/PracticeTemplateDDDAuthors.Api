using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TecnicalTestLibrary.Api.Domain.Models;
using TecnicalTestLibrary.Api.Domain.QueryFiltersModels;

namespace TecnicalTestLibrary.Api.Domain
{
    public interface IAuthorDomain
    {
        Task<IEnumerable<AuthorDto>> GetAll(AuthorQueryFilterModel filter);
        Task<AuthorDto> GetById(int id);
        Task<AuthorDto> CreateAuthor(AuthorDto author);
        Task<AuthorDto> Update(AuthorDto author);
        Task Delete(int id);
    }
}
