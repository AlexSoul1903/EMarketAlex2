using EMarketAlex2.Core.Aplication.Interfaces.Services;
using EMarketAlex2.Core.Aplication.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace EMarketAlex2.Core.Aplication
{

        
        //Extension Method es una aplicacion del patron de diseno Decorator que lo que hace es extender la posibilidad de los paquetes
    public static class ServiceRegistration
    {

        public static void addAplicationLayer(this IServiceCollection services, IConfiguration configuration)
        {
            #region "Services"

            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddTransient<IAnunciosServices, AnuncioService>();

           services.AddTransient<ICategoriasServices, CategoriasService>();

            services.AddTransient<IUserServices, UserService>();

            #endregion



        }



    }
}
