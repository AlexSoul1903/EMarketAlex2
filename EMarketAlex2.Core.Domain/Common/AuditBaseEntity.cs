using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMarketAlex2.Core.Domain.Common
{
   public class AuditBaseEntity
    {

        public string CreatedBy { get; set; }

        public string ModifiedBy { get; set; }

        public DateTime CreatedDate{ get; set; }
        public DateTime? ModifiedDate {get; set; }
    }

}
