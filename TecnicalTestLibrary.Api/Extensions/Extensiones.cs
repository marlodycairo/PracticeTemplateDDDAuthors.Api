using Microsoft.Extensions.DependencyInjection;
using TecnicalTestLibrary.Api.Application;
using TecnicalTestLibrary.Api.ApplicationService;
using TecnicalTestLibrary.Api.Domain;
using TecnicalTestLibrary.Api.DomainService;
using TecnicalTestLibrary.Api.Infrastructure.Repositories;
using TecnicalTestLibrary.Api.Infrastructure.Repositories.IRepositories;

namespace TecnicalTestLibrary.Api.Extensions
{
    public static class Extensiones
    {
        public static void RegisterServicesLibrary(this IServiceCollection services)
        {
            services.AddTransient<IAuthorRepository, AuthorRepository>();
            services.AddTransient<IAuthorDomain, AuthorDomainService>();
            services.AddTransient<IAuthorApplication, AuthorApplicationService>();

            services.AddTransient<IBookRepository, BookRepository>();
            services.AddTransient<IBookDomain, BookDomainService>();
            services.AddTransient<IBookApplication, BookApplicationService>();

            services.AddTransient(typeof(IBaseRepository<>), typeof(BaseRepository<>));
        }
    }
}
