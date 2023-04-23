using EMarketAlex2.Core.Aplication.Interfaces.Repositories;
using EMarketAlex2.Core.Domain.Entities;
using EMarketAlex2.Infraestructure.Persistence.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMarketAlex2.Infraestructure.Persistence.Repositories
{
    public class CategoryRepository:GenericRepository<Categorias>, ICategoriesRepository
    {
        private readonly Context _dbContext;

       public CategoryRepository(Context dbContext):base(dbContext)
        {
            _dbContext = dbContext;
        }   
    }
}
