using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMarketAlex2.Core.Domain.Entities
{
    public class Categorias
    {

        public int IdCategoria { get; set; }
        public string Descripcion { get; set; }
        public string Name { get; set; }

        public ICollection<Anuncios> Anuncios { get; set; }

    }
}
