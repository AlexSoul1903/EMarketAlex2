using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace EMarketAlex2.Core.Aplication.Helpers
{
    public class PasswordEncryptation
    {

        public static string ComputeSha256HashEncrypt(string contra)
        {

            //Crear a el SHA256

            using (SHA256 sha256HashEncrypt = SHA256.Create())
            {
                byte[] bytes = sha256HashEncrypt.ComputeHash(Encoding.UTF8.GetBytes(contra));


                //Convertir el arreglo de bytes a String

                StringBuilder builder = new();

                for (int i = 0; i < bytes.Length; i++)
                {

                    builder.Append(bytes[i]).ToString();


                }

                return builder.ToString();
            }

        }

    }

}
