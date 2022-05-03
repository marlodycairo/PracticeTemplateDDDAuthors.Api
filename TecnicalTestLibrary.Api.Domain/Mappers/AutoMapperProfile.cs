using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TecnicalTestLibrary.Api.Domain.Commons.DTOs;
using TecnicalTestLibrary.Api.Infrastructure.Entities;

namespace TecnicalTestLibrary.Api.Domain.Mappers
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Author, AuthorDto>();
            //.ForMember(dest => dest.BookDtos, opt => opt.MapFrom(src => src.Books));

            CreateMap<AuthorDto, Author>();
            //.ForMember(dest => dest.Books, opt => opt.MapFrom(src => src.BookDtos));

            CreateMap<Author, CreateANewAuthor>();

            CreateMap<CreateANewAuthor, Author>();

            CreateMap<Author, UpdateAuthor>();

            CreateMap<UpdateAuthor, Author>();

            CreateMap<Book, BookDto>();
            //.ForMember(dest => dest.AuthorDto, opt => opt.MapFrom(src => src.Author));

            CreateMap<BookDto, Book>();
                //.ForMember(dest => dest.Author, opt => opt.MapFrom(src => src.AuthorDto));

            CreateMap<Book, CreateANewBook>();

            CreateMap<CreateANewBook, Book>();

            CreateMap<Book, UpdateBook>();

            CreateMap<UpdateBook, Book>();
        }
    }
}
