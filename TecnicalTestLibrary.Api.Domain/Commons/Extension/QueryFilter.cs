using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TecnicalTestLibrary.Api.Domain.QueryFiltersModels;
using TecnicalTestLibrary.Api.Infrastructure.Entities;

namespace TecnicalTestLibrary.Api.Domain.Commons.Extension
{
    public static class QueryFilter
    {
        //public static List<Author> Filtros(AuthorQueryFilterModel filter, List<Author> authorsRepo)
        //{
        //    if (filter.Id != 0)
        //    {
        //        authorsRepo = authorsRepo.Where(p => p.Id == filter.Id).ToList();
        //    }

        //    if (filter.FullName != null)
        //    {
        //        authorsRepo = authorsRepo.Where(p => p.FullName.StartsWith(filter.FullName, StringComparison.CurrentCultureIgnoreCase) == filter.FullName.StartsWith(filter.FullName, StringComparison.CurrentCultureIgnoreCase)).OrderBy(p => p.FullName).ToList();
        //    }

        //    if (filter.CityOrigin != null)
        //    {
        //        authorsRepo = authorsRepo.Where(p => p.CityOrigin.StartsWith(filter.CityOrigin, StringComparison.CurrentCultureIgnoreCase) == filter.CityOrigin.StartsWith(filter.CityOrigin, StringComparison.CurrentCultureIgnoreCase)).OrderBy(p => p.CityOrigin).ToList();
        //    }

        //    return authorsRepo;
        //}
    }
}
