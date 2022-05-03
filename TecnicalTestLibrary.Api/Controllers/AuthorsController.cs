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
    public class AuthorsController : ControllerBase
    {
        private readonly IAuthorApplication _author;

        public AuthorsController(IAuthorApplication author)
        {
            _author = author;
        }

        [HttpGet]
        public async Task<IEnumerable<AuthorDto>> GetAllAuthors([FromQuery] AuthorQueryFilterModel filter)
        {
            var authors = await _author.GetAllAuthors(filter);

            return authors;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<AuthorDto>> GetAuthorById(int id)
        {
            var authorById = await _author.GetAuthorById(id);

            return Ok(authorById);
        }

        [HttpPost]
        public async Task<ActionResult<CreateANewAuthor>> CreateAuthor(CreateANewAuthor author)
        {
            var newAuthor = await _author.CreateAuthor(author);

            return Ok(newAuthor);
        }

        [HttpPut]
        public async Task<ActionResult<UpdateAuthor>> UpdateAuthor(UpdateAuthor author)
        {
            var authorUpdated = await _author.UpdateAuthor(author);

            return Ok(authorUpdated);
        }

        [HttpDelete("{id}")]
        public async Task DeleteAuthor(int id)
        {
            await _author.DeleteAuthorById(id);
        }
    }
}
