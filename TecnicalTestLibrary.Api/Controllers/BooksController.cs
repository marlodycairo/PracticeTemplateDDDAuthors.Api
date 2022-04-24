using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TecnicalTestLibrary.Api.Application;
using TecnicalTestLibrary.Api.Domain.Models;

namespace TecnicalTestLibrary.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly IBookApplication bookApplication;

        public BooksController(IBookApplication bookApplication)
        {
            this.bookApplication = bookApplication;
        }

        [HttpGet]
        public async Task<IEnumerable<BookDto>> GetAllBooks()
        {
            var books = await bookApplication.GetAll();

            return books;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<BookDto>> GetBookById(int id)
        {
            var bookById = await bookApplication.GetById(id);

            return Ok(bookById);
        }

        [HttpPost]
        public async Task<ActionResult<BookDto>> CreateAuthor(BookDto bookDto)
        {
            var newBook = await bookApplication.Insert(bookDto);

            return Ok(newBook);
        }

        [HttpPut]
        public async Task<ActionResult<BookDto>> UpdateAuthor(BookDto bookDto)
        {
            var bookUpdated = await bookApplication.Update(bookDto);

            return Ok(bookUpdated);
        }

        [HttpDelete("{id}")]
        public async Task DeleteAuthor(int id)
        {
            await bookApplication.Delete(id);
        }
    }
}
