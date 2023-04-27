using EMarketAlex2.Core.Aplication.ViewModels.Categorias;
using EMarketAlex2.Core.Aplication.ViewModels.Users;
using EMarketAlex2.Core.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMarketAlex2.Core.Aplication.ViewModels.Anuncios
{
    public class AnuncioViewModel:AuditBaseEntity {
          public int IdAnuncio { get; set; }
    public string nombre_anuncio { get; set; }
    public string descripcion { get; set; }
    public int precio { get; set; }
     public string Imagen1 { get; set; }
        public string Imagen2 { get; set; }
        public string Imagen3 { get; set; }
        public string Imagen4 { get; set; }
        public string Imagen5 { get; set; }
        public int miUserId { get; set; }
        public string userName { get; set; }
        public string CategoryName { get; set; }
        public int miCategoriaId {get; set; }


        public UserViewModel user { get; set; }
        public CategoriasViewModel categorias { get; set; }
    }


}
