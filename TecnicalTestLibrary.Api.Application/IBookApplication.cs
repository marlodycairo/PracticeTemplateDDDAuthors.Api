using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TecnicalTestLibrary.Api.Domain.Models;
using TecnicalTestLibrary.Api.Domain.QueryFiltersModels;

namespace TecnicalTestLibrary.Api.Application
{
    public interface IBookApplication
    {
        Task<IEnumerable<BookDto>> GetAll(BookQueryFilterModel filter);
        Task<BookDto> GetById(int id);
        Task<BookDto> Insert(BookDto book);
        Task<BookDto> Update(BookDto book);
        Task Delete(int id);
    }
}
