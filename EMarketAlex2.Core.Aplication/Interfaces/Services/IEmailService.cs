using EMarketAlex2.Core.Aplication.Dtos.Email;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMarketAlex2.Core.Aplication.Interfaces.Services
{
    public interface IEmailService
    {




        Task SendAsync(EmailRequest rq);
       


      
    }
}
