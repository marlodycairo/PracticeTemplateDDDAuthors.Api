using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TecnicalTestLibrary.Api.Domain.Models;
using TecnicalTestLibrary.Api.Infrastructure.Commons;
using TecnicalTestLibrary.Api.Infrastructure.Context;
using TecnicalTestLibrary.Api.Infrastructure.Entities;
using TecnicalTestLibrary.Api.Infrastructure.Repositories.IRepositories;

namespace TecnicalTestLibrary.Api.Domain.Validations
{
    public class AuthorValidator : AbstractValidator<Author>
    {
        private readonly IAuthorRepository authorRepo;

        public AuthorValidator(IAuthorRepository authorRepo)
        {
            //CascadeMode = CascadeMode.Stop;
            this.authorRepo = authorRepo;

            RuleFor(p => p.Id)
                .Cascade(CascadeMode.Stop)
                .Empty();

            RuleFor(c => c.Id)
                .Cascade(CascadeMode.Stop)
                .NotEmpty();

            RuleFor(p => p.Id)
                .Cascade(CascadeMode.Stop)
                .NotEmpty()
                .MustAsync(async (id, cancellation) =>
                {
                    var autores = await authorRepo.GetAll();

                    var autor = autores.Any(x => x.Id == id);

                    return !autor;

                }).WithMessage("ERROR!!! El Author ya existe.");

            RuleFor(p => p.FullName)
                .Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage("NO SE ACEPTAN CAMPOS VACIOS")
                .NotNull().WithMessage("DEBE INGRESAR UN NOMBRE")
                .MustAsync(async (name, cancellation) =>
                {
                    if (!string.IsNullOrEmpty(name))
                    {
                        var autores = await authorRepo.GetAll();

                        return autores.Any(x => x.FullName == name);
                    }

                    return false;

                 }).WithMessage("INGRESE EL NOMBRE COMPLETO");

            RuleFor(p => p.BirthDate).NotEmpty().WithMessage("The {PropertyName} is required.");

            RuleFor(p => p.CityOrigin)
                .Cascade(CascadeMode.Stop)
                .NotNull().WithMessage("DEBE INGRESAR LA CIUDAD")
                .NotEmpty().WithMessage("The {PropertyName} is required.");

            RuleFor(p => p.EMail)
                .Cascade(CascadeMode.Stop)
                .NotNull().WithMessage("INGRESE EL CORREO ELECTRONICO!!")
                .NotEmpty().WithMessage("The {PropertyName} is required.")
                .EmailAddress(FluentValidation.Validators.EmailValidationMode.Net4xRegex)
                .WithMessage("You must enter a valid EMail address.");
        }

    }
}
