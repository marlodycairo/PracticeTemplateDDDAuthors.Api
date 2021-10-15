using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TecnicalTestLibrary.Api.Domain;
using TecnicalTestLibrary.Api.Domain.Models;
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

        public async Task<IEnumerable<BookDto>> GetAll()
        {
            var books = await bookRepository.GetAll();

            var booksDto = mapper.Map<IEnumerable<BookDto>>(books);

            return booksDto;
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
