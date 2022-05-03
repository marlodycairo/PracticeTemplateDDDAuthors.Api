using AutoMapper;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using System;
using System.Text.Json.Serialization;
using TecnicalTestLibrary.Api.Application;
using TecnicalTestLibrary.Api.ApplicationService;
using TecnicalTestLibrary.Api.Domain;
using TecnicalTestLibrary.Api.Domain.Filters;
using TecnicalTestLibrary.Api.Domain.Mappers;
using TecnicalTestLibrary.Api.Domain.Validations;
using TecnicalTestLibrary.Api.DomainService;
using TecnicalTestLibrary.Api.Extensions;
using TecnicalTestLibrary.Api.Infrastructure.Context;
using TecnicalTestLibrary.Api.Infrastructure.Repositories;
using TecnicalTestLibrary.Api.Infrastructure.Repositories.IRepositories;

namespace TecnicalTestLibrary.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            //services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            var mapperConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new AutoMapperProfile());
            });

            IMapper mapper = mapperConfig.CreateMapper();

            services.AddSingleton(mapper);

            services.AddMvc(options => options.Filters.Add<ValidationFilter>())
                .AddFluentValidation(fv =>
                fv.RegisterValidatorsFromAssemblies(AppDomain.CurrentDomain.GetAssemblies()));
                //fv.RegisterValidatorsFromAssemblyContaining<UpdateBookValidator>());

            services.AddDbContext<ApplicationDbContext>(options =>
            {
                options.UseSqlServer(Configuration.GetConnectionString("ConnectionDB"));
            });

            //Registro de los servicios
            //RegisterServicesLibraryApi(services);

            Extensiones.RegisterServicesLibrary(services);

            services.AddControllers(options =>
            {
                options.Filters.Add<GlobalExceptionFilter>();
            }).AddJsonOptions(opt =>
                opt.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.Preserve);

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "TecnicalTestLibrary.Api", Version = "v1" });
            });
        }

        //private static void RegisterServicesLibraryApi(IServiceCollection services)
        //{
        //    services.AddScoped<IAuthorRepository, AuthorRepository>();
        //    services.AddScoped<IAuthorDomain, AuthorDomainService>();
        //    services.AddScoped<IAuthorApplication, AuthorApplicationService>();

        //    services.AddScoped<IBookRepository, BookRepository>();
        //    services.AddScoped<IBookDomain, BookDomainService>();
        //    services.AddScoped<IBookApplication, BookApplicationService>();
        //}

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "TecnicalTestLibrary.Api v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
