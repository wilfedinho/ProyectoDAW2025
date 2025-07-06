using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DigitoVerificadorDAL
    {
        public string ObtenerDVV(string nombreTabla)
        {
            using (SqlConnection cone = GestorConexion.DevolverConexion())
            {
                var cmd = new SqlCommand(
                    "SELECT DVV FROM DigitoVerificador WHERE NombreTabla = @NombreTabla", cone);
                cmd.Parameters.AddWithValue("@NombreTabla", nombreTabla);
                cone.Open();
                return cmd.ExecuteScalar()?.ToString();
            }
        }
        public void ActualizarDVV(string nombreTabla, string nuevoDVV)
        {
            using (SqlConnection cone = GestorConexion.DevolverConexion())
            {
                cone.Open();
                var cmd = new SqlCommand(
                     @"MERGE INTO DigitoVerificador AS target
                        USING (SELECT @Tabla AS Tabla, @DVV AS DVV) AS source
                        ON target.Tabla = source.Tabla
                        WHEN MATCHED THEN
                        UPDATE SET DVV = source.DVV
                        WHEN NOT MATCHED THEN
                        INSERT (Tabla, DVV) VALUES (source.Tabla, source.DVV);",
                     cone);
                cmd.Parameters.AddWithValue("@Tabla", nombreTabla);
                cmd.Parameters.AddWithValue("@DVV", nuevoDVV);
                cmd.ExecuteNonQuery();
            }
        }
    }
}
