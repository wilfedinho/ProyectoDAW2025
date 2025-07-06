using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SERVICIOS
{
    public class BackUp
    {
        public bool GenerarBackUp()
        {
            try
            {
                string carpetaDescargas = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile), "Downloads");
                string archivoBackUp = Path.Combine(carpetaDescargas, "BackUp.bak");
                string bdActual = "BD_PROYECTODAW";
                string consulta = $@"BACKUP DATABASE [{bdActual}] TO DISK = '{archivoBackUp}'";
                using (SqlConnection con = new SqlConnection("Data Source=.;Initial Catalog=BD_PROYECTODAW;Integrated Security=True"))
                {
                    con.Open();
                    using (SqlCommand cmd = new SqlCommand(consulta, con))
                    {
                        cmd.ExecuteNonQuery();
                    }
                }
                return true;
            }
            catch { return false; }
        }
    }
}
