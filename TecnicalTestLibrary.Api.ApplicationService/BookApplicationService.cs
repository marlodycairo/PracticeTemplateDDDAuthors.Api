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
    public class BookApplicationService : IBookApplication
    {
        private readonly IBookDomain bookDomain;

        public BookApplicationService(IBookDomain bookDomain)
        {
            this.bookDomain = bookDomain;
        }

        public async Task DeleteBook(int id)
        {
            await bookDomain.DeleteBook(id);
        }

        public async Task<IEnumerable<BookDto>> GetAllBooks(BookQueryFilterModel filter)
        {
            return await bookDomain.GetAllBooks(filter);
        }

        public async Task<BookDto> GetAuthorById(int id)
        {
            return await bookDomain.GetBookById(id);
        }

        public async Task<CreateANewBook> CreateBook(CreateANewBook book)
        {
            return await bookDomain.CreateBook(book);
        }

        public async Task<UpdateBook> UpdateBook(UpdateBook book)
        {
            return await bookDomain.UpdateBook(book);
        }
    }
}
