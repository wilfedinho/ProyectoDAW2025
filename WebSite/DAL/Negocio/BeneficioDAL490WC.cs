using BE;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Negocio
{
    public class BeneficioDAL490WC
    {
        #region Operaciones Beneficio

        public void Alta490WC(Beneficio490WC BeneficioAlta490WC)
        {
            using (SqlConnection cone490WC = GestorConexion490WC.DevolverConexion())
            {
                cone490WC.Open();


                string queryMaxId = "SELECT ISNULL(MAX(CodigoBeneficio), 0) + 1 FROM Beneficio";
                using (SqlCommand cmdMaxId = new SqlCommand(queryMaxId, cone490WC))
                {
                    int nuevoId = Convert.ToInt32(cmdMaxId.ExecuteScalar());
                    BeneficioAlta490WC.CodigoBeneficio490WC = nuevoId;
                }


                string queryInsert = "INSERT INTO Beneficio (CodigoBeneficio, Nombre, PrecioEstrella, CantidadBeneficioReclamado, DescuentoAplicar) VALUES (@CodigoBeneficio, @Nombre, @PrecioEstrella, @CantidadBeneficioReclamado, @DescuentoAplicar)";

                using (SqlCommand comando490WC = new SqlCommand(queryInsert, cone490WC))
                {
                    comando490WC.Parameters.AddWithValue("@CodigoBeneficio", BeneficioAlta490WC.CodigoBeneficio490WC);
                    comando490WC.Parameters.AddWithValue("@Nombre", BeneficioAlta490WC.Nombre490WC);
                    comando490WC.Parameters.AddWithValue("@PrecioEstrella", BeneficioAlta490WC.PrecioEstrella490WC);
                    comando490WC.Parameters.AddWithValue("@CantidadBeneficioReclamado", BeneficioAlta490WC.CantidadBeneficioReclamo490WC);
                    comando490WC.Parameters.AddWithValue("@DescuentoAplicar", BeneficioAlta490WC.DescuentoAplicar490WC);

                    comando490WC.ExecuteNonQuery();
                }
            }
        }


        public bool Baja490WC(int ID490WC)
        {
            using (SqlConnection cone490WC = GestorConexion490WC.DevolverConexion())
            {
                cone490WC.Open();

                string queryVerificacion490WC = "SELECT COUNT(*) FROM Usuario_Beneficio WHERE CodigoBeneficio = @ID";
                using (SqlCommand cmdVerificacion490WC = new SqlCommand(queryVerificacion490WC, cone490WC))
                {
                    cmdVerificacion490WC.Parameters.AddWithValue("@ID", ID490WC);
                    int cantidadRelacionada = (int)cmdVerificacion490WC.ExecuteScalar();

                    if (cantidadRelacionada > 0)
                    {

                        return false;
                    }
                }


                string queryEliminar490WC = "DELETE FROM Beneficio WHERE CodigoBeneficio = @ID";
                using (SqlCommand cmdEliminar490WC = new SqlCommand(queryEliminar490WC, cone490WC))
                {
                    cmdEliminar490WC.Parameters.AddWithValue("@ID", ID490WC);
                    cmdEliminar490WC.ExecuteNonQuery();
                }

                return true;
            }
        }


        public void Modificacion490WC(Beneficio490WC BeneficioModificado490WC)
        {
            using (SqlConnection cone490WC = GestorConexion490WC.DevolverConexion())
            {
                cone490WC.Open();
                string query490WC = "UPDATE Beneficio SET Nombre = @Nombre, PrecioEstrella = @PrecioEstrella, CantidadBeneficioReclamado = @CantidadBeneficioReclamado, DescuentoAplicar = @DescuentoAplicar WHERE CodigoBeneficio = @CodigoBeneficio";
                using (SqlCommand comando490WC = new SqlCommand(query490WC, cone490WC))
                {
                    comando490WC.Parameters.AddWithValue("@CodigoBeneficio", BeneficioModificado490WC.CodigoBeneficio490WC);
                    comando490WC.Parameters.AddWithValue("@Nombre", BeneficioModificado490WC.Nombre490WC);
                    comando490WC.Parameters.AddWithValue("@PrecioEstrella", BeneficioModificado490WC.PrecioEstrella490WC);
                    comando490WC.Parameters.AddWithValue("@CantidadBeneficioReclamado", BeneficioModificado490WC.CantidadBeneficioReclamo490WC);
                    comando490WC.Parameters.AddWithValue("@DescuentoAplicar", BeneficioModificado490WC.DescuentoAplicar490WC);
                    comando490WC.ExecuteNonQuery();
                }
            }
        }

        public void AgregarBeneficioACliente490WC(string DNICliente490WC, int CodigoBeneficio490WC)
        {
            using (SqlConnection cone490WC = GestorConexion490WC.DevolverConexion())
            {
                cone490WC.Open();
                string query490WC = "INSERT INTO Usuario_Beneficio (DNI, CodigoBeneficio) VALUES (@DNICliente, @CodigoBeneficio)";
                using (SqlCommand comando490WC = new SqlCommand(query490WC, cone490WC))
                {
                    comando490WC.Parameters.AddWithValue("@DNICliente", DNICliente490WC);
                    comando490WC.Parameters.AddWithValue("@CodigoBeneficio", CodigoBeneficio490WC);
                    comando490WC.ExecuteNonQuery();
                }
            }
        }

        public void EliminarBeneficioDeCliente490WC(string DNICliente490WC, int CodigoBeneficio490WC)
        {
            using (SqlConnection cone490WC = GestorConexion490WC.DevolverConexion())
            {
                cone490WC.Open();
                string query490WC = "DELETE FROM Usuario_Beneficio WHERE DNI = @DNICliente AND CodigoBeneficio = @CodigoBeneficio";
                using (SqlCommand comando490WC = new SqlCommand(query490WC, cone490WC))
                {
                    comando490WC.Parameters.AddWithValue("@DNICliente", DNICliente490WC);
                    comando490WC.Parameters.AddWithValue("@CodigoBeneficio", CodigoBeneficio490WC);
                    comando490WC.ExecuteNonQuery();
                }
            }
        }

        public void ReducirSaldoEstrellas490WC(string DNICliente490WC, int cantidadEstrellas490WC)
        {
            using (SqlConnection cone490WC = GestorConexion490WC.DevolverConexion())
            {
                cone490WC.Open();
                string query490WC = "UPDATE Cliente SET EstrellasCliente = EstrellasCliente - @CantidadEstrellas WHERE DNI = @DNICliente";
                using (SqlCommand comando490WC = new SqlCommand(query490WC, cone490WC))
                {
                    comando490WC.Parameters.AddWithValue("@CantidadEstrellas", cantidadEstrellas490WC);
                    comando490WC.Parameters.AddWithValue("@DNICliente", DNICliente490WC);
                    comando490WC.ExecuteNonQuery();
                }
            }
        }

        public void AplicarBeneficio490WC(string IDBoleto490WC, float DescuentoAplicar490WC, string nombreBeneficio490WC)
        {
            using (SqlConnection cone490WC = GestorConexion490WC.DevolverConexion())
            {
                cone490WC.Open();
                string query490WC = "UPDATE Boleto SET Precio = Precio * (1 - @PorcentajeDescuento), BeneficioAplicado = @BeneficioAplicado WHERE ID = @ID;";
                using (SqlCommand comando490WC = new SqlCommand(query490WC, cone490WC))
                {
                    comando490WC.Parameters.AddWithValue("@PorcentajeDescuento", DescuentoAplicar490WC);
                    comando490WC.Parameters.AddWithValue("@ID", IDBoleto490WC);
                    comando490WC.Parameters.AddWithValue("@BeneficioAplicado", nombreBeneficio490WC);
                    comando490WC.ExecuteNonQuery();
                }
            }

        }

        public bool ExisteNombreBeneficioAlta490WC(string nombreBeneficio490WC)
        {
            using (SqlConnection cone490WC = GestorConexion490WC.DevolverConexion())
            {
                cone490WC.Open();
                string query490WC = "SELECT COUNT(*) FROM Beneficio WHERE Nombre = @Nombre";
                using (SqlCommand comando490WC = new SqlCommand(query490WC, cone490WC))
                {
                    comando490WC.Parameters.AddWithValue("@Nombre", nombreBeneficio490WC);
                    int cantidad = (int)comando490WC.ExecuteScalar();
                    return cantidad > 0;
                }
            }
        }

        public bool ExisteNombreBeneficioModificar490WC(string nombreBeneficio490WC, int idActual490WC)
        {
            using (SqlConnection cone490WC = GestorConexion490WC.DevolverConexion())
            {
                cone490WC.Open();
                string query490WC = "SELECT COUNT(*) FROM Beneficio WHERE Nombre = @Nombre AND CodigoBeneficio <> @ID";

                using (SqlCommand comando490WC = new SqlCommand(query490WC, cone490WC))
                {
                    comando490WC.Parameters.AddWithValue("@Nombre", nombreBeneficio490WC);
                    comando490WC.Parameters.AddWithValue("@ID", idActual490WC);
                    int cantidad = (int)comando490WC.ExecuteScalar();
                    return cantidad > 0;
                }
            }
        }


        #endregion

        #region Busquedas Beneficio
        public Beneficio490WC ObtenerBeneficioPorCodigo490WC(int CodigoBeneficio490WC)
        {
            using (SqlConnection cone490WC = GestorConexion490WC.DevolverConexion())
            {
                cone490WC.Open();
                string query490WC = "SELECT * FROM Beneficio WHERE CodigoBeneficio = @CodigoBeneficio";
                using (SqlCommand comando490WC = new SqlCommand(query490WC, cone490WC))
                {
                    comando490WC.Parameters.AddWithValue("@CodigoBeneficio", CodigoBeneficio490WC);
                    using (SqlDataReader reader = comando490WC.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new Beneficio490WC(int.Parse(reader["CodigoBeneficio"].ToString()), reader["Nombre"].ToString(), int.Parse(reader["PrecioEstrella"].ToString()), int.Parse(reader["CantidadBeneficioReclamado"].ToString()), float.Parse(reader["DescuentoAplicar"].ToString()));
                        }
                        else
                        {
                            return null;
                        }
                    }
                }
            }
        }

        public List<Beneficio490WC> ObtenerTodosLosBeneficios490WC()
        {
            List<Beneficio490WC> beneficios = new List<Beneficio490WC>();
            using (SqlConnection cone490WC = GestorConexion490WC.DevolverConexion())
            {
                cone490WC.Open();
                string query490WC = "SELECT * FROM Beneficio";
                using (SqlCommand comando490WC = new SqlCommand(query490WC, cone490WC))
                {
                    using (SqlDataReader reader = comando490WC.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            beneficios.Add(new Beneficio490WC(int.Parse(reader["CodigoBeneficio"].ToString()), reader["Nombre"].ToString(), int.Parse(reader["PrecioEstrella"].ToString()), int.Parse(reader["CantidadBeneficioReclamado"].ToString()), float.Parse(reader["DescuentoAplicar"].ToString())));
                        }
                    }
                }
            }
            return beneficios;
        }

        public List<Beneficio490WC> ObtenerBeneficiosPorCliente490WC(string DNI490WC)
        {
            List<Beneficio490WC> beneficios = new List<Beneficio490WC>();
            using (SqlConnection cone490WC = GestorConexion490WC.DevolverConexion())
            {
                cone490WC.Open();
                string query490WC = "SELECT b.* FROM Beneficio b INNER JOIN Usuario_Beneficio cb ON b.CodigoBeneficio = cb.CodigoBeneficio WHERE cb.DNI = @DNI";
                using (SqlCommand comando490WC = new SqlCommand(query490WC, cone490WC))
                {
                    comando490WC.Parameters.AddWithValue("@DNI", DNI490WC);
                    using (SqlDataReader reader = comando490WC.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            beneficios.Add(new Beneficio490WC(int.Parse(reader["CodigoBeneficio"].ToString()), reader["Nombre"].ToString(), int.Parse(reader["PrecioEstrella"].ToString()), int.Parse(reader["CantidadBeneficioReclamado"].ToString()), float.Parse(reader["DescuentoAplicar"].ToString())));
                        }
                    }
                }
            }
            return beneficios;
        }

        public List<Beneficio490WC> ObtenerBeneficiosPorCantidadDeReclamados490WC(int cantidadReclamados)
        {
            List<Beneficio490WC> beneficios = new List<Beneficio490WC>();
            using (SqlConnection cone490WC = GestorConexion490WC.DevolverConexion())
            {
                cone490WC.Open();
                string query490WC = "SELECT * FROM Beneficio WHERE CantidadBeneficioReclamado >= @CantidadReclamados";
                using (SqlCommand comando490WC = new SqlCommand(query490WC, cone490WC))
                {
                    comando490WC.Parameters.AddWithValue("@CantidadReclamados", cantidadReclamados);
                    using (SqlDataReader reader = comando490WC.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            beneficios.Add(new Beneficio490WC(int.Parse(reader["CodigoBeneficio"].ToString()), reader["Nombre"].ToString(), int.Parse(reader["PrecioEstrella"].ToString()), int.Parse(reader["CantidadBeneficioReclamado"].ToString()), float.Parse(reader["DescuentoAplicar"].ToString())));
                        }
                    }
                }
            }
            return beneficios;
        }

        #endregion
    }
}
