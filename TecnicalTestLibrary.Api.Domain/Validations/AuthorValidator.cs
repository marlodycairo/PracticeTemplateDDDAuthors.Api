using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TecnicalTestLibrary.Api.Domain.Models;

namespace TecnicalTestLibrary.Api.Domain.Validations
{
    public class AuthorValidator : AbstractValidator<AuthorDto>
    {
        public AuthorValidator()
        {
            RuleFor(p => p.FullName).NotNull()
                .NotEmpty().WithMessage("You must enter the {PropertyName} is required.");

            RuleFor(p => p.BirthDate).NotEmpty().WithMessage("The {PropertyName} is required.");

            RuleFor(p => p.CityOrigin).NotNull()
                .NotEmpty().WithMessage("The {PropertyName} is required.");

            RuleFor(p => p.EMail).NotNull()
                .NotEmpty().WithMessage("The {PropertyName} is required.")
                .EmailAddress(FluentValidation.Validators.EmailValidationMode.Net4xRegex).WithMessage("You must enter a valid EMail address.");
        }
    }
}
