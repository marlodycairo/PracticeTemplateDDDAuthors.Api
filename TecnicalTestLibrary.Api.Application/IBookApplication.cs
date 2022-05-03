using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TecnicalTestLibrary.Api.Domain.Commons.DTOs;
using TecnicalTestLibrary.Api.Domain.QueryFiltersModels;

namespace TecnicalTestLibrary.Api.Application
{
    public interface IBookApplication
    {
        Task<IEnumerable<BookDto>> GetAllBooks(BookQueryFilterModel filter);
        Task<BookDto> GetAuthorById(int id);
        Task<CreateANewBook> CreateBook(CreateANewBook book);
        Task<UpdateBook> UpdateBook(UpdateBook book);
        Task DeleteBook(int id);
    }
}
