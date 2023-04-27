using EMarketAlex2.Core.Aplication.ViewModels.Anuncios;
using EMarketAlex2.Core.Domain.Entities;
using System;
using System.Collections.Generic;


namespace EMarketAlex2.Core.Aplication.ViewModels.Categorias
{
    public class CategoriasViewModel
    {
        public int IdCategoria { get; set; }
        public string Descripcion { get; set; }
        public string Name { get; set; }
        public int CantidadAnunciosCate { get; set; }

      public int CantidadUsuarioAnun { get; set; }

        public ICollection<AnuncioViewModel> Anuncios { get; set; }

    }
}
