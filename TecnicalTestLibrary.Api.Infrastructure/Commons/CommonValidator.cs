using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TecnicalTestLibrary.Api.Infrastructure.Entities;
using TecnicalTestLibrary.Api.Infrastructure.Repositories.IRepositories;

namespace TecnicalTestLibrary.Api.Infrastructure.Commons
{
    public class CommonValidator
    {
        private readonly IAuthorRepository authorRepo;

        public CommonValidator(IAuthorRepository authorRepo)
        {
            this.authorRepo = authorRepo;
        }

        
    }
}
