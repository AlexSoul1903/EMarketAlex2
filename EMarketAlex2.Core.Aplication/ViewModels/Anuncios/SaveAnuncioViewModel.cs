using EMarketAlex2.Core.Aplication.ViewModels.Categorias;
using EMarketAlex2.Core.Domain.Common;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMarketAlex2.Core.Aplication.ViewModels.Anuncios
{
    public class SaveAnuncioViewModel:AuditBaseEntity
    {

   
        public int IdAnuncio { get; set; }
        [Required(ErrorMessage ="Debe de colocarle un nombre al anuncio.")]
        [DataType(DataType.Text)]
        public string nombre_anuncio { get; set; }
        [Required(ErrorMessage ="El anuncio debe contener una descripción.")]
        public string descripcion { get; set; }
        [Required(ErrorMessage ="El anuncio debe tener un valor de precio")]
        [RegularExpression(@"^[0-9]*$", ErrorMessage = "Debe ingresar un número.")]
        [Range(1,double.MaxValue,ErrorMessage ="Debe ser un numero positivo mayor o igual que uno")]
        [DataType(DataType.Currency)]
        public int precio { get; set; }
        [Range(1, int.MaxValue, ErrorMessage = "Debe colocar la categoria del anuncio")]
        public int miCategoriaId { get; set; }
        public int miUserId { get; set; }


        [DataType(DataType.Text)]
        public string Imagen1 { get; set; }
        [DataType(DataType.Text)]
        public string? Imagen2 { get; set; }
        [DataType(DataType.Text)]
        public string? Imagen3 { get; set; }
        [DataType(DataType.Text)]
        public string? Imagen4 { get; set; }
        [DataType(DataType.Text)]
        public string? Imagen5 { get; set; }

        [Required(ErrorMessage = "Debe haber almenos 1 imagen")]
        [DataType(DataType.Upload)]
        public IFormFile File1 { get; set; }

        [DataType(DataType.Upload)]
        public IFormFile File2 { get; set; }

        [DataType(DataType.Upload)]
        public IFormFile File3 { get; set; }
        [DataType(DataType.Upload)]
        public IFormFile File4 { get; set; }
        [DataType(DataType.Upload)]
        public IFormFile File5 { get; set; }

        public List<CategoriasViewModel> CategoriaList { get; set; }
        public string CategoryName { get; set; }
    }


   

}

 