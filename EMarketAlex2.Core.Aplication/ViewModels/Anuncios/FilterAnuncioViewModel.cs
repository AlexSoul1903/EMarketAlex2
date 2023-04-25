using EMarketAlex2.Core.Aplication.ViewModels.Categorias;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMarketAlex2.Core.Aplication.ViewModels.Anuncios
{
    public class FilterAnuncioViewModel
    {
        public List<AnuncioViewModel> anuncioslist { get; set; }
        public List<CategoriasViewModel> Categorias { get; set; }
        public List<int> IdCategoria { get; set; }
        public string NombreAnuncio { get; set; }
        public int miUserId { get; set; }
        public int UserId { get; set; }
    }
}
