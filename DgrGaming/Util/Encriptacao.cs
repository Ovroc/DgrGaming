using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace DgrGaming.Util
{
    public class Encriptacao
    {
        public static string Encriptar(string stringOriginal)
        {
            var cripto = new System.Security.Cryptography.SHA256Managed();
            var stringCodificada = new System.Text.StringBuilder();
            byte[] hash = cripto.ComputeHash(Encoding.UTF8.GetBytes(stringOriginal));
            foreach (byte B in hash)
            {
                stringCodificada.Append(B.ToString("x2"));
            }
            return stringCodificada.ToString();
        }
    }
}