using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace SERVICIOS
{
    public class DatosTraduccion
    {
        GestorConexion gd = new GestorConexion();
        GestorConexion gc = GestorConexion.INSTANCIA;
        public Dictionary<string, string> CargarTraduccion(string idioma)
        {
            gc.ActualizarGeneral();
            int idIdioma = 0;
            foreach (DataRowView drv in gd.DevolverTabla("Idioma").DefaultView)
            {
                if (drv[1].ToString() == idioma)
                {
                    idIdioma = int.Parse(drv[0].ToString());
                }
            }
            Dictionary<string, string> d = new Dictionary<string, string>();
            foreach (DataRowView drv in gd.DevolverTabla("Traduccion").DefaultView)
            {
                DataRow dr = gd.DevolverTabla("Etiqueta").Rows.Find(int.Parse(drv[0].ToString()));
                string textoTraducir = dr[1].ToString();
                if (int.Parse(drv[1].ToString()) == idIdioma)
                {
                    d.Add(textoTraducir, drv[2].ToString());
                }
            }
            int aux = d.Keys.Count;
            return d;
        }
    }
}
