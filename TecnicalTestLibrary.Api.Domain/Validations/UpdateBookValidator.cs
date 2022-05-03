using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TecnicalTestLibrary.Api.Domain.Commons.DTOs;
using TecnicalTestLibrary.Api.Infrastructure.Entities;
using TecnicalTestLibrary.Api.Infrastructure.Repositories.IRepositories;

namespace TecnicalTestLibrary.Api.Domain.Validations
{
    public class UpdateBookValidator : AbstractValidator<UpdateBook>
    {
        private readonly IBookRepository bookRepo;

        public UpdateBookValidator(IBookRepository bookRepo)
        {
            this.bookRepo = bookRepo;

            RuleFor(book => book.Id)
                .Cascade(CascadeMode.Stop)
                .NotEmpty();

            RuleFor(book => book.Id)
                .Cascade(CascadeMode.Stop)
                .MustAsync(async (id, cancellation) =>
                {
                    return (await bookRepo.GetAllEntitiesAsync()).Any(x => x.Id == id);

                }).WithMessage("The book don't exist.");

            RuleFor(book => book.Title)
                .Cascade(CascadeMode.Stop)
                .NotEmpty();

            RuleFor(book => book.Date)
                .Cascade(CascadeMode.Stop)
                .NotEmpty();

            RuleFor(book => book.Genre)
                .Cascade(CascadeMode.Stop)
                .IsInEnum();

            RuleFor(book => book.NumberOfPages)
                .Cascade(CascadeMode.Stop)
                .GreaterThan(0)
                .NotEmpty();

            RuleFor(book => book.AuthorId)
                .Cascade(CascadeMode.Stop)
                .NotEmpty();

            RuleFor(book => book.AuthorId)
                .Cascade(CascadeMode.Stop)
                .MustAsync(async (authorId, cancellation) =>
                {
                    var book = (await bookRepo.GetAllEntitiesAsync()).Any(b => b.AuthorId == authorId);

                    return !book;

                }).WithMessage("The author don't exist.");
        }
    }
}
