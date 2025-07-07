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
        public bool GenerarBackUp(out string mensaje)
        {
            mensaje = "";

            try
            {
                string carpetaBackup = @"C:\BackupsSQL";

                if (!Directory.Exists(carpetaBackup))
                    Directory.CreateDirectory(carpetaBackup);

                string nombreArchivo = $"Backup_{DateTime.Now:ddMMyyyy_HHmmss}.bak";
                string archivoBackUp = Path.Combine(carpetaBackup, nombreArchivo);

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

                mensaje = $"✔️ Backup generado correctamente en: {archivoBackUp}";
                return true;
            }
            catch (Exception ex)
            {
                mensaje = $"❌ Error al generar backup: {ex.Message}";
                return false;
            }
        }

        public bool RestaurarBaseDeDatos(string rutaArchivoBak, out string mensaje)
        {
            mensaje = "";
            string nombreDB = "BD_PROYECTODAW";

            try
            {
                using (SqlConnection con = new SqlConnection("Data Source=.;Initial Catalog=master;Integrated Security=True"))
                {
                    con.Open();

                    string consultaRestore = $@"
                        RESTORE DATABASE [{nombreDB}] 
                        FROM DISK = '{rutaArchivoBak}' 
                        WITH REPLACE";

                    using (SqlCommand cmdRestore = new SqlCommand(consultaRestore, con))
                    {
                        cmdRestore.ExecuteNonQuery();
                    }

                    string repararLogin = $@"
                        USE [{nombreDB}];
                        IF EXISTS (SELECT * FROM sys.database_principals WHERE name = 'Santi')
                        BEGIN
                        ALTER USER [Santi] WITH LOGIN = [DESKTOP-541PG3B\Santi];
                        END";

                    using (SqlCommand cmdReparar = new SqlCommand(repararLogin, con))
                    {
                        cmdReparar.ExecuteNonQuery();
                    }
                }

                mensaje = "✅ Restauración realizada correctamente.";
                return true;
            }
            catch (Exception ex)
            {
                mensaje = "❌ Error al restaurar la base de datos: " + ex.Message;
                return false;
            }
        }

    }
    
}
