using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TecnicalTestLibrary.Api.Application;
using TecnicalTestLibrary.Api.Domain;
using TecnicalTestLibrary.Api.Domain.Commons.DTOs;
using TecnicalTestLibrary.Api.Domain.QueryFiltersModels;

namespace TecnicalTestLibrary.Api.ApplicationService
{
    public class AuthorApplicationService : IAuthorApplication
    {
        private readonly IAuthorDomain authorDomain;

        public AuthorApplicationService(IAuthorDomain authorDomain)
        {
            this.authorDomain = authorDomain;
        }

        public async Task DeleteAuthorById(int id)
        {
            await authorDomain.DeleteAuthorById(id);
        }

        public async Task<IEnumerable<AuthorDto>> GetAllAuthors(AuthorQueryFilterModel filter)
        {
            return await authorDomain.GetAllAuthors(filter);
        }

        public async Task<AuthorDto> GetAuthorById(int id)
        {
            return await authorDomain.GetAuthorById(id);
        }

        public async Task<CreateANewAuthor> CreateAuthor(CreateANewAuthor author)
        {
            return await authorDomain.CreateAuthor(author);
        }

        public async Task<UpdateAuthor> UpdateAuthor(UpdateAuthor author)
        {
            return await authorDomain.UpdateAuthor(author);
        }
    }
}
