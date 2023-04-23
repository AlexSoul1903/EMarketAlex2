using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMarketAlex2.Core.Aplication.Helpers
{
    public static class Session
    {
        public static void Set<S>(this ISession session, string key, S valor)
        {
            session.SetString(key, JsonConvert.SerializeObject(valor));

        }
        //Obtener Json
        public static S Get<S>(this ISession session, string key)
        {

            var valor = session.GetString(key);
            return valor == null ? default : JsonConvert.DeserializeObject<S>(valor);


        }
    }
}