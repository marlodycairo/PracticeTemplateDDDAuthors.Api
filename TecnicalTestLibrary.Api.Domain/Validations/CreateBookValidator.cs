using FluentValidation;
using System.Linq;
using TecnicalTestLibrary.Api.Domain.Commons.DTOs;
using TecnicalTestLibrary.Api.Infrastructure;
using TecnicalTestLibrary.Api.Infrastructure.Repositories.IRepositories;

namespace TecnicalTestLibrary.Api.Domain.Validations
{
    public class CreateBookValidator : AbstractValidator<CreateANewBook>
    {
        private readonly IBookRepository _bookRepo;

        public CreateBookValidator(IBookRepository bookRepo)
        {
            _bookRepo = bookRepo;

            RuleFor(book => book.Title)
                .Cascade(CascadeMode.Stop)
                .NotEmpty();

            RuleFor(book => book.Title)
            .Cascade(CascadeMode.Stop)
            .MustAsync(async (name, cancellation) =>
            {
                var book = (await bookRepo.GetAllEntitiesAsync()).Any(b => b.Title == name);

                return !book;

            }).WithMessage("The book exist.");

            RuleFor(book => book.Title)
                .Cascade(CascadeMode.Stop)
                .MustAsync(async (name, cancellation) =>
                {
                    var libros = (await bookRepo.GetAllEntitiesAsync()).Count();

                    return libros <= Constants.maximumAllowed;
                })
                .WithMessage("Unable to register the book, the maximum allowed has been reached");

            RuleFor(p => p.Date)
                .Cascade(CascadeMode.Stop)
                .NotNull()
                .NotEmpty();

            RuleFor(p => p.Genre)
                .Cascade(CascadeMode.Stop)
                .IsInEnum();

            RuleFor(p => p.NumberOfPages)
                .Cascade(CascadeMode.Stop)
                .GreaterThan(0)
                .NotNull()
                .NotEmpty();

            RuleFor(book => book.AuthorId)
                .Cascade(CascadeMode.Stop)
                .NotEmpty();

            RuleFor(book => book.AuthorId)
                .Cascade(CascadeMode.Stop)
                .MustAsync(async (autorId, cancellation) =>
                {
                    return (await bookRepo.GetAllEntitiesAsync()).Any(x => x.AuthorId == autorId);

                }).WithMessage("The author don't exist.");
        }
    }
}
