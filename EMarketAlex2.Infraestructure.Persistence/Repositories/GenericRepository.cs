using EMarketAlex2.Core.Aplication.Interfaces.Repositories;
using EMarketAlex2.Infraestructure.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMarketAlex2.Infraestructure.Persistence.Repositories
{
    public class GenericRepository<Entidad> : IGenericRespository<Entidad> where Entidad : class
    {

        private readonly Context _dbContext;

            public GenericRepository(Context dbContext)
        {

            _dbContext = dbContext;
        }

        public virtual async Task<Entidad> AddAsync(Entidad entidad)
        {

            await _dbContext.Set<Entidad>().AddAsync(entidad);

            await _dbContext.SaveChangesAsync();

            return entidad;
          

        }

        public virtual async Task DeleteAsync(Entidad entidad, int id)
        {
            _dbContext.Remove(entidad);

            await _dbContext.SaveChangesAsync();

           
        }

        public virtual async Task<List<Entidad>> GetAllAsync()
        {

            return await _dbContext.Set<Entidad>().ToListAsync();

        }


        public virtual async Task<Entidad> GetByIdAsync(int Id)
        {
            return await _dbContext.Set<Entidad>().FindAsync(Id);
        }

        public virtual async Task UpdateAsync(Entidad entidad, int id)
        {

            Entidad entry = await _dbContext.Set<Entidad>().FindAsync(id);
            _dbContext.Entry(entry).CurrentValues.SetValues(entidad);
            await _dbContext.SaveChangesAsync();

        }

     public virtual  async Task<List<Entidad>> GetAllWithIncludeAsync(List<string> propiedades)
        {

            var qr = _dbContext.Set<Entidad>().AsQueryable();

            foreach (string propiedad in propiedades)
            {

                qr = qr.Include(propiedad);

            }

            return await qr.ToListAsync();


        }
    }
}
