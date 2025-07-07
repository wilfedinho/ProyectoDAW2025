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
        public Bitacora Alta(Bitacora bitacoraAlta)
        {
            int idBitacoraGenerado = 0; 
            using (SqlConnection cone = GestorConexion.DevolverConexion())
            {
                cone.Open();

                string query = @"INSERT INTO Bitacora (NombreUsuario, Fecha, Hora, Modulo, Descripcion, Criticidad) VALUES (@Username, @Fecha, @Hora, @Modulo, @Descripcion, @Criticidad); SELECT SCOPE_IDENTITY();";

                using (SqlCommand comando = new SqlCommand(query, cone))
                {
                    comando.Parameters.AddWithValue("@Username", bitacoraAlta.Username);
                    comando.Parameters.AddWithValue("@Fecha", bitacoraAlta.Fecha);
                    comando.Parameters.AddWithValue("@Hora", bitacoraAlta.Hora);
                    comando.Parameters.AddWithValue("@Modulo", bitacoraAlta.Modulo);
                    comando.Parameters.AddWithValue("@Descripcion", bitacoraAlta.Descripcion);
                    comando.Parameters.AddWithValue("@Criticidad", bitacoraAlta.Criticidad);
                    object id = comando.ExecuteScalar();
                    idBitacoraGenerado = int.Parse(id.ToString());
                    bitacoraAlta.IdBitacora = idBitacoraGenerado;

                }
            }
            return bitacoraAlta;
        }



        public List<Bitacora> ObtenerEventosPorConsulta(string usuarioFiltrar = "", string moduloFiltrar = "", string descripcionFiltrar = "", string criticidadFiltrar = "", DateTime? fechaInicioFiltrar = null, DateTime? fechaFinFiltrar = null)
        {
            List<Bitacora> listaBitacora = new List<Bitacora>();

            using (SqlConnection cone = GestorConexion.DevolverConexion())
            {
                cone.Open();

                List<string> condiciones = new List<string>();
                SqlCommand comando = new SqlCommand();
                comando.Connection = cone;

                string query = "SELECT ID_Bitacora, NombreUsuario, Fecha, Hora, Modulo, Descripcion, Criticidad FROM Bitacora WHERE 1=1";

                if (!string.IsNullOrEmpty(usuarioFiltrar))
                {
                    condiciones.Add("NombreUsuario = @Username");
                    comando.Parameters.AddWithValue("@Username", usuarioFiltrar);
                }
                if (!string.IsNullOrEmpty(moduloFiltrar))
                {
                    condiciones.Add("Modulo = @Modulo");
                    comando.Parameters.AddWithValue("@Modulo", moduloFiltrar);
                }
                if (!string.IsNullOrEmpty(descripcionFiltrar))
                {
                    condiciones.Add("Descripcion = @Descripcion");
                    comando.Parameters.AddWithValue("@Descripcion", descripcionFiltrar);
                }
                if (!string.IsNullOrEmpty(criticidadFiltrar))
                {
                    condiciones.Add("Criticidad = @Criticidad");
                    comando.Parameters.AddWithValue("@Criticidad", criticidadFiltrar);
                }
                if (fechaInicioFiltrar.HasValue)
                {
                    condiciones.Add("Fecha >= @FechaInicio");
                    comando.Parameters.AddWithValue("@FechaInicio", fechaInicioFiltrar.Value.Date);
                }
                if (fechaFinFiltrar.HasValue)
                {
                    condiciones.Add("Fecha <= @FechaFin");
                    comando.Parameters.AddWithValue("@FechaFin", fechaFinFiltrar.Value.Date);
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
                        listaBitacora.Add(bitacora);
                    }
                }
            }

            return listaBitacora;
        }

        public List<string> ObtenerListaDVH()
        {
            List<string> listaDVH = new List<string>();
            using (SqlConnection cone = GestorConexion.DevolverConexion())
            {
                cone.Open();
                string query = "SELECT * FROM Bitacora";
                using (SqlCommand comando = new SqlCommand(query, cone))
                {
                    using (SqlDataReader lector = comando.ExecuteReader())
                    {
                        while (lector.Read())
                        {
                            listaDVH.Add(lector["DVH"].ToString());
                        }
                    }
                }
            }
            return listaDVH;
        }

        public void ActualizarDVH(Bitacora bitacora, string dvh)
        {
            using (SqlConnection cone = GestorConexion.DevolverConexion())
            {
                cone.Open();
                using (SqlCommand comando = new SqlCommand("UPDATE Bitacora SET DVH = @DVH WHERE ID_Bitacora = @ID_Bitacora", cone))
                {
                    comando.Parameters.AddWithValue("@DVH", dvh);
                    comando.Parameters.AddWithValue("@ID_Bitacora", bitacora.IdBitacora);
                    comando.ExecuteNonQuery();
                }
            }
        }
        public string ObtenerDVH(Bitacora bitacora)
        {
            using (SqlConnection cone = GestorConexion.DevolverConexion())
            {
                cone.Open();
                string query = "SELECT DVH FROM Bitacora WHERE ID_Bitacora = @ID_Bitacora";
                using (SqlCommand comando = new SqlCommand(query, cone))
                {
                    comando.Parameters.AddWithValue("@ID_Bitacora", bitacora.IdBitacora);
                    return comando.ExecuteScalar()?.ToString();
                }
            }
        }
    }
}
