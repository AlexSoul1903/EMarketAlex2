using EMarketAlex2.Core.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMarketAlex2.Core.Domain.Entities
{
    public class Users:AuditBaseEntity
    {
    

    public   int Id { get; set; }
       public string Nombre { get; set; }
       public string Email { get; set; }
        public string Username { get; set; }
        public string Phone { get; set; }
        public string Password { get; set; }
        public int Edad { get; set; }
        public int idEstatus { get; set; }
        public string ImgRoute { get; set; }
        public ICollection <Anuncios> anuncios { get; set; }



    }
}
