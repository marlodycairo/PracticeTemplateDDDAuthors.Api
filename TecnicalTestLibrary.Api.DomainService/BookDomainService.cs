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
    public class BookDomainService : IBookDomain
    {
        private readonly IBookRepository bookRepository;
        private readonly IMapper mapper;

        public BookDomainService(IBookRepository bookRepository, IMapper mapper)
        {
            this.bookRepository = bookRepository;
            this.mapper = mapper;
        }

        public async Task DeleteBook(int id)
        {
            await bookRepository.DeleteEntityAsync(id);
        }

        public async Task<IEnumerable<BookDto>> GetAllBooks(BookQueryFilterModel filter)
        {
            var booksRepo = (await bookRepository.GetAllEntitiesAsync()).ToList();

            booksRepo = FiltroBook(filter, booksRepo);

            var books = mapper.Map<IEnumerable<BookDto>>(booksRepo);

            return books;
        }

        private static List<Book> FiltroBook(BookQueryFilterModel filter, List<Book> booksRepo)
        {
            if (filter.Id != 0)
            {
                booksRepo = booksRepo.Where(p => p.Id == filter.Id).ToList();
            }

            if (filter.Title != null)
            {
                booksRepo = booksRepo.Where(p => p.Title.StartsWith(filter.Title, StringComparison.CurrentCultureIgnoreCase) == filter.Title.StartsWith(filter.Title, StringComparison.CurrentCultureIgnoreCase)).OrderBy(p => p.Title).ToList();
            }

            if (filter.Genre != 0)
            {
                booksRepo = booksRepo.Where(p => Convert.ToString(p.Genre).StartsWith(Convert.ToString(filter.Genre), StringComparison.CurrentCultureIgnoreCase) == Convert.ToString(filter.Genre).StartsWith(Convert.ToString(filter.Genre), StringComparison.CurrentCultureIgnoreCase)).OrderBy(p => p.Title).ToList();
            }

            if (filter.Date != null)
            {
                booksRepo = booksRepo.Where(p => p.Date.ToString() == filter.Date.ToString()).ToList();
            }

            return booksRepo;
        }

        public async Task<BookDto> GetBookById(int id)
        {
            var book = await bookRepository.GetEntityByIdAsync(id);

            var bookDto = mapper.Map<BookDto>(book);

            return bookDto;
        }

        public async Task<CreateANewBook> CreateBook(CreateANewBook bookDto)
        {
            var book = mapper.Map<Book>(bookDto);

            await bookRepository.CreateEntityAsync(book);

            return bookDto;
        }

        public async Task<UpdateBook> UpdateBook(UpdateBook book)
        {
            var _book = mapper.Map<Book>(book);

            await bookRepository.UpdateEntityAsync(_book);

            return book;
        }
    }
}
