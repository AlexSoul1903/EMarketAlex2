using EMarketAlex2.Core.Aplication.Interfaces.Services;
using EMarketAlex2.Core.Aplication.Services;
using EMarketAlex2.Core.Domain.Settings;
using EMarketAlex2.Infraestructure.Shared.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMarketAlex2.Infraestructure.Shared
{

        
        //Extension Method es una aplicacion del patron de diseno Decorator que lo que hace es extender la posibilidad de los paquetes
    public static class ServiceRegistration
    {

        public static void addSharedInfraestructure(this IServiceCollection services, IConfiguration configuration)
        {

            services.Configure<MailSettings>(configuration.GetSection("MailSettings"));


            services.AddTransient<IEmailService, EmailService>();

        }



    }
}
