using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TecnicalTestLibrary.Api.Application;
using TecnicalTestLibrary.Api.Domain;
using TecnicalTestLibrary.Api.Domain.Models;
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

        public async Task Delete(int id)
        {
            await bookDomain.Delete(id);
        }

        public async Task<IEnumerable<BookDto>> GetAll(BookQueryFilterModel filter)
        {
            return await bookDomain.GetAll(filter);
        }

        public async Task<BookDto> GetById(int id)
        {
            return await bookDomain.GetById(id);
        }

        public async Task<BookDto> Insert(BookDto book)
        {
            return await bookDomain.Insert(book);
        }

        public async Task<BookDto> Update(BookDto book)
        {
            return await bookDomain.Update(book);
        }
    }
}
