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
    public class BookDomainService : IBookDomain
    {
        private readonly IBookRepository bookRepository;
        private readonly IMapper mapper;

        public BookDomainService(IBookRepository bookRepository, IMapper mapper)
        {
            this.bookRepository = bookRepository;
            this.mapper = mapper;
        }

        public async Task Delete(int id)
        {
            await bookRepository.Delete(id);
        }

        public async Task<IEnumerable<BookDto>> GetAll(BookQueryFilterModel filter)
        {
            var booksRepo = await bookRepository.GetAll();

            var books = mapper.Map<IEnumerable<BookDto>>(booksRepo);

            if (filter.Id != 0)
            {
                books = books.Where(p => p.Id == filter.Id);
            }

            if (filter.Title != null)
            {
                books = books.Where(p => p.Title.StartsWith(filter.Title, StringComparison.CurrentCultureIgnoreCase) == filter.Title.StartsWith(filter.Title, StringComparison.CurrentCultureIgnoreCase)).OrderBy(p => p.Title).ToList();
            }

            if (filter.Genre != 0)
            {
                books = books.Where(p => Convert.ToString(p.Genre).StartsWith(Convert.ToString(filter.Genre), StringComparison.CurrentCultureIgnoreCase) == Convert.ToString(filter.Genre).StartsWith(Convert.ToString(filter.Genre), StringComparison.CurrentCultureIgnoreCase)).OrderBy(p => p.Title).ToList();
            }

            if (filter.Date != null)
            {
                books = books.Where(p => p.Date.ToString() == filter.Date.ToString());
            }

            return books;
        }

        public async Task<BookDto> GetById(int id)
        {
            var book = await bookRepository.GetById(id);

            var bookDto = mapper.Map<BookDto>(book);

            return bookDto;
        }

        public async Task<BookDto> Insert(BookDto bookDto)
        {
            var book = mapper.Map<Book>(bookDto);

            await bookRepository.Insert(book);

            return bookDto;
        }

        public async Task<BookDto> Update(BookDto bookDto)
        {
            var book = mapper.Map<Book>(bookDto);

            await bookRepository.Update(book);

            return bookDto;
        }
    }
}
