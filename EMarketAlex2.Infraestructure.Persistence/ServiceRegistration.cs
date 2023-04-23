using EMarketAlex2.Core.Aplication.Interfaces.Repositories;
using EMarketAlex2.Infraestructure.Persistence.Contexts;
using EMarketAlex2.Infraestructure.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMarketAlex2.Infraestructure.Persistence
{
    public static class ServiceRegistration
    {
        //Extension Method es una aplicacion del patron de diseno Decorator que lo que hace es extender la posibilidad de los paquetes
        public static void AddPersistenceInfraestructure(this IServiceCollection services, IConfiguration configuration)
        {


            #region "Contexts"

            if (configuration.GetValue<bool>("UseInMemoryDatabase"))
            {

                services.AddDbContext<Context>(options => options.UseInMemoryDatabase("AppDb"));



            }
            else
            {

                services.AddDbContext<Context>(options => options.UseSqlServer(configuration.GetConnectionString
                    ("DefaultConnection"), migration => migration.MigrationsAssembly(typeof(Context).Assembly.FullName)));

            }

            #endregion


            #region "Repositories"

            services.AddTransient(typeof(IGenericRespository<>), typeof(GenericRepository<>));

            services.AddTransient<IAnuncioRepository, AnuncioRepository>();

            services.AddTransient<ICategoriesRepository, CategoryRepository>();

            services.AddTransient<IUserRepository, UserRepository>();

            #endregion



        }


    }
}
