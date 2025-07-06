using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SERVICIOS
{
    public class GestorDigitoVerificador
    {

        public static string CalcularDVHRegistro(object[] valoresCampos)
        {
            StringBuilder sb = new StringBuilder();
            foreach(var valor in valoresCampos)
            {
                if (valor != null)
                {
                    sb.Append(valor?.ToString() ?? "NULL");
                    sb.Append(",");
                }
                if (sb.Length > 0) sb.Length--;
            }
            return new Encryptador().EncryptadorIrreversible(sb.ToString());

        }
        
    }
}

