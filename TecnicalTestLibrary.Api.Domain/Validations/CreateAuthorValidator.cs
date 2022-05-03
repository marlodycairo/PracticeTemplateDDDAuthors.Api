using FluentValidation;
using System.Linq;
using TecnicalTestLibrary.Api.Domain.Commons.DTOs;
using TecnicalTestLibrary.Api.Domain.Validations;
using TecnicalTestLibrary.Api.Infrastructure.Entities;
using TecnicalTestLibrary.Api.Infrastructure.Repositories.IRepositories;

namespace TecnicalTestLibrary.Api.Domain.Validations
{
    public class CreateAuthorValidator : AbstractValidator<CreateANewAuthor>
    {
        private readonly IAuthorRepository authorRepo;

        public CreateAuthorValidator(IAuthorRepository authorRepo)
        {
            this.authorRepo = authorRepo;

            RuleFor(p => p.FullName)
                .Cascade(CascadeMode.Stop)
                .NotEmpty();

            RuleFor(p => p.FullName)
                .Cascade(CascadeMode.Stop)
                .MustAsync(async (name, cancellation) =>
                {
                    var autores = (await authorRepo.GetAllEntitiesAsync()).Any(x => x.FullName == name);

                    return !autores;

                }).WithMessage("The author exist.");

            RuleFor(p => p.BirthDate)
                .Cascade(CascadeMode.Stop)
                .NotNull()
                .NotEmpty();

            RuleFor(p => p.CityOrigin)
                .Cascade(CascadeMode.Stop)
                .NotEmpty()
                .NotNull();

            RuleFor(p => p.EMail)
                .Cascade(CascadeMode.Stop)
                .NotNull().WithMessage("INGRESE EL CORREO ELECTRONICO!!")
                .NotEmpty().WithMessage("The {PropertyName} is required.");

            RuleFor(p => p.EMail)
                .Cascade(CascadeMode.Stop)
                .EmailAddress(FluentValidation.Validators.EmailValidationMode.Net4xRegex)
                .WithMessage("You must enter a valid EMail address.");
        }
    }
}
