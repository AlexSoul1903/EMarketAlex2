using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMarketAlex2.Core.Aplication.ViewModels.Users
{
    public class LoginUserViewModel
    {


        [Required(ErrorMessage = "Debe colocar el nombre del usuario")]
        [DataType(DataType.Text)]
        public string Username { get; set; }

        [Required(ErrorMessage = "Debe colocar la contraseña")]
        [DataType(DataType.Text)]
        public string Password { get; set; }

    }
}
