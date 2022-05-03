using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TecnicalTestLibrary.Api.Application;
using TecnicalTestLibrary.Api.Domain.Commons.DTOs;
using TecnicalTestLibrary.Api.Domain.QueryFiltersModels;

namespace TecnicalTestLibrary.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly IBookApplication _book;

        public BooksController(IBookApplication book)
        {
            _book = book;
        }

        [HttpGet]
        public async Task<IEnumerable<BookDto>> GetAllBooks([FromQuery]BookQueryFilterModel filter)
        {
            var books = await _book.GetAllBooks(filter);

            return books;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<BookDto>> GetBookById(int id)
        {
            var bookById = await _book.GetAuthorById(id);

            return Ok(bookById);
        }

        [HttpPost]
        public async Task<ActionResult<CreateANewBook>> CreateBook(CreateANewBook book)
        {
            var newBook = await _book.CreateBook(book);

            return Ok(newBook);
        }

        [HttpPut]
        public async Task<ActionResult<UpdateBook>> UpdateBook(UpdateBook book)
        {
            var bookUpdated = await _book.UpdateBook(book);

            return Ok(bookUpdated);
        }

        [HttpDelete("{id}")]
        public async Task DeleteBook(int id)
        {
            await _book.DeleteBook(id);
        }
    }
}
