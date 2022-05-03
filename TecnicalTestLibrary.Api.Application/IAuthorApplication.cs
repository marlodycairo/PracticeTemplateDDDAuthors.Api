using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TecnicalTestLibrary.Api.Domain.Commons.DTOs;
using TecnicalTestLibrary.Api.Domain.QueryFiltersModels;

namespace TecnicalTestLibrary.Api.Application
{
    public interface IAuthorApplication
    {
        Task<IEnumerable<AuthorDto>> GetAllAuthors(AuthorQueryFilterModel filter);
        Task<AuthorDto> GetAuthorById(int id);
        Task<CreateANewAuthor> CreateAuthor(CreateANewAuthor author);
        Task<UpdateAuthor> UpdateAuthor(UpdateAuthor author);
        Task DeleteAuthorById(int id);
    }
}
