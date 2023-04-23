using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMarketAlex2.Core.Aplication.ViewModels.Categorias
{
    public class SaveCategoriaViewModel
    {
        public int IdCategoria { get; set; }
        [Required(ErrorMessage = "Debe colocar la descripcion")]
        public string Descripcion { get; set; }
        [Required(ErrorMessage = "Debe colocar el nombre")]
        public string Name { get; set; }

    }
}
