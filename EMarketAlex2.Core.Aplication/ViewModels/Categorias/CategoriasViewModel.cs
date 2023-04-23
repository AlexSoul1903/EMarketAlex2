using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMarketAlex2.Core.Aplication.ViewModels.Categorias
{
    public class CategoriasViewModel
    {
        public int IdCategoria { get; set; }
        public string Descripcion { get; set; }
        public string Name { get; set; }
        public int CantidadAnunciosCate { get; set; }

      public int CantidadUsuarioAnun { get; set; }


    }
}
