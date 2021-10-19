using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TecnicalTestLibrary.Api.Application;
using TecnicalTestLibrary.Api.Domain.Models;
using TecnicalTestLibrary.Api.Domain.QueryFiltersModels;

namespace TecnicalTestLibrary.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly IBookApplication book;

        public BooksController(IBookApplication book)
        {
            this.book = book;
        }

        [HttpGet]
        public async Task<IEnumerable<BookDto>> GetAllBooks([FromQuery]BookQueryFilterModel filter)
        {
            var books = await book.GetAll(filter);

            return books;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<BookDto>> GetBookById(int id)
        {
            var bookById = await book.GetById(id);

            return Ok(bookById);
        }

        [HttpPost]
        public async Task<ActionResult<BookDto>> CreateBook(BookDto bookDto)
        {
            var newBook = await book.Insert(bookDto);

            return Ok(newBook);
        }

        [HttpPut]
        public async Task<ActionResult<BookDto>> UpdateBook(BookDto bookDto)
        {
            var bookUpdated = await book.Update(bookDto);

            return Ok(bookUpdated);
        }

        [HttpDelete("{id}")]
        public async Task DeleteBook(int id)
        {
            await book.Delete(id);
        }
    }
}
