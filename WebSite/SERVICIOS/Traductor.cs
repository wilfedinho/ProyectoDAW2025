using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Collections.Specialized.BitVector32;

namespace SERVICIOS
{
    public class Traductor
    {
        DatosTraduccion dt = new DatosTraduccion();
        Dictionary<string, string> d;
        private static Traductor instancia;

        public static Traductor INSTANCIA(string idioma)
        {
            if (instancia == null)
                instancia = new Traductor(idioma);

            return instancia;
        }


        public Traductor(string idioma)
        {
            try
            {
                ActualizarIdioma(idioma);
            }
            catch { ActualizarIdioma("Español"); }
        }

        

        public void ActualizarIdioma(string idioma)
        {
            d = dt.CargarTraduccion(idioma);
        }

        public string Traducir(string textoTraducir, string pIdioma)
        {
            try
            {
                return d[textoTraducir].ToString();
            }
            catch { return textoTraducir; }
        }
    }
}
