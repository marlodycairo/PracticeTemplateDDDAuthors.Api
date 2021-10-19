using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TecnicalTestLibrary.Api.Domain.QueryFiltersModels
{
    public class AuthorQueryFilterModel
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string CityOrigin { get; set; }
    }
}
