using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TecnicalTestLibrary.Api.Domain;
using TecnicalTestLibrary.Api.Domain.Commons.DTOs;
using TecnicalTestLibrary.Api.Domain.QueryFiltersModels;
using TecnicalTestLibrary.Api.Infrastructure.Entities;
using TecnicalTestLibrary.Api.Infrastructure.Repositories.IRepositories;

namespace TecnicalTestLibrary.Api.DomainService
{
    public class AuthorDomainService : IAuthorDomain
    {
        private readonly IAuthorRepository authorRepository;
        private readonly IMapper mapper;

        public AuthorDomainService(IAuthorRepository authorRepository, IMapper mapper)
        {
            this.authorRepository = authorRepository;
            this.mapper = mapper;
        }

        public async Task DeleteAuthorById(int id)
        {
            await authorRepository.DeleteEntityAsync(id);
        }

        public async Task<IEnumerable<AuthorDto>> GetAllAuthors(AuthorQueryFilterModel filter)
        {
            var authorsRepo = (await authorRepository.GetAllEntitiesAsync()).ToList();
            
            authorsRepo = Filtros(filter, authorsRepo);

            var authors = mapper.Map<IEnumerable<AuthorDto>>(authorsRepo);

            return authors;
        }

        private static List<Author> Filtros(AuthorQueryFilterModel filter, List<Author> authorsRepo)
        {
            if (filter.Id != 0)
            {
                authorsRepo = authorsRepo.Where(p => p.Id == filter.Id).ToList();
            }

            if (filter.FullName != null)
            {
                authorsRepo = authorsRepo.Where(p => p.FullName.StartsWith(filter.FullName, StringComparison.CurrentCultureIgnoreCase) == filter.FullName.StartsWith(filter.FullName, StringComparison.CurrentCultureIgnoreCase)).OrderBy(p => p.FullName).ToList();
            }

            if (filter.CityOrigin != null)
            {
                authorsRepo = authorsRepo.Where(p => p.CityOrigin.StartsWith(filter.CityOrigin, StringComparison.CurrentCultureIgnoreCase) == filter.CityOrigin.StartsWith(filter.CityOrigin, StringComparison.CurrentCultureIgnoreCase)).OrderBy(p => p.CityOrigin).ToList();
            }

            return authorsRepo;
        }

        public async Task<AuthorDto> GetAuthorById(int id)
        {
            var author = await authorRepository.GetEntityByIdAsync(id);

            var authorDto = mapper.Map<AuthorDto>(author);

            return authorDto;
        }

        public async Task<CreateANewAuthor> CreateAuthor(CreateANewAuthor author)
        {
            var newAuthor = mapper.Map<Author>(author);

            await authorRepository.CreateEntityAsync(newAuthor);

            return author;
        }

        public async Task<UpdateAuthor> UpdateAuthor(UpdateAuthor author)
        {
            var _author = mapper.Map<Author>(author);

            await authorRepository.UpdateEntityAsync(_author);

            return author;
        }
    }
}
