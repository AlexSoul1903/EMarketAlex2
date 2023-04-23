using EMarketAlex2.Core.Aplication.Helpers;
using EMarketAlex2.Core.Aplication.ViewModels.Users;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;

namespace EMarketAlex2.Middlewares
{
    public class ValidarSession
    {

        private readonly IHttpContextAccessor _httpContextAccessor;

        public ValidarSession(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }


        public bool VerificarUsuario()
        {

            UserViewModel userViewModel = _httpContextAccessor.HttpContext.Session.Get<UserViewModel>("usuario");

            if (userViewModel == null)
            {

                return false;
            }

            return true;

        }


    }
}
