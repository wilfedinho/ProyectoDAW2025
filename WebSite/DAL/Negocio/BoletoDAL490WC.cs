using BE;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Negocio
{
    public class BoletoDAL490WC
    {
        #region Operaciones Boleto



        public void Alta490WC(Boleto490WC BoletoAgregar490WC)
        {
            using (SqlConnection cone490WC = GestorConexion490WC.DevolverConexion())
            {
                cone490WC.Open();


                string queryMaxId = "SELECT ISNULL(MAX(CAST(ID490WC AS INT)), 0) + 1 FROM Boleto";

                int nuevoId;
                using (SqlCommand cmdId = new SqlCommand(queryMaxId, cone490WC))
                {
                    nuevoId = Convert.ToInt32(cmdId.ExecuteScalar());
                }


                BoletoAgregar490WC.IDBoleto490WC = nuevoId.ToString();

                string query490WC = "";

                if (BoletoAgregar490WC is BoletoIDA490WC boletoIDA490WC)
                {
                    query490WC = @"INSERT INTO Boleto (ID, Origen, Destino, FechaPartidaIDA, FechaLlegadaIDA, IsVendido, PesoEquipajePermitido, ClaseBoleto, Precio, Titular, NumeroAsiento) VALUES (@ID490WC, @Origen490WC, @Destino490WC, @FechaPartidaIDA490WC, @FechaLlegadaIDA490WC, @IsVendido490WC, @PesoEquipajePermitido490WC, @ClaseBoleto490WC, @Precio490WC, @Titular490WC, @NumeroAsiento490WC)";

                    using (SqlCommand comando490WC = new SqlCommand(query490WC, cone490WC))
                    {
                        comando490WC.Parameters.AddWithValue("@ID490WC", boletoIDA490WC.IDBoleto490WC);
                        comando490WC.Parameters.AddWithValue("@Origen490WC", boletoIDA490WC.Origen490WC);
                        comando490WC.Parameters.AddWithValue("@Destino490WC", boletoIDA490WC.Destino490WC);
                        comando490WC.Parameters.AddWithValue("@FechaPartidaIDA490WC", boletoIDA490WC.FechaPartida490WC);
                        comando490WC.Parameters.AddWithValue("@FechaLlegadaIDA490WC", boletoIDA490WC.FechaLlegada490WC);
                        comando490WC.Parameters.AddWithValue("@IsVendido490WC", boletoIDA490WC.IsVendido490WC);
                        comando490WC.Parameters.AddWithValue("@PesoEquipajePermitido490WC", boletoIDA490WC.EquipajePermitido490WC);
                        comando490WC.Parameters.AddWithValue("@ClaseBoleto490WC", boletoIDA490WC.ClaseBoleto490WC);
                        comando490WC.Parameters.AddWithValue("@Precio490WC", boletoIDA490WC.Precio490WC);
                        comando490WC.Parameters.AddWithValue("@Titular490WC", boletoIDA490WC.Titular490WC.DNI);
                        comando490WC.Parameters.AddWithValue("@NumeroAsiento490WC", boletoIDA490WC.NumeroAsiento490WC);

                        comando490WC.ExecuteNonQuery();
                    }
                }
                else if (BoletoAgregar490WC is BoletoIDAVUELTA490WC boletoIDAVUELTA490WC)
                {
                    query490WC = @"INSERT INTO Boleto (ID, Origen, Destino, FechaPartidaIDA, FechaLlegadaIDA, FechaPartidaVUELTA, FechaLlegadaVUELTA, IsVendido, PesoEquipajePermitido, ClaseBoleto, Precio, Titular, NumeroAsiento) VALUES (@ID490WC, @Origen490WC, @Destino490WC, @FechaPartidaIDA490WC, @FechaLlegadaIDA490WC, @FechaPartidaVUELTA490WC, @FechaLlegadaVUELTA490WC, @IsVendido490WC, @PesoEquipajePermitido490WC, @ClaseBoleto490WC, @Precio490WC, @Titular490WC, @NumeroAsiento490WC)";

                    using (SqlCommand comando490WC = new SqlCommand(query490WC, cone490WC))
                    {
                        comando490WC.Parameters.AddWithValue("@ID490WC", boletoIDAVUELTA490WC.IDBoleto490WC);
                        comando490WC.Parameters.AddWithValue("@Origen490WC", boletoIDAVUELTA490WC.Origen490WC);
                        comando490WC.Parameters.AddWithValue("@Destino490WC", boletoIDAVUELTA490WC.Destino490WC);
                        comando490WC.Parameters.AddWithValue("@FechaPartidaIDA490WC", boletoIDAVUELTA490WC.FechaPartida490WC);
                        comando490WC.Parameters.AddWithValue("@FechaLlegadaIDA490WC", boletoIDAVUELTA490WC.FechaLlegada490WC);
                        comando490WC.Parameters.AddWithValue("@FechaPartidaVUELTA490WC", boletoIDAVUELTA490WC.FechaPartidaVUELTA490WC);
                        comando490WC.Parameters.AddWithValue("@FechaLlegadaVUELTA490WC", boletoIDAVUELTA490WC.FechaLlegadaVUELTA490WC);
                        comando490WC.Parameters.AddWithValue("@IsVendido490WC", boletoIDAVUELTA490WC.IsVendido490WC);
                        comando490WC.Parameters.AddWithValue("@PesoEquipajePermitido490WC", boletoIDAVUELTA490WC.EquipajePermitido490WC);
                        comando490WC.Parameters.AddWithValue("@ClaseBoleto490WC", boletoIDAVUELTA490WC.ClaseBoleto490WC);
                        comando490WC.Parameters.AddWithValue("@Precio490WC", boletoIDAVUELTA490WC.Precio490WC);
                        comando490WC.Parameters.AddWithValue("@Titular490WC", boletoIDAVUELTA490WC.Titular490WC.DNI);
                        comando490WC.Parameters.AddWithValue("@NumeroAsiento490WC", boletoIDAVUELTA490WC.NumeroAsiento490WC);

                        comando490WC.ExecuteNonQuery();
                    }
                }
            }
        }


        public void Baja490WC(string IDBoleto490WC)
        {
            using (SqlConnection cone490WC = GestorConexion490WC.DevolverConexion())
            {
                cone490WC.Open();
                string query490WC = "DELETE FROM Boleto WHERE ID = @IDBoleto490WC";
                using (SqlCommand comando490WC = new SqlCommand(query490WC, cone490WC))
                {
                    comando490WC.Parameters.AddWithValue("@IDBoleto490WC", IDBoleto490WC);
                    comando490WC.ExecuteNonQuery();
                }
            }
        }

        public void Modificar490WC(Boleto490WC BoletoModificado490WC)
        {
            using (SqlConnection cone490WC = GestorConexion490WC.DevolverConexion())
            {
                cone490WC.Open();
                string query490WC = "";
                if (BoletoModificado490WC is BoletoIDA490WC boletoIDA490WC)
                {
                    query490WC = "UPDATE Boleto SET Origen = @Origen490WC, Destino = @Destino490WC, FechaPartidaIDA = @FechaPartidaIDA490WC, FechaLlegadaIDA = @FechaLlegadaIDA490WC, IsVendido = @IsVendido490WC, PesoEquipajePermitido = @PesoEquipajePermitido490WC, ClaseBoleto = @ClaseBoleto490WC, Precio = @Precio490WC, Titular = @Titular490WC, NumeroAsiento = @NumeroAsiento490WC WHERE ID = @ID490WC";
                    using (SqlCommand comando490WC = new SqlCommand(query490WC, cone490WC))
                    {
                        comando490WC.Parameters.AddWithValue("@ID490WC", boletoIDA490WC.IDBoleto490WC);
                        comando490WC.Parameters.AddWithValue("@Origen490WC", boletoIDA490WC.Origen490WC);
                        comando490WC.Parameters.AddWithValue("@Destino490WC", boletoIDA490WC.Destino490WC);
                        comando490WC.Parameters.AddWithValue("@FechaPartidaIDA490WC", boletoIDA490WC.FechaPartida490WC);
                        comando490WC.Parameters.AddWithValue("@FechaLlegadaIDA490WC", boletoIDA490WC.FechaLlegada490WC);
                        comando490WC.Parameters.AddWithValue("@IsVendido490WC", boletoIDA490WC.IsVendido490WC);
                        comando490WC.Parameters.AddWithValue("@PesoEquipajePermitido490WC", boletoIDA490WC.EquipajePermitido490WC);
                        comando490WC.Parameters.AddWithValue("@ClaseBoleto490WC", boletoIDA490WC.ClaseBoleto490WC);
                        comando490WC.Parameters.AddWithValue("@Precio490WC", boletoIDA490WC.Precio490WC);
                        comando490WC.Parameters.AddWithValue("@Titular490WC", boletoIDA490WC.Titular490WC.DNI);
                        comando490WC.Parameters.AddWithValue("@NumeroAsiento490WC", boletoIDA490WC.NumeroAsiento490WC);

                        comando490WC.ExecuteNonQuery();
                    }
                }

                if (BoletoModificado490WC is BoletoIDAVUELTA490WC boletoIDAVUELTA490WC)
                {
                    query490WC = "UPDATE Boleto SET Origen = @Origen490WC, Destino = @Destino490WC, FechaPartidaIDA = @FechaPartidaIDA490WC, FechaLlegadaIDA = @FechaLlegadaIDA490WC, FechaPartidaVUELTA = @FechaPartidaVUELTA490WC, FechaLlegadaVUELTA = @FechaLlegadaVUELTA490WC, IsVendido = @IsVendido490WC, PesoEquipajePermitido = @PesoEquipajePermitido490WC, ClaseBoleto = @ClaseBoleto490WC, Precio = @Precio490WC, Titular = @Titular490WC, NumeroAsiento = @NumeroAsiento490WC WHERE ID = @ID490WC";
                    using (SqlCommand comando490WC = new SqlCommand(query490WC, cone490WC))
                    {
                        comando490WC.Parameters.AddWithValue("@ID490WC", boletoIDAVUELTA490WC.IDBoleto490WC);
                        comando490WC.Parameters.AddWithValue("@Origen490WC", boletoIDAVUELTA490WC.Origen490WC);
                        comando490WC.Parameters.AddWithValue("@Destino490WC", boletoIDAVUELTA490WC.Destino490WC);
                        comando490WC.Parameters.AddWithValue("@FechaPartidaIDA490WC", boletoIDAVUELTA490WC.FechaPartida490WC);
                        comando490WC.Parameters.AddWithValue("@FechaLlegadaIDA490WC", boletoIDAVUELTA490WC.FechaLlegada490WC);
                        comando490WC.Parameters.AddWithValue("@FechaPartidaVUELTA490WC", boletoIDAVUELTA490WC.FechaPartidaVUELTA490WC);
                        comando490WC.Parameters.AddWithValue("@FechaLlegadaVUELTA490WC", boletoIDAVUELTA490WC.FechaLlegadaVUELTA490WC);
                        comando490WC.Parameters.AddWithValue("@IsVendido490WC", boletoIDAVUELTA490WC.IsVendido490WC);
                        comando490WC.Parameters.AddWithValue("@PesoEquipajePermitido490WC", boletoIDAVUELTA490WC.EquipajePermitido490WC);
                        comando490WC.Parameters.AddWithValue("@ClaseBoleto490WC", boletoIDAVUELTA490WC.ClaseBoleto490WC);
                        comando490WC.Parameters.AddWithValue("@Precio490WC", boletoIDAVUELTA490WC.Precio490WC);
                        comando490WC.Parameters.AddWithValue("@Titular490WC", boletoIDAVUELTA490WC.Titular490WC.DNI);
                        comando490WC.Parameters.AddWithValue("@NumeroAsiento490WC", boletoIDAVUELTA490WC.NumeroAsiento490WC);

                        comando490WC.ExecuteNonQuery();
                    }
                }
            }
        }
        public bool ExisteBoletoAsignar490WC(int idBoleto)
        {
            using (SqlConnection cone490WC = GestorConexion490WC.DevolverConexion())
            {
                cone490WC.Open();
                string query = "SELECT CASE WHEN EXISTS (SELECT 1 FROM Boleto WHERE ID = @ID490WC AND FechaBoletoGenerado IS NOT NULL AND (Titular = @ID490WC OR Titular = 'Sistema')) THEN 1 ELSE 0 END";

                using (SqlCommand comando = new SqlCommand(query, cone490WC))
                {
                    comando.Parameters.AddWithValue("@ID490WC", idBoleto);
                    int resultado = (int)comando.ExecuteScalar();
                    return resultado == 1;
                }
            }
        }

        public void AsignarBoletoCliente490WC(Boleto490WC boletoAsignar490WC, Usuario clienteAsignar490WC)
        {
            using (SqlConnection cone490WC = GestorConexion490WC.DevolverConexion())
            {
                cone490WC.Open();
                string query490WC = "UPDATE Boleto SET Titular = @Titular490WC, FechaBoletoGenerado = @FechaBoletoGenerado490WC WHERE ID = @ID490WC AND FechaBoletoGenerado IS  NULL AND (Titular = @ID490WC OR Titular = 'Sistema' OR Titular = @Titular490WC)";

                using (SqlCommand comando490WC = new SqlCommand(query490WC, cone490WC))
                {
                    comando490WC.Parameters.AddWithValue("@ID490WC", boletoAsignar490WC.IDBoleto490WC);
                    comando490WC.Parameters.AddWithValue("@Titular490WC", clienteAsignar490WC.DNI);
                    comando490WC.Parameters.AddWithValue("@FechaBoletoGenerado490WC", DateTime.Now);

                    comando490WC.ExecuteNonQuery();
                }
            }
        }

        public void AsignarBoletoClienteRegistrar490WC(Boleto490WC boletoAsignar490WC, Usuario clienteAsignar490WC)
        {
            using (SqlConnection cone490WC = GestorConexion490WC.DevolverConexion())
            {
                cone490WC.Open();
                string query490WC = "UPDATE Boleto SET Titular = @Titular490WC, FechaBoletoGenerado = @FechaBoletoGenerado490WC WHERE ID4 = @ID490WC AND FechaBoletoGenerado IS NOT NULL AND (Titular = @ID490WC OR Titular = 'Sistema' OR Titular = @Titular490WC)";

                using (SqlCommand comando490WC = new SqlCommand(query490WC, cone490WC))
                {
                    comando490WC.Parameters.AddWithValue("@ID490WC", boletoAsignar490WC.IDBoleto490WC);
                    comando490WC.Parameters.AddWithValue("@Titular490WC", clienteAsignar490WC.DNI);
                    comando490WC.Parameters.AddWithValue("@FechaBoletoGenerado490WC", DateTime.Now);

                    comando490WC.ExecuteNonQuery();
                }
            }
        }

        public void GenerarBoletoCompra490WC(Boleto490WC boletoGenerar490WC)
        {
            using (SqlConnection cone490WC = GestorConexion490WC.DevolverConexion())
            {
                cone490WC.Open();
                string query490WC = "UPDATE Boleto SET Titular = @Titular490WC, FechaBoletoGenerado = @FechaBoletoGenerado490WC WHERE ID = @ID490WC";
                using (SqlCommand comando490WC = new SqlCommand(query490WC, cone490WC))
                {
                    comando490WC.Parameters.AddWithValue("@ID490WC", boletoGenerar490WC.IDBoleto490WC);
                    comando490WC.Parameters.AddWithValue("@Titular490WC", boletoGenerar490WC.IDBoleto490WC);
                    comando490WC.Parameters.AddWithValue("@FechaBoletoGenerado490WC", DateTime.Now);

                    comando490WC.ExecuteNonQuery();
                }
            }
        }

        public void LiberarBoletosVencidos490WC()
        {
            using (SqlConnection cone490WC = GestorConexion490WC.DevolverConexion())
            {
                cone490WC.Open();
                string query490WC = "UPDATE Boleto SET Titular = 'Sistema', FechaBoletoGenerado = NULL, BeneficioAplicado = NULL WHERE IsVendido = 0 AND FechaBoletoGenerado IS NOT NULL AND DATEADD(hour, 8, FechaBoletoGenerado) <= SYSDATETIME()";
                using (SqlCommand comando490WC = new SqlCommand(query490WC, cone490WC))
                {
                    comando490WC.ExecuteNonQuery();
                }
            }
        }
        public bool ExisteBoletoEnAsiento490WC(Boleto490WC boletoVerificarExistencia490WC)
        {
            using (SqlConnection con = GestorConexion490WC.DevolverConexion())
            {
                con.Open();
                string query = "SELECT COUNT(*) FROM Boleto WHERE Origen = @Origen AND Destino = @Destino AND FechaPartidaIDA = @FechaPartidaIDA AND FechaLlegadaIDA = @FechaLlegadaIDA AND (@FechaPartidaVuelta IS NULL OR FechaPartidaVUELTA = @FechaPartidaVuelta) AND (@FechaLlegadaVuelta IS NULL OR FechaLlegadaVUELTA = @FechaLlegadaVuelta) AND NumeroAsiento = @NumeroAsiento";

                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@Origen", boletoVerificarExistencia490WC.Origen490WC);
                    cmd.Parameters.AddWithValue("@Destino", boletoVerificarExistencia490WC.Destino490WC);
                    cmd.Parameters.AddWithValue("@FechaPartidaIDA", boletoVerificarExistencia490WC.FechaPartida490WC.ToShortDateString());
                    cmd.Parameters.AddWithValue("@FechaLlegadaIDA", boletoVerificarExistencia490WC.FechaLlegada490WC.ToShortDateString());
                    if (boletoVerificarExistencia490WC is BoletoIDAVUELTA490WC bole490WC)
                    {
                        cmd.Parameters.AddWithValue("@FechaPartidaVuelta", bole490WC.FechaPartidaVUELTA490WC.ToShortDateString());
                        cmd.Parameters.AddWithValue("@FechaLlegadaVuelta", bole490WC.FechaLlegadaVUELTA490WC.ToShortDateString());
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@FechaPartidaVuelta", DBNull.Value);
                        cmd.Parameters.AddWithValue("@FechaLlegadaVuelta", DBNull.Value);
                    }
                    cmd.Parameters.AddWithValue("@NumeroAsiento", boletoVerificarExistencia490WC.NumeroAsiento490WC);
                    int count = (int)cmd.ExecuteScalar();
                    return count > 0;
                }
            }
        }

        public bool ExisteBoletoEnAsientoParaModificar490WC(Boleto490WC boletoVerificarExistencia490WC)
        {
            using (SqlConnection con = GestorConexion490WC.DevolverConexion())
            {
                con.Open();
                string query = "SELECT COUNT(*) FROM Boleto WHERE Origen = @Origen AND Destino = @Destino AND FechaPartidaIDA = @FechaPartidaIDA AND FechaLlegadaIDA = @FechaLlegadaIDA AND (@FechaPartidaVuelta IS NULL OR FechaPartidaVUELTA = @FechaPartidaVuelta) AND (@FechaLlegadaVuelta IS NULL OR FechaLlegadaVUELTA = @FechaLlegadaVuelta) AND NumeroAsiento = @NumeroAsiento AND ID != @IdBoleto";
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@Origen", boletoVerificarExistencia490WC.Origen490WC);
                    cmd.Parameters.AddWithValue("@Destino", boletoVerificarExistencia490WC.Destino490WC);
                    cmd.Parameters.AddWithValue("@FechaPartidaIDA", boletoVerificarExistencia490WC.FechaPartida490WC);
                    cmd.Parameters.AddWithValue("@FechaLlegadaIDA", boletoVerificarExistencia490WC.FechaLlegada490WC);

                    if (boletoVerificarExistencia490WC is BoletoIDAVUELTA490WC bole490WC)
                    {
                        cmd.Parameters.AddWithValue("@FechaPartidaVuelta", bole490WC.FechaPartidaVUELTA490WC);
                        cmd.Parameters.AddWithValue("@FechaLlegadaVuelta", bole490WC.FechaLlegadaVUELTA490WC);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@FechaPartidaVuelta", DBNull.Value);
                        cmd.Parameters.AddWithValue("@FechaLlegadaVuelta", DBNull.Value);
                    }

                    cmd.Parameters.AddWithValue("@NumeroAsiento", boletoVerificarExistencia490WC.NumeroAsiento490WC);
                    cmd.Parameters.AddWithValue("@IdBoleto", boletoVerificarExistencia490WC.IDBoleto490WC);

                    int count = (int)cmd.ExecuteScalar();
                    return count > 0;
                }
            }
        }



        public void CobrarBoleto490WC(Boleto490WC BoletoCobrado490WC)
        {
            using (SqlConnection cone490WC = GestorConexion490WC.DevolverConexion())
            {
                cone490WC.Open();
                string query490WC = "UPDATE Boleto SET IsVendido = 1 WHERE ID = @ID490WC";
                using (SqlCommand comando490WC = new SqlCommand(query490WC, cone490WC))
                {
                    comando490WC.Parameters.AddWithValue("@ID490WC", BoletoCobrado490WC.IDBoleto490WC);
                    comando490WC.ExecuteNonQuery();
                }
            }
        }



        #endregion

        #region Busqueda Boleto

        public List<Boleto490WC> ObtenerBoletosPorModalidad490WC(string Modalidad490WC)
        {
            using (SqlConnection cone490WC = GestorConexion490WC.DevolverConexion())
            {
                List<Boleto490WC> boletos490WC = new List<Boleto490WC>();
                UsuarioDAL gestorUsuario = new UsuarioDAL();
                List<Usuario> Titulares490WC = gestorUsuario.DevolverTodosLosUsuarios();
                cone490WC.Open();
                string query490WC = "";
                if (Modalidad490WC == "IDA")
                {
                    query490WC = "SELECT * FROM Boleto WHERE FechaPartidaVUELTA IS NULL OR FechaLlegadaVUELTA IS NULL";
                    using (SqlCommand comando490WC = new SqlCommand(query490WC, cone490WC))
                    {
                        using (SqlDataReader reader = comando490WC.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Boleto490WC boletoIDA490WC = new BoletoIDA490WC(
                                    reader["ID"].ToString(),
                                    reader["Origen"].ToString(),
                                    reader["Destino"].ToString(),
                                    Convert.ToDateTime(reader["FechaPartidaIDA"]),
                                    Convert.ToDateTime(reader["FechaLlegadaIDA"]),
                                    Convert.ToBoolean(reader["IsVendido"]),
                                    Convert.ToSingle(reader["PesoEquipajePermitido"]),
                                    reader["ClaseBoleto"].ToString(),
                                    Convert.ToSingle(reader["Precio"]),
                                    Titulares490WC.Find(x => x.DNI == reader["Titular"].ToString()),
                                    reader["NumeroAsiento"].ToString()
                                );
                                boletos490WC.Add(boletoIDA490WC);
                            }
                        }
                    }
                }

                if (Modalidad490WC == "IDAVUELTA")
                {
                    query490WC = "SELECT * FROM Boleto WHERE FechaPartidaVUELTA IS NOT NULL AND FechaLlegadaVUELTA IS NOT NULL";
                    using (SqlCommand comando490WC = new SqlCommand(query490WC, cone490WC))
                    {
                        using (SqlDataReader reader = comando490WC.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Boleto490WC boletoIDA490WC = new BoletoIDAVUELTA490WC(
                                    reader["ID"].ToString(),
                                    reader["Origen"].ToString(),
                                    reader["Destino"].ToString(),
                                    Convert.ToDateTime(reader["FechaPartidaIDA"]),
                                    Convert.ToDateTime(reader["FechaLlegadaIDA"]),
                                    Convert.ToDateTime(reader["FechaPartidaVUELTA"]),
                                    Convert.ToDateTime(reader["FechaLlegadaVUELTA"]),
                                    Convert.ToBoolean(reader["IsVendido"]),
                                    Convert.ToSingle(reader["PesoEquipajePermitido"]),
                                    reader["ClaseBoleto"].ToString(),
                                    Convert.ToSingle(reader["Precio"]),
                                   Titulares490WC.Find(x => x.DNI == reader["Titular"].ToString()),
                                   reader["NumeroAsiento"].ToString()
                                );
                                boletos490WC.Add(boletoIDA490WC);
                            }
                        }
                    }
                }

                return boletos490WC;
            }
        }

        public Boleto490WC ObtenerBoletoPorID490WC(string ID490WC)
        {
            using (SqlConnection cone490WC = GestorConexion490WC.DevolverConexion())
            {
                UsuarioDAL gestorUsuario = new UsuarioDAL();
                List<Usuario> Titulares490WC = gestorUsuario.DevolverTodosLosUsuarios();
                cone490WC.Open();
                string query490WC = "SELECT * FROM Boleto WHERE ID = @ID490WC";
                using (SqlCommand comando490WC = new SqlCommand(query490WC, cone490WC))
                {
                    comando490WC.Parameters.AddWithValue("@ID490WC", ID490WC);
                    using (SqlDataReader reader = comando490WC.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            string dni490WC = reader["Titular"].ToString();
                            if (reader["FechaPartidaVUELTA"] == DBNull.Value || reader["FechaLlegadaVUELTA"] == DBNull.Value)
                            {
                                return new BoletoIDA490WC(
                                    reader["ID"].ToString(),
                                    reader["Origen"].ToString(),
                                    reader["Destino"].ToString(),
                                    Convert.ToDateTime(reader["FechaPartidaIDA"]),
                                    Convert.ToDateTime(reader["FechaLlegadaIDA"]),
                                    Convert.ToBoolean(reader["IsVendido"]),
                                    Convert.ToSingle(reader["PesoEquipajePermitido"]),
                                    reader["ClaseBoleto"].ToString(),
                                    Convert.ToSingle(reader["Precio"]),
                                    Titulares490WC.Find(x => x.DNI == dni490WC),
                                    reader["NumeroAsiento"].ToString()
                                );
                            }
                            else
                            {
                                return new BoletoIDAVUELTA490WC(
                                    reader["ID"].ToString(),
                                    reader["Origen"].ToString(),
                                    reader["Destino"].ToString(),
                                    Convert.ToDateTime(reader["FechaPartidaIDA"]),
                                    Convert.ToDateTime(reader["FechaLlegadaIDA"]),
                                    Convert.ToDateTime(reader["FechaPartidaVUELTA"]),
                                    Convert.ToDateTime(reader["FechaLlegadaVUELTA"]),
                                    Convert.ToBoolean(reader["IsVendido"]),
                                    Convert.ToSingle(reader["PesoEquipajePermitido"]),
                                    reader["ClaseBoleto"].ToString(),
                                    Convert.ToSingle(reader["Precio"]),
                                    Titulares490WC.Find(x => x.DNI == dni490WC),
                                    reader["NumeroAsiento"].ToString()
                                );
                            }
                        }
                    }
                }
                return null;
            }
        }

        public List<Boleto490WC> ObtenerBoletosPorPagarCliente490WC(Usuario cliente490WC)
        {
            using (SqlConnection cone490WC = GestorConexion490WC.DevolverConexion())
            {
                List<Boleto490WC> boletos490WC = new List<Boleto490WC>();
                UsuarioDAL gestorUsuario = new UsuarioDAL();
                List<Usuario> Titulares490WC = gestorUsuario.DevolverTodosLosUsuarios();
                cone490WC.Open();
                string query490WC = "SELECT * FROM Boleto WHERE Titular = @Titular490WC AND IsVendido = 0";
                using (SqlCommand comando490WC = new SqlCommand(query490WC, cone490WC))
                {
                    comando490WC.Parameters.AddWithValue("@Titular490WC", cliente490WC.DNI);
                    using (SqlDataReader reader = comando490WC.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            if (reader["FechaPartidaVUELTA"] == DBNull.Value || reader["FechaLlegadaVUELTA"] == DBNull.Value)
                            {
                                Boleto490WC boletoPagar490WC = new BoletoIDA490WC(
                                   reader["ID"].ToString(),
                                   reader["Origen"].ToString(),
                                   reader["Destino"].ToString(),
                                   Convert.ToDateTime(reader["FechaPartidaIDA"]),
                                   Convert.ToDateTime(reader["FechaLlegadaIDA"]),
                                   Convert.ToBoolean(reader["IsVendido"]),
                                   Convert.ToSingle(reader["PesoEquipajePermitido"]),
                                   reader["ClaseBoleto"].ToString(),
                                   Convert.ToSingle(reader["Precio"]),
                                   Titulares490WC.Find(x => x.DNI == cliente490WC.DNI),
                                   reader["NumeroAsiento"].ToString()
                               );
                                boletos490WC.Add(boletoPagar490WC);
                            }
                            else
                            {
                                Boleto490WC boletoPagar490WC = new BoletoIDAVUELTA490WC(
                                    reader["ID"].ToString(),
                                    reader["Origen"].ToString(),
                                    reader["Destino"].ToString(),
                                    Convert.ToDateTime(reader["FechaPartidaIDA"]),
                                    Convert.ToDateTime(reader["FechaLlegadaIDA"]),
                                    Convert.ToDateTime(reader["FechaPartidaVUELTA"]),
                                    Convert.ToDateTime(reader["FechaLlegadaVUELTA"]),
                                    Convert.ToBoolean(reader["IsVendido"]),
                                    Convert.ToSingle(reader["PesoEquipajePermitido"]),
                                    reader["ClaseBoleto"].ToString(),
                                    Convert.ToSingle(reader["Precio"]),
                                    Titulares490WC.Find(x => x.DNI == cliente490WC.DNI),
                                    reader["NumeroAsiento"].ToString()
                                );
                                boletos490WC.Add(boletoPagar490WC);
                            }
                        }
                    }
                }
                return boletos490WC;
            }
        }

        public List<Boleto490WC> ObtenerBoletosPorCliente490WC(Usuario cliente490WC)
        {
            using (SqlConnection cone490WC = GestorConexion490WC.DevolverConexion())
            {
                List<Boleto490WC> boletos490WC = new List<Boleto490WC>();
                UsuarioDAL gestorUsuario = new UsuarioDAL();
                List<Usuario> Titulares490WC = gestorUsuario.DevolverTodosLosUsuarios();
                cone490WC.Open();
                string query490WC = "SELECT * FROM Boleto WHERE Titular = @Titular490WC";
                using (SqlCommand comando490WC = new SqlCommand(query490WC, cone490WC))
                {
                    comando490WC.Parameters.AddWithValue("@Titular490WC", cliente490WC.DNI);
                    using (SqlDataReader reader = comando490WC.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            if (reader["FechaPartidaVUELTA"] == DBNull.Value || reader["FechaLlegadaVUELTA"] == DBNull.Value)
                            {
                                if (reader["BeneficioAplicado"] == DBNull.Value)
                                {

                                    Boleto490WC boletoAgregar490WC = new BoletoIDA490WC(
                                        reader["ID"].ToString(),
                                        reader["Origen"].ToString(),
                                        reader["Destino"].ToString(),
                                        Convert.ToDateTime(reader["FechaPartidaIDA"]),
                                        Convert.ToDateTime(reader["FechaLlegadaIDA"]),
                                        Convert.ToBoolean(reader["IsVendido"]),
                                        Convert.ToSingle(reader["PesoEquipajePermitido"]),
                                        reader["ClaseBoleto"].ToString(),
                                        Convert.ToSingle(reader["Precio"]),
                                        cliente490WC,
                                        reader["NumeroAsiento"].ToString()
                                    );
                                    boletos490WC.Add(boletoAgregar490WC);
                                }
                                else
                                {
                                    Boleto490WC boletoAgregar490WC = new BoletoIDA490WC(
                                    reader["ID"].ToString(),
                                    reader["Origen"].ToString(),
                                    reader["Destino"].ToString(),
                                    Convert.ToDateTime(reader["FechaPartidaIDA"]),
                                    Convert.ToDateTime(reader["FechaLlegadaIDA"]),
                                    Convert.ToBoolean(reader["IsVendido"]),
                                    Convert.ToSingle(reader["PesoEquipajePermitido"]),
                                    reader["ClaseBoleto"].ToString(),
                                    Convert.ToSingle(reader["Precio"]),
                                    cliente490WC,
                                    reader["NumeroAsiento"].ToString(),
                                    reader["BeneficioAplicado"].ToString()
                                );
                                    boletos490WC.Add(boletoAgregar490WC);
                                }
                            }
                            else
                            {
                                if (reader["BeneficioAplicado"] == DBNull.Value)
                                {
                                    Boleto490WC boletoAgregar490WC = new BoletoIDAVUELTA490WC(
                                    reader["ID"].ToString(),
                                    reader["Origen"].ToString(),
                                    reader["Destino"].ToString(),
                                    Convert.ToDateTime(reader["FechaPartidaIDA"]),
                                    Convert.ToDateTime(reader["FechaLlegadaIDA"]),
                                    Convert.ToDateTime(reader["FechaPartidaVUELTA"]),
                                    Convert.ToDateTime(reader["FechaLlegadaVUELTA"]),
                                    Convert.ToBoolean(reader["IsVendido"]),
                                    Convert.ToSingle(reader["PesoEquipajePermitido"]),
                                    reader["ClaseBoleto"].ToString(),
                                    Convert.ToSingle(reader["Precio"]),
                                    cliente490WC,
                                    reader["NumeroAsiento"].ToString()
                                );
                                    boletos490WC.Add(boletoAgregar490WC);
                                }
                                else
                                {
                                    Boleto490WC boletoAgregar490WC = new BoletoIDAVUELTA490WC(
                                    reader["ID"].ToString(),
                                    reader["Origen"].ToString(),
                                    reader["Destino"].ToString(),
                                    Convert.ToDateTime(reader["FechaPartidaIDA"]),
                                    Convert.ToDateTime(reader["FechaLlegadaIDA"]),
                                    Convert.ToDateTime(reader["FechaPartidaVUELTA"]),
                                    Convert.ToDateTime(reader["FechaLlegadaVUELTA"]),
                                    Convert.ToBoolean(reader["IsVendido"]),
                                    Convert.ToSingle(reader["PesoEquipajePermitido"]),
                                    reader["ClaseBoleto"].ToString(),
                                    Convert.ToSingle(reader["Precio"]),
                                    cliente490WC,
                                    reader["NumeroAsiento"].ToString(),
                                    reader["BeneficioAplicado"].ToString()
                                );
                                    boletos490WC.Add(boletoAgregar490WC);
                                }
                            }
                        }
                    }
                }
                return boletos490WC;
            }
        }

        public List<Boleto490WC> ObtenerTodosLosBoletos490WC()
        {
            using (SqlConnection cone490WC = GestorConexion490WC.DevolverConexion())
            {
                List<Boleto490WC> boletos490WC = new List<Boleto490WC>();
                UsuarioDAL gestorUsuario = new UsuarioDAL();
                List<Usuario> Titulares490WC = gestorUsuario.DevolverTodosLosUsuarios();
                cone490WC.Open();
                string query490WC = "SELECT * FROM Boleto";
                using (SqlCommand comando490WC = new SqlCommand(query490WC, cone490WC))
                {

                    using (SqlDataReader reader = comando490WC.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            if (reader["FechaPartidaVUELTA"] == DBNull.Value || reader["FechaLlegadaVUELTA"] == DBNull.Value)
                            {
                                Boleto490WC boletoPagar490WC = new BoletoIDA490WC(
                                   reader["ID"].ToString(),
                                   reader["Origen"].ToString(),
                                   reader["Destino"].ToString(),
                                   Convert.ToDateTime(reader["FechaPartidaIDA"]),
                                   Convert.ToDateTime(reader["FechaLlegadaIDA"]),
                                   Convert.ToBoolean(reader["IsVendido"]),
                                   Convert.ToSingle(reader["PesoEquipajePermitido"]),
                                   reader["ClaseBoleto"].ToString(),
                                   Convert.ToSingle(reader["Precio"]),
                                   Titulares490WC.Find(x => x.DNI == reader["Titular"].ToString()),
                                   reader["NumeroAsiento"].ToString()
                               );
                                boletos490WC.Add(boletoPagar490WC);
                            }
                            else
                            {
                                Boleto490WC boletoPagar490WC = new BoletoIDAVUELTA490WC(
                                    reader["ID"].ToString(),
                                    reader["Origen"].ToString(),
                                    reader["Destino"].ToString(),
                                    Convert.ToDateTime(reader["FechaPartidaIDA"]),
                                    Convert.ToDateTime(reader["FechaLlegadaIDA"]),
                                    Convert.ToDateTime(reader["FechaPartidaVUELTA"]),
                                    Convert.ToDateTime(reader["FechaLlegadaVUELTA"]),
                                    Convert.ToBoolean(reader["IsVendido"]),
                                    Convert.ToSingle(reader["PesoEquipajePermitido"]),
                                    reader["ClaseBoleto"].ToString(),
                                    Convert.ToSingle(reader["Precio"]),
                                    Titulares490WC.Find(x => x.DNI == reader["Titular"].ToString()),
                                    reader["NumeroAsiento"].ToString()
                                );
                                boletos490WC.Add(boletoPagar490WC);
                            }
                        }
                    }
                }
                return boletos490WC;
            }
        }



        public List<Boleto490WC> ObtenerBoletosFiltrados490WC(string origen490WC = "", string destino490WC = "", string claseBoleto490WC = "", float? precioDesde490WC = null, float? precioHasta490WC = null, float? pesoPermitido490WC = null, DateTime? fechaPartida490WC = null, DateTime? fechaLlegada490WC = null, DateTime? fechaPartidaVUELTA490WC = null, DateTime? fechaLlegadaVUELTA490WC = null)
        {
            List<Boleto490WC> boletos490WC = new List<Boleto490WC>();
            UsuarioDAL gestorUsuario = new UsuarioDAL();
            List<Usuario> Titulares490WC = gestorUsuario.DevolverTodosLosUsuarios();
            using (SqlConnection cone490WC = GestorConexion490WC.DevolverConexion())
            {
                cone490WC.Open();


                string query = "SELECT * FROM Boleto WHERE FechaBoletoGenerado IS NULL";

                if (!string.IsNullOrEmpty(origen490WC))
                    query += " AND Origen = @Origen";
                if (!string.IsNullOrEmpty(destino490WC))
                    query += " AND Destino = @Destino";
                if (!string.IsNullOrEmpty(claseBoleto490WC))
                    query += " AND ClaseBoleto = @ClaseBoleto";
                if (precioDesde490WC.HasValue)
                    query += " AND Precio >= @PrecioDesde";
                if (precioHasta490WC.HasValue)
                    query += " AND Precio <= @PrecioHasta";
                if (pesoPermitido490WC.HasValue)
                    query += " AND PesoEquipajePermitido = @PesoPermitido";
                if (fechaPartida490WC.HasValue)
                    query += " AND FechaPartidaIDA >= @FechaPartida";
                if (fechaLlegada490WC.HasValue)
                    query += " AND FechaLlegadaIDA <= @FechaLlegada";
                if (fechaPartidaVUELTA490WC.HasValue)
                    query += " AND FechaPartidaVUELTA >= @FechaPartidaVuelta";
                if (fechaLlegadaVUELTA490WC.HasValue)
                    query += " AND FechaLlegadaVUELTA <= @FechaLlegadaVuelta";


                using (SqlCommand comando490WC = new SqlCommand(query, cone490WC))
                {
                    if (!string.IsNullOrEmpty(origen490WC))
                        comando490WC.Parameters.AddWithValue("@Origen", origen490WC);
                    if (!string.IsNullOrEmpty(destino490WC))
                        comando490WC.Parameters.AddWithValue("@Destino", destino490WC);
                    if (!string.IsNullOrEmpty(claseBoleto490WC))
                        comando490WC.Parameters.AddWithValue("@ClaseBoleto", claseBoleto490WC);
                    if (precioDesde490WC.HasValue)
                        comando490WC.Parameters.AddWithValue("@PrecioDesde", precioDesde490WC.Value);
                    if (precioHasta490WC.HasValue)
                        comando490WC.Parameters.AddWithValue("@PrecioHasta", precioHasta490WC.Value);
                    if (pesoPermitido490WC.HasValue)
                        comando490WC.Parameters.AddWithValue("@PesoPermitido", pesoPermitido490WC.Value);
                    if (fechaPartida490WC.HasValue)
                        comando490WC.Parameters.AddWithValue("@FechaPartida", fechaPartida490WC.Value);
                    if (fechaLlegada490WC.HasValue)
                        comando490WC.Parameters.AddWithValue("@FechaLlegada", fechaLlegada490WC.Value);
                    if (fechaPartidaVUELTA490WC.HasValue)
                        comando490WC.Parameters.AddWithValue("@FechaPartidaVuelta", fechaPartidaVUELTA490WC.Value);
                    if (fechaLlegadaVUELTA490WC.HasValue)
                        comando490WC.Parameters.AddWithValue("@FechaLlegadaVuelta", fechaLlegadaVUELTA490WC.Value);


                    using (SqlDataReader reader = comando490WC.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            if (reader["FechaPartidaVUELTA"] == DBNull.Value || reader["FechaLlegadaVUELTA"] == DBNull.Value)
                            {
                                Boleto490WC boletoPagar490WC = new BoletoIDA490WC(
                                   reader["ID"].ToString(),
                                   reader["Origen"].ToString(),
                                   reader["Destino"].ToString(),
                                   Convert.ToDateTime(reader["FechaPartidaIDA"]),
                                   Convert.ToDateTime(reader["FechaLlegadaIDA"]),
                                   Convert.ToBoolean(reader["IsVendido"]),
                                   Convert.ToSingle(reader["PesoEquipajePermitido"]),
                                   reader["ClaseBoleto"].ToString(),
                                   Convert.ToSingle(reader["Precio"]),
                                   Titulares490WC.Find(x => x.DNI == reader["Titular"].ToString()),
                                   reader["NumeroAsiento"].ToString()
                               );
                                boletos490WC.Add(boletoPagar490WC);
                            }
                            else
                            {
                                Boleto490WC boletoPagar490WC = new BoletoIDAVUELTA490WC(
                                    reader["ID"].ToString(),
                                    reader["Origen"].ToString(),
                                    reader["Destino"].ToString(),
                                    Convert.ToDateTime(reader["FechaPartidaIDA"]),
                                    Convert.ToDateTime(reader["FechaLlegadaIDA"]),
                                    Convert.ToDateTime(reader["FechaPartidaVUELTA"]),
                                    Convert.ToDateTime(reader["FechaLlegadaVUELTA"]),
                                    Convert.ToBoolean(reader["IsVendido"]),
                                    Convert.ToSingle(reader["PesoEquipajePermitido"]),
                                    reader["ClaseBoleto"].ToString(),
                                    Convert.ToSingle(reader["Precio"]),
                                    Titulares490WC.Find(x => x.DNI == reader["Titular"].ToString()),
                                    reader["NumeroAsiento"].ToString()
                                );
                                boletos490WC.Add(boletoPagar490WC);
                            }
                        }
                    }
                }
            }
            return boletos490WC;
        }

        public Boleto490WC ObtenerBoletoConBeneficio490WC(string ID490WC)
        {
            using (SqlConnection cone490WC = GestorConexion490WC.DevolverConexion())
            {
                UsuarioDAL gestorUsuario = new UsuarioDAL();
                List<Usuario> Titulares490WC = gestorUsuario.DevolverTodosLosUsuarios();
                cone490WC.Open();
                string query490WC = "SELECT * FROM Boleto WHERE ID = @ID490WC";
                using (SqlCommand comando490WC = new SqlCommand(query490WC, cone490WC))
                {
                    comando490WC.Parameters.AddWithValue("@ID490WC", ID490WC);
                    using (SqlDataReader reader = comando490WC.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            if (reader["FechaPartidaVUELTA"] == DBNull.Value || reader["FechaLlegadaVUELTA"] == DBNull.Value)
                            {
                                if (reader["BeneficioAplicado"] == DBNull.Value)
                                {

                                    return new BoletoIDA490WC(
                                        reader["ID"].ToString(),
                                        reader["Origen"].ToString(),
                                        reader["Destino"].ToString(),
                                        Convert.ToDateTime(reader["FechaPartidaIDA"]),
                                        Convert.ToDateTime(reader["FechaLlegadaIDA"]),
                                        Convert.ToBoolean(reader["IsVendido"]),
                                        Convert.ToSingle(reader["PesoEquipajePermitido"]),
                                        reader["ClaseBoleto"].ToString(),
                                        Convert.ToSingle(reader["Precio"]),
                                        Titulares490WC.Find(x => x.DNI == ID490WC),
                                        reader["NumeroAsiento"].ToString()
                                    );
                                }
                                else
                                {
                                    return new BoletoIDA490WC(
                                    reader["ID"].ToString(),
                                    reader["Origen"].ToString(),
                                    reader["Destino"].ToString(),
                                    Convert.ToDateTime(reader["FechaPartidaIDA"]),
                                    Convert.ToDateTime(reader["FechaLlegadaIDA"]),
                                    Convert.ToBoolean(reader["IsVendido"]),
                                    Convert.ToSingle(reader["PesoEquipajePermitido"]),
                                    reader["ClaseBoleto"].ToString(),
                                    Convert.ToSingle(reader["Precio"]),
                                    Titulares490WC.Find(x => x.DNI == ID490WC),
                                    reader["NumeroAsiento"].ToString(),
                                    reader["BeneficioAplicado"].ToString()
                                );
                                }
                            }
                            else
                            {
                                if (reader["BeneficioAplicado"] == DBNull.Value)
                                {
                                    return new BoletoIDAVUELTA490WC(
                                    reader["ID"].ToString(),
                                    reader["Origen"].ToString(),
                                    reader["Destino"].ToString(),
                                    Convert.ToDateTime(reader["FechaPartidaIDA"]),
                                    Convert.ToDateTime(reader["FechaLlegadaIDA"]),
                                    Convert.ToDateTime(reader["FechaPartidaVUELTA"]),
                                    Convert.ToDateTime(reader["FechaLlegadaVUELTA"]),
                                    Convert.ToBoolean(reader["IsVendido"]),
                                    Convert.ToSingle(reader["PesoEquipajePermitido"]),
                                    reader["ClaseBoleto"].ToString(),
                                    Convert.ToSingle(reader["Precio"]),
                                    Titulares490WC.Find(x => x.DNI == ID490WC),
                                    reader["NumeroAsiento"].ToString()
                                );

                                }
                                else
                                {
                                    return new BoletoIDAVUELTA490WC(
                                    reader["ID"].ToString(),
                                    reader["Origen"].ToString(),
                                    reader["Destino"].ToString(),
                                    Convert.ToDateTime(reader["FechaPartidaIDA"]),
                                    Convert.ToDateTime(reader["FechaLlegadaIDA"]),
                                    Convert.ToDateTime(reader["FechaPartidaVUELTA"]),
                                    Convert.ToDateTime(reader["FechaLlegadaVUELTA"]),
                                    Convert.ToBoolean(reader["IsVendido"]),
                                    Convert.ToSingle(reader["PesoEquipajePermitido"]),
                                    reader["ClaseBoleto"].ToString(),
                                    Convert.ToSingle(reader["Precio"]),
                                    Titulares490WC.Find(x => x.DNI == ID490WC),
                                    reader["NumeroAsiento"].ToString(),
                                    reader["BeneficioAplicado"].ToString()
                                );
                                }
                            }
                        }
                    }
                }
                return null;
            }
        }


        #endregion
    }
}
