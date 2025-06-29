using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;

namespace DAL.Tecnica
{
    public class BitacoraDAL
    {
        public void Alta490WC(Bitacora bitacoraAlta)
        {
            using (SqlConnection cone = GestorConexion490WC.DevolverConexion())
            {
                cone.Open();

                string query = @"INSERT INTO Bitacora (Username, Fecha, Hora, Modulo, Descripcion, Criticidad) VALUES (@Username, @Fecha, @Hora, @Modulo, @Descripcion, @Criticidad)";

                using (SqlCommand comando = new SqlCommand(query, cone))
                {
                    comando.Parameters.AddWithValue("@Username", bitacoraAlta.Username);
                    comando.Parameters.AddWithValue("@Fecha", bitacoraAlta.Fecha);
                    comando.Parameters.AddWithValue("@Hora", bitacoraAlta.Hora);
                    comando.Parameters.AddWithValue("@Modulo", bitacoraAlta.Modulo);
                    comando.Parameters.AddWithValue("@Descripcion", bitacoraAlta.Descripcion);
                    comando.Parameters.AddWithValue("@Criticidad", bitacoraAlta.Criticidad);

                    comando.ExecuteNonQuery();
                }
            }
        }

        public List<Bitacora> ObtenerEventosPorConsulta490WC(string usuarioFiltrar490WC = "", string moduloFiltrar490WC = "", string descripcionFiltrar490WC = "", string criticidadFiltrar490WC = "", DateTime? fechaInicioFiltrar490WC = null, DateTime? fechaFinFiltrar490WC = null)
        {
            List<Bitacora> listaBitacora490WC = new List<Bitacora>();

            using (SqlConnection cone = GestorConexion490WC.DevolverConexion())
            {
                cone.Open();

                List<string> condiciones = new List<string>();
                SqlCommand comando = new SqlCommand();
                comando.Connection = cone;

                string query = "SELECT IdBitacora, Username, Fecha, Hora, Modulo, Descripcion, Criticidad FROM Bitacora WHERE 1=1";

                if (!string.IsNullOrEmpty(usuarioFiltrar490WC))
                {
                    condiciones.Add("Username = @Username");
                    comando.Parameters.AddWithValue("@Username", usuarioFiltrar490WC);
                }
                if (!string.IsNullOrEmpty(moduloFiltrar490WC))
                {
                    condiciones.Add("Modulo = @Modulo");
                    comando.Parameters.AddWithValue("@Modulo", moduloFiltrar490WC);
                }
                if (!string.IsNullOrEmpty(descripcionFiltrar490WC))
                {
                    condiciones.Add("Descripcion = @Descripcion");
                    comando.Parameters.AddWithValue("@Descripcion", descripcionFiltrar490WC);
                }
                if (!string.IsNullOrEmpty(criticidadFiltrar490WC))
                {
                    condiciones.Add("Criticidad = @Criticidad");
                    comando.Parameters.AddWithValue("@Criticidad", criticidadFiltrar490WC);
                }
                if (fechaInicioFiltrar490WC.HasValue)
                {
                    condiciones.Add("Fecha >= @FechaInicio");
                    comando.Parameters.AddWithValue("@FechaInicio", fechaInicioFiltrar490WC.Value.Date);
                }
                if (fechaFinFiltrar490WC.HasValue)
                {
                    condiciones.Add("Fecha <= @FechaFin");
                    comando.Parameters.AddWithValue("@FechaFin", fechaFinFiltrar490WC.Value.Date);
                }

                if (condiciones.Count > 0)
                {
                    query += " AND " + string.Join(" AND ", condiciones);
                }

                comando.CommandText = query;

                using (SqlDataReader reader = comando.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        int idBitacora = reader.GetInt32(0);
                        string username = reader.GetString(1);
                        DateTime fecha = reader.GetDateTime(2).Date;
                        TimeSpan hora = reader.GetTimeSpan(3);
                        string modulo = reader.GetString(4);
                        string descripcion = reader.GetString(5);
                        int criticidad = reader.GetInt32(6);

                        Bitacora bitacora = new Bitacora(username, fecha, hora, modulo, descripcion, criticidad, idBitacora);
                        listaBitacora490WC.Add(bitacora);
                    }
                }
            }

            return listaBitacora490WC;
        }



    }
}
