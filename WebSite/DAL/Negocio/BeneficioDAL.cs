using BE;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Negocio
{
    public class BeneficioDAL
    {
        #region Operaciones Beneficio

        public void Alta(Beneficio BeneficioAlta)
        {
            using (SqlConnection cone = GestorConexion.DevolverConexion())
            {
                cone.Open();


                string queryMaxId = "SELECT ISNULL(MAX(CodigoBeneficio), 0) + 1 FROM Beneficio";
                using (SqlCommand cmdMaxId = new SqlCommand(queryMaxId, cone))
                {
                    int nuevoId = Convert.ToInt32(cmdMaxId.ExecuteScalar());
                    BeneficioAlta.CodigoBeneficio = nuevoId;
                }


                string queryInsert = "INSERT INTO Beneficio (CodigoBeneficio, Nombre, PrecioEstrella, CantidadBeneficioReclamado, DescuentoAplicar) VALUES (@CodigoBeneficio, @Nombre, @PrecioEstrella, @CantidadBeneficioReclamado, @DescuentoAplicar)";

                using (SqlCommand comando = new SqlCommand(queryInsert, cone))
                {
                    comando.Parameters.AddWithValue("@CodigoBeneficio", BeneficioAlta.CodigoBeneficio);
                    comando.Parameters.AddWithValue("@Nombre", BeneficioAlta.Nombre);
                    comando.Parameters.AddWithValue("@PrecioEstrella", BeneficioAlta.PrecioEstrella);
                    comando.Parameters.AddWithValue("@CantidadBeneficioReclamado", BeneficioAlta.CantidadBeneficioReclamo);
                    comando.Parameters.AddWithValue("@DescuentoAplicar", BeneficioAlta.DescuentoAplicar);

                    comando.ExecuteNonQuery();
                }
            }
        }


        public bool Baja(int ID)
        {
            using (SqlConnection cone = GestorConexion.DevolverConexion())
            {
                cone.Open();

                string queryVerificacion = "SELECT COUNT(*) FROM Usuario_Beneficio WHERE CodigoBeneficio = @ID";
                using (SqlCommand cmdVerificacion = new SqlCommand(queryVerificacion, cone))
                {
                    cmdVerificacion.Parameters.AddWithValue("@ID", ID);
                    int cantidadRelacionada = (int)cmdVerificacion.ExecuteScalar();

                    if (cantidadRelacionada > 0)
                    {

                        return false;
                    }
                }


                string queryEliminar = "DELETE FROM Beneficio WHERE CodigoBeneficio = @ID";
                using (SqlCommand cmdEliminar = new SqlCommand(queryEliminar, cone))
                {
                    cmdEliminar.Parameters.AddWithValue("@ID", ID);
                    cmdEliminar.ExecuteNonQuery();
                }

                return true;
            }
        }


        public void Modificacion(Beneficio BeneficioModificado)
        {
            using (SqlConnection cone = GestorConexion.DevolverConexion())
            {
                cone.Open();
                string query = "UPDATE Beneficio SET Nombre = @Nombre, PrecioEstrella = @PrecioEstrella, CantidadBeneficioReclamado = @CantidadBeneficioReclamado, DescuentoAplicar = @DescuentoAplicar WHERE CodigoBeneficio = @CodigoBeneficio";
                using (SqlCommand comando = new SqlCommand(query, cone))
                {
                    comando.Parameters.AddWithValue("@CodigoBeneficio", BeneficioModificado.CodigoBeneficio);
                    comando.Parameters.AddWithValue("@Nombre", BeneficioModificado.Nombre);
                    comando.Parameters.AddWithValue("@PrecioEstrella", BeneficioModificado.PrecioEstrella);
                    comando.Parameters.AddWithValue("@CantidadBeneficioReclamado", BeneficioModificado.CantidadBeneficioReclamo);
                    comando.Parameters.AddWithValue("@DescuentoAplicar", BeneficioModificado.DescuentoAplicar);
                    comando.ExecuteNonQuery();
                }
            }
        }

        public void AgregarBeneficioACliente(string DNICliente, int CodigoBeneficio)
        {
            using (SqlConnection cone = GestorConexion.DevolverConexion())
            {
                cone.Open();
                string query = "INSERT INTO Usuario_Beneficio (DNI, CodigoBeneficio) VALUES (@DNICliente, @CodigoBeneficio)";
                using (SqlCommand comando = new SqlCommand(query, cone))
                {
                    comando.Parameters.AddWithValue("@DNICliente", DNICliente);
                    comando.Parameters.AddWithValue("@CodigoBeneficio", CodigoBeneficio);
                    comando.ExecuteNonQuery();
                }
            }
        }

        public void EliminarBeneficioDeCliente(string DNICliente, int CodigoBeneficio)
        {
            using (SqlConnection cone = GestorConexion.DevolverConexion())
            {
                cone.Open();
                string query = "DELETE FROM Usuario_Beneficio WHERE DNI = @DNICliente AND CodigoBeneficio = @CodigoBeneficio";
                using (SqlCommand comando = new SqlCommand(query, cone))
                {
                    comando.Parameters.AddWithValue("@DNICliente", DNICliente);
                    comando.Parameters.AddWithValue("@CodigoBeneficio", CodigoBeneficio);
                    comando.ExecuteNonQuery();
                }
            }
        }

        public void ReducirSaldoEstrellas(string DNICliente, int cantidadEstrellas)
        {
            using (SqlConnection cone = GestorConexion.DevolverConexion())
            {
                cone.Open();
                string query = "UPDATE Cliente SET EstrellasCliente = EstrellasCliente - @CantidadEstrellas WHERE DNI = @DNICliente";
                using (SqlCommand comando = new SqlCommand(query, cone))
                {
                    comando.Parameters.AddWithValue("@CantidadEstrellas", cantidadEstrellas);
                    comando.Parameters.AddWithValue("@DNICliente", DNICliente);
                    comando.ExecuteNonQuery();
                }
            }
        }

        public void AplicarBeneficio(string IDBoleto, float DescuentoAplicar, string nombreBeneficio)
        {
            using (SqlConnection cone = GestorConexion.DevolverConexion())
            {
                cone.Open();
                string query = "UPDATE Boleto SET Precio = Precio * (1 - @PorcentajeDescuento), BeneficioAplicado = @BeneficioAplicado WHERE ID = @ID;";
                using (SqlCommand comando = new SqlCommand(query, cone))
                {
                    comando.Parameters.AddWithValue("@PorcentajeDescuento", DescuentoAplicar);
                    comando.Parameters.AddWithValue("@ID", IDBoleto);
                    comando.Parameters.AddWithValue("@BeneficioAplicado", nombreBeneficio);
                    comando.ExecuteNonQuery();
                }
            }

        }

        public bool ExisteNombreBeneficioAlta(string nombreBeneficio)
        {
            using (SqlConnection cone = GestorConexion.DevolverConexion())
            {
                cone.Open();
                string query = "SELECT COUNT(*) FROM Beneficio WHERE Nombre = @Nombre";
                using (SqlCommand comando = new SqlCommand(query, cone))
                {
                    comando.Parameters.AddWithValue("@Nombre", nombreBeneficio);
                    int cantidad = (int)comando.ExecuteScalar();
                    return cantidad > 0;
                }
            }
        }

        public bool ExisteNombreBeneficioModificar(string nombreBeneficio, int idActual)
        {
            using (SqlConnection cone = GestorConexion.DevolverConexion())
            {
                cone.Open();
                string query = "SELECT COUNT(*) FROM Beneficio WHERE Nombre = @Nombre AND CodigoBeneficio <> @ID";

                using (SqlCommand comando = new SqlCommand(query, cone))
                {
                    comando.Parameters.AddWithValue("@Nombre", nombreBeneficio);
                    comando.Parameters.AddWithValue("@ID", idActual);
                    int cantidad = (int)comando.ExecuteScalar();
                    return cantidad > 0;
                }
            }
        }


        #endregion

        #region Busquedas Beneficio
        public Beneficio ObtenerBeneficioPorCodigo(int CodigoBeneficio)
        {
            using (SqlConnection cone = GestorConexion.DevolverConexion())
            {
                cone.Open();
                string query = "SELECT * FROM Beneficio WHERE CodigoBeneficio = @CodigoBeneficio";
                using (SqlCommand comando = new SqlCommand(query, cone))
                {
                    comando.Parameters.AddWithValue("@CodigoBeneficio", CodigoBeneficio);
                    using (SqlDataReader reader = comando.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new Beneficio(int.Parse(reader["CodigoBeneficio"].ToString()), reader["Nombre"].ToString(), int.Parse(reader["PrecioEstrella"].ToString()), int.Parse(reader["CantidadBeneficioReclamado"].ToString()), float.Parse(reader["DescuentoAplicar"].ToString()));
                        }
                        else
                        {
                            return null;
                        }
                    }
                }
            }
        }

        public List<Beneficio> ObtenerTodosLosBeneficios()
        {
            List<Beneficio> beneficios = new List<Beneficio>();
            using (SqlConnection cone = GestorConexion.DevolverConexion())
            {
                cone.Open();
                string query = "SELECT * FROM Beneficio";
                using (SqlCommand comando = new SqlCommand(query, cone))
                {
                    using (SqlDataReader reader = comando.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            beneficios.Add(new Beneficio(int.Parse(reader["CodigoBeneficio"].ToString()), reader["Nombre"].ToString(), int.Parse(reader["PrecioEstrella"].ToString()), int.Parse(reader["CantidadBeneficioReclamado"].ToString()), float.Parse(reader["DescuentoAplicar"].ToString())));
                        }
                    }
                }
            }
            return beneficios;
        }

        public List<Beneficio> ObtenerBeneficiosPorCliente(string DNI)
        {
            List<Beneficio> beneficios = new List<Beneficio>();
            using (SqlConnection cone = GestorConexion.DevolverConexion())
            {
                cone.Open();
                string query = "SELECT b.* FROM Beneficio b INNER JOIN Usuario_Beneficio cb ON b.CodigoBeneficio = cb.CodigoBeneficio WHERE cb.DNI = @DNI";
                using (SqlCommand comando = new SqlCommand(query, cone))
                {
                    comando.Parameters.AddWithValue("@DNI", DNI);
                    using (SqlDataReader reader = comando.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            beneficios.Add(new Beneficio(int.Parse(reader["CodigoBeneficio"].ToString()), reader["Nombre"].ToString(), int.Parse(reader["PrecioEstrella"].ToString()), int.Parse(reader["CantidadBeneficioReclamado"].ToString()), float.Parse(reader["DescuentoAplicar"].ToString())));
                        }
                    }
                }
            }
            return beneficios;
        }

        public List<Beneficio> ObtenerBeneficiosPorCantidadDeReclamados(int cantidadReclamados)
        {
            List<Beneficio> beneficios = new List<Beneficio>();
            using (SqlConnection cone = GestorConexion.DevolverConexion())
            {
                cone.Open();
                string query = "SELECT * FROM Beneficio WHERE CantidadBeneficioReclamado >= @CantidadReclamados";
                using (SqlCommand comando = new SqlCommand(query, cone))
                {
                    comando.Parameters.AddWithValue("@CantidadReclamados", cantidadReclamados);
                    using (SqlDataReader reader = comando.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            beneficios.Add(new Beneficio(int.Parse(reader["CodigoBeneficio"].ToString()), reader["Nombre"].ToString(), int.Parse(reader["PrecioEstrella"].ToString()), int.Parse(reader["CantidadBeneficioReclamado"].ToString()), float.Parse(reader["DescuentoAplicar"].ToString())));
                        }
                    }
                }
            }
            return beneficios;
        }

        #endregion
    }
}
