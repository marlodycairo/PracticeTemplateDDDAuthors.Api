using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TecnicalTestLibrary.Api.Domain;
using TecnicalTestLibrary.Api.Domain.Models;
using TecnicalTestLibrary.Api.Domain.QueryFiltersModels;
using TecnicalTestLibrary.Api.Infrastructure.Entities;
using TecnicalTestLibrary.Api.Infrastructure.Repositories.IRepositories;

namespace TecnicalTestLibrary.Api.DomainService
{
    public class AuthorDomainService : IAuthorDomain
    {
        private readonly IAuthorRepository authorRepository;
        private readonly IMapper mapper;
        private readonly IBookRepository bookRepository;

        public AuthorDomainService(IAuthorRepository authorRepository, IMapper mapper, IBookRepository bookRepository)
        {
            this.authorRepository = authorRepository;
            this.mapper = mapper;
            this.bookRepository = bookRepository;
        }

        public async Task Delete(int id)
        {
            await authorRepository.Delete(id);
        }

        public async Task<IEnumerable<AuthorDto>> GetAll(AuthorQueryFilterModel filter)
        {
            var authorsRepo = await authorRepository.GetAll();

            var authors = mapper.Map<IEnumerable<AuthorDto>>(authorsRepo);

            if (filter.Id != 0)
            {
                authors = authors.Where(p => p.Id == filter.Id);
            }

            if (filter.FullName != null)
            {
                authors = authors.Where(p => p.FullName.StartsWith(filter.FullName, StringComparison.CurrentCultureIgnoreCase) == filter.FullName.StartsWith(filter.FullName, StringComparison.CurrentCultureIgnoreCase)).OrderBy(p => p.FullName).ToList();
            }

            if (filter.CityOrigin != null)
            {
                authors = authors.Where(p => p.CityOrigin.StartsWith(filter.CityOrigin, StringComparison.CurrentCultureIgnoreCase) == filter.CityOrigin.StartsWith(filter.CityOrigin, StringComparison.CurrentCultureIgnoreCase)).OrderBy(p => p.CityOrigin).ToList();
            }

            return authors;
        }

        public async Task<AuthorDto> GetById(int id)
        {
            var author = await authorRepository.GetById(id);

            var authorDto = mapper.Map<AuthorDto>(author);

            return authorDto;
        }

        public async Task<AuthorDto> Insert(AuthorDto authorDto)
        {
            var author = mapper.Map<Author>(authorDto);

            await authorRepository.Insert(author);

            return authorDto;
        }

        public async Task<AuthorDto> Update(AuthorDto authorDto)
        {
            var author = mapper.Map<Author>(authorDto);

            await authorRepository.Update(author);

            return authorDto;
        }
    }
}
