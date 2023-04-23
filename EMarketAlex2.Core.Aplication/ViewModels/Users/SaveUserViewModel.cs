using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMarketAlex2.Core.Aplication.ViewModels.Users
{
    public class SaveUserViewModel
    {


        public int Id { get; set; }
        [Required(ErrorMessage = "Debe colocar su nombre")]
        [DataType(DataType.Text)]
        public string Nombre { get; set; }
        [Required(ErrorMessage = "Debe colocar el Email")]
        [DataType(DataType.Text)]
        public string Email { get; set; }
        [Required(ErrorMessage = "Debe colocar el nombre del usuario")]
        [DataType(DataType.Text)]
        public string Username { get; set; }
        [Required(ErrorMessage = "Debe colocar un número de teléfono")]
        [DataType(DataType.PhoneNumber)]
        public string Phone { get; set; }
        [Required(ErrorMessage = "Debe colocar la contraseña")]
        [DataType(DataType.Text)]
        public string Password { get; set; }

        [Compare(nameof(Password), ErrorMessage = "Las contraseñas deben de ser iguales")]
        [Required(ErrorMessage = "Debe colocar la contraseña")]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }
        [Required(ErrorMessage = "Debe colocar la edad")]
        [DataType(DataType.Currency)]
        public int Edad { get; set; }

        public string ImgRoute { get; set; }

        [DataType(DataType.Upload)]
        public IFormFile File { get; set; }
    }
}
