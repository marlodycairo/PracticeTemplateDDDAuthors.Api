using FluentValidation;
using System.Linq;
using TecnicalTestLibrary.Api.Domain.Commons.DTOs;
using TecnicalTestLibrary.Api.Infrastructure.Repositories.IRepositories;

namespace TecnicalTestLibrary.Api.Domain.Validations
{
    public class UpdateAuthorValidator : AbstractValidator<UpdateAuthor>
    {
        private readonly IAuthorRepository authorRepo;

        public UpdateAuthorValidator(IAuthorRepository authorRepo)
        {
            this.authorRepo = authorRepo;

            RuleFor(author => author.Id)
                .Cascade(CascadeMode.Stop)
                .NotEmpty();

            RuleFor(author => author.Id)
                .Cascade(CascadeMode.Stop)
                .MustAsync(async (id, cancellation) =>
                {
                    return (await authorRepo.GetAllEntitiesAsync()).Any(x => x.Id == id);

                }).WithMessage("The author don´t exist.");

            RuleFor(author => author.FullName)
                .Cascade(CascadeMode.Stop)
                .NotEmpty();

            RuleFor(author => author.BirthDate)
                .Cascade(CascadeMode.Stop)
                .NotEmpty();

            RuleFor(author => author.CityOrigin)
                .Cascade(CascadeMode.Stop)
                .NotEmpty();

            RuleFor(author => author.EMail)
                .Cascade(CascadeMode.Stop)
                .NotNull()
                .NotEmpty().WithMessage("The {PropertyName} is required.");

            RuleFor(author => author.EMail)
                .Cascade(CascadeMode.Stop)
                .EmailAddress(FluentValidation.Validators.EmailValidationMode.Net4xRegex)
                .WithMessage("You must enter a valid EMail address.");
        }
    }
}
