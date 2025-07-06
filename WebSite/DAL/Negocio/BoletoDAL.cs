using BE;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Negocio
{
    public class BoletoDAL
    {
        #region Operaciones Boleto



        public void Alta(Boleto BoletoAgregar)
        {
            using (SqlConnection cone = GestorConexion.DevolverConexion())
            {
                cone.Open();


                string queryMaxId = "SELECT ISNULL(MAX(CAST(ID AS INT)), 0) + 1 FROM Boleto";

                int nuevoId;
                using (SqlCommand cmdId = new SqlCommand(queryMaxId, cone))
                {
                    nuevoId = Convert.ToInt32(cmdId.ExecuteScalar());
                }


                BoletoAgregar.IDBoleto = nuevoId.ToString();

                string query = "";

                if (BoletoAgregar is BoletoIDA boletoIDA)
                {
                    query = @"INSERT INTO Boleto (ID, Origen, Destino, FechaPartidaIDA, FechaLlegadaIDA, IsVendido, PesoEquipajePermitido, ClaseBoleto, Precio, Titular, NumeroAsiento) VALUES (@ID, @Origen, @Destino, @FechaPartidaIDA, @FechaLlegadaIDA, @IsVendido, @PesoEquipajePermitido, @ClaseBoleto, @Precio, @Titular, @NumeroAsiento)";

                    using (SqlCommand comando = new SqlCommand(query, cone))
                    {
                        comando.Parameters.AddWithValue("@ID", boletoIDA.IDBoleto);
                        comando.Parameters.AddWithValue("@Origen", boletoIDA.Origen);
                        comando.Parameters.AddWithValue("@Destino", boletoIDA.Destino);
                        comando.Parameters.AddWithValue("@FechaPartidaIDA", boletoIDA.FechaPartida);
                        comando.Parameters.AddWithValue("@FechaLlegadaIDA", boletoIDA.FechaLlegada);
                        comando.Parameters.AddWithValue("@IsVendido", boletoIDA.IsVendido);
                        comando.Parameters.AddWithValue("@PesoEquipajePermitido", boletoIDA.EquipajePermitido);
                        comando.Parameters.AddWithValue("@ClaseBoleto", boletoIDA.ClaseBoleto);
                        comando.Parameters.AddWithValue("@Precio", boletoIDA.Precio);
                        comando.Parameters.AddWithValue("@Titular", boletoIDA.Titular.DNI);
                        comando.Parameters.AddWithValue("@NumeroAsiento", boletoIDA.NumeroAsiento);

                        comando.ExecuteNonQuery();
                    }
                }
                else if (BoletoAgregar is BoletoIDAVUELTA boletoIDAVUELTA)
                {
                    query = @"INSERT INTO Boleto (ID, Origen, Destino, FechaPartidaIDA, FechaLlegadaIDA, FechaPartidaVUELTA, FechaLlegadaVUELTA, IsVendido, PesoEquipajePermitido, ClaseBoleto, Precio, Titular, NumeroAsiento) VALUES (@ID, @Origen, @Destino, @FechaPartidaIDA, @FechaLlegadaIDA, @FechaPartidaVUELTA, @FechaLlegadaVUELTA, @IsVendido, @PesoEquipajePermitido, @ClaseBoleto, @Precio, @Titular, @NumeroAsiento)";

                    using (SqlCommand comando = new SqlCommand(query, cone))
                    {
                        comando.Parameters.AddWithValue("@ID", boletoIDAVUELTA.IDBoleto);
                        comando.Parameters.AddWithValue("@Origen", boletoIDAVUELTA.Origen);
                        comando.Parameters.AddWithValue("@Destino", boletoIDAVUELTA.Destino);
                        comando.Parameters.AddWithValue("@FechaPartidaIDA", boletoIDAVUELTA.FechaPartida);
                        comando.Parameters.AddWithValue("@FechaLlegadaIDA", boletoIDAVUELTA.FechaLlegada);
                        comando.Parameters.AddWithValue("@FechaPartidaVUELTA", boletoIDAVUELTA.FechaPartidaVUELTA);
                        comando.Parameters.AddWithValue("@FechaLlegadaVUELTA", boletoIDAVUELTA.FechaLlegadaVUELTA);
                        comando.Parameters.AddWithValue("@IsVendido", boletoIDAVUELTA.IsVendido);
                        comando.Parameters.AddWithValue("@PesoEquipajePermitido", boletoIDAVUELTA.EquipajePermitido);
                        comando.Parameters.AddWithValue("@ClaseBoleto", boletoIDAVUELTA.ClaseBoleto);
                        comando.Parameters.AddWithValue("@Precio", boletoIDAVUELTA.Precio);
                        comando.Parameters.AddWithValue("@Titular", boletoIDAVUELTA.Titular.DNI);
                        comando.Parameters.AddWithValue("@NumeroAsiento", boletoIDAVUELTA.NumeroAsiento);

                        comando.ExecuteNonQuery();
                    }
                }
            }
        }


        public void Baja(string IDBoleto)
        {
            using (SqlConnection cone = GestorConexion.DevolverConexion())
            {
                cone.Open();
                string query = "DELETE FROM Boleto WHERE ID = @IDBoleto";
                using (SqlCommand comando = new SqlCommand(query, cone))
                {
                    comando.Parameters.AddWithValue("@IDBoleto", IDBoleto);
                    comando.ExecuteNonQuery();
                }
            }
        }

        public void Modificar(Boleto BoletoModificado)
        {
            using (SqlConnection con = GestorConexion.DevolverConexion())
            {
                con.Open();
                string query = "";
                if (BoletoModificado is BoletoIDA boletoIDA)
                {
                    query = "UPDATE Boleto SET Origen = @Origen, Destino = @Destino, FechaPartidaIDA = @FechaPartidaIDA, FechaLlegadaIDA = @FechaLlegadaIDA, IsVendido = @IsVendido, PesoEquipajePermitido = @PesoEquipajePermitido, ClaseBoleto = @ClaseBoleto, Precio = @Precio, Titular = @Titular, NumeroAsiento = @NumeroAsiento WHERE ID = @ID";
                    using (SqlCommand comando = new SqlCommand(query, con))
                    {
                        comando.Parameters.AddWithValue("@ID", boletoIDA.IDBoleto);
                        comando.Parameters.AddWithValue("@Origen", boletoIDA.Origen);
                        comando.Parameters.AddWithValue("@Destino", boletoIDA.Destino);
                        comando.Parameters.AddWithValue("@FechaPartidaIDA", boletoIDA.FechaPartida);
                        comando.Parameters.AddWithValue("@FechaLlegadaIDA", boletoIDA.FechaLlegada);
                        comando.Parameters.AddWithValue("@IsVendido", boletoIDA.IsVendido);
                        comando.Parameters.AddWithValue("@PesoEquipajePermitido", boletoIDA.EquipajePermitido);
                        comando.Parameters.AddWithValue("@ClaseBoleto", boletoIDA.ClaseBoleto);
                        comando.Parameters.AddWithValue("@Precio", boletoIDA.Precio);
                        comando.Parameters.AddWithValue("@Titular", boletoIDA.Titular.DNI);
                        comando.Parameters.AddWithValue("@NumeroAsiento", boletoIDA.NumeroAsiento);

                        comando.ExecuteNonQuery();
                    }
                }

                if (BoletoModificado is BoletoIDAVUELTA boletoIDAVUELTA)
                {
                    query = "UPDATE Boleto SET Origen = @Origen, Destino = @Destino, FechaPartidaIDA = @FechaPartidaIDA, FechaLlegadaIDA = @FechaLlegadaIDA, FechaPartidaVUELTA = @FechaPartidaVUELTA, FechaLlegadaVUELTA = @FechaLlegadaVUELTA, IsVendido = @IsVendido, PesoEquipajePermitido = @PesoEquipajePermitido, ClaseBoleto = @ClaseBoleto, Precio = @Precio, Titular = @Titular, NumeroAsiento = @NumeroAsiento WHERE ID = @ID";
                    using (SqlCommand comand = new SqlCommand(query, con))
                    {
                        comand.Parameters.AddWithValue("@ID", boletoIDAVUELTA.IDBoleto);
                        comand.Parameters.AddWithValue("@Origen", boletoIDAVUELTA.Origen);
                        comand.Parameters.AddWithValue("@Destino", boletoIDAVUELTA.Destino);
                        comand.Parameters.AddWithValue("@FechaPartidaIDA", boletoIDAVUELTA.FechaPartida);
                        comand.Parameters.AddWithValue("@FechaLlegadaIDA", boletoIDAVUELTA.FechaLlegada);
                        comand.Parameters.AddWithValue("@FechaPartidaVUELTA", boletoIDAVUELTA.FechaPartidaVUELTA);
                        comand.Parameters.AddWithValue("@FechaLlegadaVUELTA", boletoIDAVUELTA.FechaLlegadaVUELTA);
                        comand.Parameters.AddWithValue("@IsVendido", boletoIDAVUELTA.IsVendido);
                        comand.Parameters.AddWithValue("@PesoEquipajePermitido", boletoIDAVUELTA.EquipajePermitido);
                        comand.Parameters.AddWithValue("@ClaseBoleto", boletoIDAVUELTA.ClaseBoleto);
                        comand.Parameters.AddWithValue("@Precio", boletoIDAVUELTA.Precio);
                        comand.Parameters.AddWithValue("@Titular", boletoIDAVUELTA.Titular.DNI);
                        comand.Parameters.AddWithValue("@NumeroAsiento", boletoIDAVUELTA.NumeroAsiento);

                        comand.ExecuteNonQuery();
                    }
                }
            }
        }
        public bool ExisteBoletoAsignar(int idBoleto)
        {
            using (SqlConnection cone = GestorConexion.DevolverConexion())
            {
                cone.Open();
                string query = "SELECT CASE WHEN EXISTS (SELECT 1 FROM Boleto WHERE ID = @ID AND FechaBoletoGenerado IS NOT NULL AND (Titular = @ID OR Titular = 'Sistema')) THEN 1 ELSE 0 END";

                using (SqlCommand comando = new SqlCommand(query, cone))
                {
                    comando.Parameters.AddWithValue("@ID", idBoleto);
                    int resultado = (int)comando.ExecuteScalar();
                    return resultado == 1;
                }
            }
        }

        public void AsignarBoletoCliente(Boleto boletoAsignar, Usuario clienteAsignar)
        {
            using (SqlConnection cone = GestorConexion.DevolverConexion())
            {
                cone.Open();
                string query = "UPDATE Boleto SET Titular = @Titular, FechaBoletoGenerado = @FechaBoletoGenerado WHERE ID = @ID AND FechaBoletoGenerado IS  NULL AND (Titular = @ID OR Titular = 'Sistema' OR Titular = @Titular)";

                using (SqlCommand comando = new SqlCommand(query, cone))
                {
                    comando.Parameters.AddWithValue("@ID", boletoAsignar.IDBoleto);
                    comando.Parameters.AddWithValue("@Titular", clienteAsignar.DNI);
                    comando.Parameters.AddWithValue("@FechaBoletoGenerado", DateTime.Now);

                    comando.ExecuteNonQuery();
                }
            }
        }

        public void AsignarBoletoClienteRegistrar(Boleto boletoAsignar, Usuario clienteAsignar)
        {
            using (SqlConnection cone = GestorConexion.DevolverConexion())
            {
                cone.Open();
                string query = "UPDATE Boleto SET Titular = @Titular, FechaBoletoGenerado = @FechaBoletoGenerado WHERE ID4 = @ID AND FechaBoletoGenerado IS NOT NULL AND (Titular = @ID OR Titular = 'Sistema' OR Titular = @Titular)";

                using (SqlCommand comando = new SqlCommand(query, cone))
                {
                    comando.Parameters.AddWithValue("@ID", boletoAsignar.IDBoleto);
                    comando.Parameters.AddWithValue("@Titular", clienteAsignar.DNI);
                    comando.Parameters.AddWithValue("@FechaBoletoGenerado", DateTime.Now);

                    comando.ExecuteNonQuery();
                }
            }
        }

        public void GenerarBoletoCompra(Boleto boletoGenerar)
        {
            using (SqlConnection cone = GestorConexion.DevolverConexion())
            {
                cone.Open();
                string query = "UPDATE Boleto SET Titular = @Titular, FechaBoletoGenerado = @FechaBoletoGenerado WHERE ID = @ID";
                using (SqlCommand comando = new SqlCommand(query, cone))
                {
                    comando.Parameters.AddWithValue("@ID", boletoGenerar.IDBoleto);
                    comando.Parameters.AddWithValue("@Titular", boletoGenerar.IDBoleto);
                    comando.Parameters.AddWithValue("@FechaBoletoGenerado", DateTime.Now);

                    comando.ExecuteNonQuery();
                }
            }
        }

        public void LiberarBoletosVencidos()
        {
            using (SqlConnection cone = GestorConexion.DevolverConexion())
            {
                cone.Open();
                string query = "UPDATE Boleto SET Titular = 'Sistema', FechaBoletoGenerado = NULL, BeneficioAplicado = NULL WHERE IsVendido = 0 AND FechaBoletoGenerado IS NOT NULL AND DATEADD(hour, 8, FechaBoletoGenerado) <= SYSDATETIME()";
                using (SqlCommand comando = new SqlCommand(query, cone))
                {
                    comando.ExecuteNonQuery();
                }
            }
        }
        public bool ExisteBoletoEnAsiento(Boleto boletoVerificarExistencia)
        {
            using (SqlConnection con = GestorConexion.DevolverConexion())
            {
                con.Open();
                string query = "SELECT COUNT(*) FROM Boleto WHERE Origen = @Origen AND Destino = @Destino AND FechaPartidaIDA = @FechaPartidaIDA AND FechaLlegadaIDA = @FechaLlegadaIDA AND (@FechaPartidaVuelta IS NULL OR FechaPartidaVUELTA = @FechaPartidaVuelta) AND (@FechaLlegadaVuelta IS NULL OR FechaLlegadaVUELTA = @FechaLlegadaVuelta) AND NumeroAsiento = @NumeroAsiento";

                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@Origen", boletoVerificarExistencia.Origen);
                    cmd.Parameters.AddWithValue("@Destino", boletoVerificarExistencia.Destino);
                    cmd.Parameters.AddWithValue("@FechaPartidaIDA", boletoVerificarExistencia.FechaPartida.ToShortDateString());
                    cmd.Parameters.AddWithValue("@FechaLlegadaIDA", boletoVerificarExistencia.FechaLlegada.ToShortDateString());
                    if (boletoVerificarExistencia is BoletoIDAVUELTA bole)
                    {
                        cmd.Parameters.AddWithValue("@FechaPartidaVuelta", bole.FechaPartidaVUELTA.ToShortDateString());
                        cmd.Parameters.AddWithValue("@FechaLlegadaVuelta", bole.FechaLlegadaVUELTA.ToShortDateString());
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@FechaPartidaVuelta", DBNull.Value);
                        cmd.Parameters.AddWithValue("@FechaLlegadaVuelta", DBNull.Value);
                    }
                    cmd.Parameters.AddWithValue("@NumeroAsiento", boletoVerificarExistencia.NumeroAsiento);
                    int count = (int)cmd.ExecuteScalar();
                    return count > 0;
                }
            }
        }

        public bool ExisteBoletoEnAsientoParaModificar(Boleto boletoVerificarExistencia)
        {
            using (SqlConnection con = GestorConexion.DevolverConexion())
            {
                con.Open();
                string query = "SELECT COUNT(*) FROM Boleto WHERE Origen = @Origen AND Destino = @Destino AND FechaPartidaIDA = @FechaPartidaIDA AND FechaLlegadaIDA = @FechaLlegadaIDA AND (@FechaPartidaVuelta IS NULL OR FechaPartidaVUELTA = @FechaPartidaVuelta) AND (@FechaLlegadaVuelta IS NULL OR FechaLlegadaVUELTA = @FechaLlegadaVuelta) AND NumeroAsiento = @NumeroAsiento AND ID != @IdBoleto";
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@Origen", boletoVerificarExistencia.Origen);
                    cmd.Parameters.AddWithValue("@Destino", boletoVerificarExistencia.Destino);
                    cmd.Parameters.AddWithValue("@FechaPartidaIDA", boletoVerificarExistencia.FechaPartida);
                    cmd.Parameters.AddWithValue("@FechaLlegadaIDA", boletoVerificarExistencia.FechaLlegada);

                    if (boletoVerificarExistencia is BoletoIDAVUELTA bole)
                    {
                        cmd.Parameters.AddWithValue("@FechaPartidaVuelta", bole.FechaPartidaVUELTA);
                        cmd.Parameters.AddWithValue("@FechaLlegadaVuelta", bole.FechaLlegadaVUELTA);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@FechaPartidaVuelta", DBNull.Value);
                        cmd.Parameters.AddWithValue("@FechaLlegadaVuelta", DBNull.Value);
                    }

                    cmd.Parameters.AddWithValue("@NumeroAsiento", boletoVerificarExistencia.NumeroAsiento);
                    cmd.Parameters.AddWithValue("@IdBoleto", boletoVerificarExistencia.IDBoleto);

                    int count = (int)cmd.ExecuteScalar();
                    return count > 0;
                }
            }
        }



        public void CobrarBoleto(Boleto BoletoCobrado)
        {
            using (SqlConnection cone = GestorConexion.DevolverConexion())
            {
                cone.Open();
                string query = "UPDATE Boleto SET IsVendido = 1 WHERE ID = @ID";
                using (SqlCommand comando = new SqlCommand(query, cone))
                {
                    comando.Parameters.AddWithValue("@ID", BoletoCobrado.IDBoleto);
                    comando.ExecuteNonQuery();
                }
            }
        }



        #endregion

        #region Busqueda Boleto

        public List<Boleto> ObtenerBoletosPorModalidad(string Modalidad)
        {
            using (SqlConnection cone = GestorConexion.DevolverConexion())
            {
                List<Boleto> boletos = new List<Boleto>();
                UsuarioDAL gestorUsuario = new UsuarioDAL();
                List<Usuario> Titulares = gestorUsuario.DevolverTodosLosUsuarios();
                cone.Open();
                string query = "";
                if (Modalidad == "IDA")
                {
                    query = "SELECT * FROM Boleto WHERE FechaPartidaVUELTA IS NULL OR FechaLlegadaVUELTA IS NULL";
                    using (SqlCommand comando = new SqlCommand(query, cone))
                    {
                        using (SqlDataReader reader = comando.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Boleto boletoIDA = new BoletoIDA(
                                    reader["ID"].ToString(),
                                    reader["Origen"].ToString(),
                                    reader["Destino"].ToString(),
                                    Convert.ToDateTime(reader["FechaPartidaIDA"]),
                                    Convert.ToDateTime(reader["FechaLlegadaIDA"]),
                                    Convert.ToBoolean(reader["IsVendido"]),
                                    Convert.ToSingle(reader["PesoEquipajePermitido"]),
                                    reader["ClaseBoleto"].ToString(),
                                    Convert.ToSingle(reader["Precio"]),
                                    Titulares.Find(x => x.DNI == reader["Titular"].ToString()),
                                    reader["NumeroAsiento"].ToString()
                                );
                                boletos.Add(boletoIDA);
                            }
                        }
                    }
                }

                if (Modalidad == "IDAVUELTA")
                {
                    query = "SELECT * FROM Boleto WHERE FechaPartidaVUELTA IS NOT NULL AND FechaLlegadaVUELTA IS NOT NULL";
                    using (SqlCommand comando = new SqlCommand(query, cone))
                    {
                        using (SqlDataReader reader = comando.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Boleto boletoIDA = new BoletoIDAVUELTA(
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
                                   Titulares.Find(x => x.DNI == reader["Titular"].ToString()),
                                   reader["NumeroAsiento"].ToString()
                                );
                                boletos.Add(boletoIDA);
                            }
                        }
                    }
                }

                return boletos;
            }
        }

        public Boleto ObtenerBoletoPorID(string ID)
        {
            using (SqlConnection cone = GestorConexion.DevolverConexion())
            {
                UsuarioDAL gestorUsuario = new UsuarioDAL();
                List<Usuario> Titulares = gestorUsuario.DevolverTodosLosUsuarios();
                cone.Open();
                string query = "SELECT * FROM Boleto WHERE ID = @ID";
                using (SqlCommand comando = new SqlCommand(query, cone))
                {
                    comando.Parameters.AddWithValue("@ID", ID);
                    using (SqlDataReader reader = comando.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            string dni = reader["Titular"].ToString();
                            if (reader["FechaPartidaVUELTA"] == DBNull.Value || reader["FechaLlegadaVUELTA"] == DBNull.Value)
                            {
                                return new BoletoIDA(
                                    reader["ID"].ToString(),
                                    reader["Origen"].ToString(),
                                    reader["Destino"].ToString(),
                                    Convert.ToDateTime(reader["FechaPartidaIDA"]),
                                    Convert.ToDateTime(reader["FechaLlegadaIDA"]),
                                    Convert.ToBoolean(reader["IsVendido"]),
                                    Convert.ToSingle(reader["PesoEquipajePermitido"]),
                                    reader["ClaseBoleto"].ToString(),
                                    Convert.ToSingle(reader["Precio"]),
                                    Titulares.Find(x => x.DNI == dni),
                                    reader["NumeroAsiento"].ToString()
                                );
                            }
                            else
                            {
                                return new BoletoIDAVUELTA(
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
                                    Titulares.Find(x => x.DNI == dni),
                                    reader["NumeroAsiento"].ToString()
                                );
                            }
                        }
                    }
                }
                return null;
            }
        }

        public List<Boleto> ObtenerBoletosPorPagarCliente(Usuario cliente)
        {
            using (SqlConnection cone = GestorConexion.DevolverConexion())
            {
                List<Boleto> boletos = new List<Boleto>();
                UsuarioDAL gestorUsuario = new UsuarioDAL();
                List<Usuario> Titulares = gestorUsuario.DevolverTodosLosUsuarios();
                cone.Open();
                string query = "SELECT * FROM Boleto WHERE Titular = @Titular AND IsVendido = 0";
                using (SqlCommand comando = new SqlCommand(query, cone))
                {
                    comando.Parameters.AddWithValue("@Titular", cliente.DNI);
                    using (SqlDataReader reader = comando.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            if (reader["FechaPartidaVUELTA"] == DBNull.Value || reader["FechaLlegadaVUELTA"] == DBNull.Value)
                            {
                                Boleto boletoPagar = new BoletoIDA(
                                   reader["ID"].ToString(),
                                   reader["Origen"].ToString(),
                                   reader["Destino"].ToString(),
                                   Convert.ToDateTime(reader["FechaPartidaIDA"]),
                                   Convert.ToDateTime(reader["FechaLlegadaIDA"]),
                                   Convert.ToBoolean(reader["IsVendido"]),
                                   Convert.ToSingle(reader["PesoEquipajePermitido"]),
                                   reader["ClaseBoleto"].ToString(),
                                   Convert.ToSingle(reader["Precio"]),
                                   Titulares.Find(x => x.DNI == cliente.DNI),
                                   reader["NumeroAsiento"].ToString()
                               );
                                boletos.Add(boletoPagar);
                            }
                            else
                            {
                                Boleto boletoPagar = new BoletoIDAVUELTA(
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
                                    Titulares.Find(x => x.DNI == cliente.DNI),
                                    reader["NumeroAsiento"].ToString()
                                );
                                boletos.Add(boletoPagar);
                            }
                        }
                    }
                }
                return boletos;
            }
        }

        public List<Boleto> ObtenerBoletosPorCliente(Usuario cliente)
        {
            using (SqlConnection cone = GestorConexion.DevolverConexion())
            {
                List<Boleto> boletos = new List<Boleto>();
                UsuarioDAL gestorUsuario = new UsuarioDAL();
                List<Usuario> Titulares = gestorUsuario.DevolverTodosLosUsuarios();
                cone.Open();
                string query = "SELECT * FROM Boleto WHERE Titular = @Titular";
                using (SqlCommand comando = new SqlCommand(query, cone))
                {
                    comando.Parameters.AddWithValue("@Titular", cliente.DNI);
                    using (SqlDataReader reader = comando.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            if (reader["FechaPartidaVUELTA"] == DBNull.Value || reader["FechaLlegadaVUELTA"] == DBNull.Value)
                            {
                                if (reader["BeneficioAplicado"] == DBNull.Value)
                                {

                                    Boleto boletoAgregar = new BoletoIDA(
                                        reader["ID"].ToString(),
                                        reader["Origen"].ToString(),
                                        reader["Destino"].ToString(),
                                        Convert.ToDateTime(reader["FechaPartidaIDA"]),
                                        Convert.ToDateTime(reader["FechaLlegadaIDA"]),
                                        Convert.ToBoolean(reader["IsVendido"]),
                                        Convert.ToSingle(reader["PesoEquipajePermitido"]),
                                        reader["ClaseBoleto"].ToString(),
                                        Convert.ToSingle(reader["Precio"]),
                                        cliente,
                                        reader["NumeroAsiento"].ToString()
                                    );
                                    boletos.Add(boletoAgregar);
                                }
                                else
                                {
                                    Boleto boletoAgregar = new BoletoIDA(
                                    reader["ID"].ToString(),
                                    reader["Origen"].ToString(),
                                    reader["Destino"].ToString(),
                                    Convert.ToDateTime(reader["FechaPartidaIDA"]),
                                    Convert.ToDateTime(reader["FechaLlegadaIDA"]),
                                    Convert.ToBoolean(reader["IsVendido"]),
                                    Convert.ToSingle(reader["PesoEquipajePermitido"]),
                                    reader["ClaseBoleto"].ToString(),
                                    Convert.ToSingle(reader["Precio"]),
                                    cliente,
                                    reader["NumeroAsiento"].ToString(),
                                    reader["BeneficioAplicado"].ToString()
                                );
                                    boletos.Add(boletoAgregar);
                                }
                            }
                            else
                            {
                                if (reader["BeneficioAplicado"] == DBNull.Value)
                                {
                                    Boleto boletoAgregar = new BoletoIDAVUELTA(
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
                                    cliente,
                                    reader["NumeroAsiento"].ToString()
                                );
                                    boletos.Add(boletoAgregar);
                                }
                                else
                                {
                                    Boleto boletoAgregar = new BoletoIDAVUELTA(
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
                                    cliente,
                                    reader["NumeroAsiento"].ToString(),
                                    reader["BeneficioAplicado"].ToString()
                                );
                                    boletos.Add(boletoAgregar);
                                }
                            }
                        }
                    }
                }
                return boletos;
            }
        }

        public List<Boleto> ObtenerTodosLosBoletos()
        {
            using (SqlConnection cone = GestorConexion.DevolverConexion())
            {
                List<Boleto> boletos = new List<Boleto>();
                UsuarioDAL gestorUsuario = new UsuarioDAL();
                List<Usuario> Titulares = gestorUsuario.DevolverTodosLosUsuarios();
                cone.Open();
                string query = "SELECT * FROM Boleto";
                using (SqlCommand comando = new SqlCommand(query, cone))
                {

                    using (SqlDataReader reader = comando.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            if (reader["FechaPartidaVUELTA"] == DBNull.Value || reader["FechaLlegadaVUELTA"] == DBNull.Value)
                            {
                                Boleto boletoPagar = new BoletoIDA(
                                   reader["ID"].ToString(),
                                   reader["Origen"].ToString(),
                                   reader["Destino"].ToString(),
                                   Convert.ToDateTime(reader["FechaPartidaIDA"]),
                                   Convert.ToDateTime(reader["FechaLlegadaIDA"]),
                                   Convert.ToBoolean(reader["IsVendido"]),
                                   Convert.ToSingle(reader["PesoEquipajePermitido"]),
                                   reader["ClaseBoleto"].ToString(),
                                   Convert.ToSingle(reader["Precio"]),
                                   Titulares.Find(x => x.DNI == reader["Titular"].ToString()),
                                   reader["NumeroAsiento"].ToString()
                               );
                                boletos.Add(boletoPagar);
                            }
                            else
                            {
                                Boleto boletoPagar = new BoletoIDAVUELTA(
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
                                    Titulares.Find(x => x.DNI == reader["Titular"].ToString()),
                                    reader["NumeroAsiento"].ToString()
                                );
                                boletos.Add(boletoPagar);
                            }
                        }
                    }
                }
                return boletos;
            }
        }



        public List<Boleto> ObtenerBoletosFiltrados(string origen = "", string destino = "", string claseBoleto = "", float? precioDesde = null, float? precioHasta = null, float? pesoPermitido = null, DateTime? fechaPartida = null, DateTime? fechaLlegada = null, DateTime? fechaPartidaVUELTA = null, DateTime? fechaLlegadaVUELTA = null)
        {
            List<Boleto> boletos = new List<Boleto>();
            UsuarioDAL gestorUsuario = new UsuarioDAL();
            List<Usuario> Titulares = gestorUsuario.DevolverTodosLosUsuarios();
            using (SqlConnection cone = GestorConexion.DevolverConexion())
            {
                cone.Open();


                string query = "SELECT * FROM Boleto WHERE FechaBoletoGenerado IS NULL";

                if (!string.IsNullOrEmpty(origen))
                    query += " AND Origen = @Origen";
                if (!string.IsNullOrEmpty(destino))
                    query += " AND Destino = @Destino";
                if (!string.IsNullOrEmpty(claseBoleto))
                    query += " AND ClaseBoleto = @ClaseBoleto";
                if (precioDesde.HasValue)
                    query += " AND Precio >= @PrecioDesde";
                if (precioHasta.HasValue)
                    query += " AND Precio <= @PrecioHasta";
                if (pesoPermitido.HasValue)
                    query += " AND PesoEquipajePermitido = @PesoPermitido";
                if (fechaPartida.HasValue)
                    query += " AND FechaPartidaIDA >= @FechaPartida";
                if (fechaLlegada.HasValue)
                    query += " AND FechaLlegadaIDA <= @FechaLlegada";
                if (fechaPartidaVUELTA.HasValue)
                    query += " AND FechaPartidaVUELTA >= @FechaPartidaVuelta";
                if (fechaLlegadaVUELTA.HasValue)
                    query += " AND FechaLlegadaVUELTA <= @FechaLlegadaVuelta";


                using (SqlCommand comando = new SqlCommand(query, cone))
                {
                    if (!string.IsNullOrEmpty(origen))
                        comando.Parameters.AddWithValue("@Origen", origen);
                    if (!string.IsNullOrEmpty(destino))
                        comando.Parameters.AddWithValue("@Destino", destino);
                    if (!string.IsNullOrEmpty(claseBoleto))
                        comando.Parameters.AddWithValue("@ClaseBoleto", claseBoleto);
                    if (precioDesde.HasValue)
                        comando.Parameters.AddWithValue("@PrecioDesde", precioDesde.Value);
                    if (precioHasta.HasValue)
                        comando.Parameters.AddWithValue("@PrecioHasta", precioHasta.Value);
                    if (pesoPermitido.HasValue)
                        comando.Parameters.AddWithValue("@PesoPermitido", pesoPermitido.Value);
                    if (fechaPartida.HasValue)
                        comando.Parameters.AddWithValue("@FechaPartida", fechaPartida.Value);
                    if (fechaLlegada.HasValue)
                        comando.Parameters.AddWithValue("@FechaLlegada", fechaLlegada.Value);
                    if (fechaPartidaVUELTA.HasValue)
                        comando.Parameters.AddWithValue("@FechaPartidaVuelta", fechaPartidaVUELTA.Value);
                    if (fechaLlegadaVUELTA.HasValue)
                        comando.Parameters.AddWithValue("@FechaLlegadaVuelta", fechaLlegadaVUELTA.Value);


                    using (SqlDataReader reader = comando.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            if (reader["FechaPartidaVUELTA"] == DBNull.Value || reader["FechaLlegadaVUELTA"] == DBNull.Value)
                            {
                                Boleto boletoPagar = new BoletoIDA(
                                   reader["ID"].ToString(),
                                   reader["Origen"].ToString(),
                                   reader["Destino"].ToString(),
                                   Convert.ToDateTime(reader["FechaPartidaIDA"]),
                                   Convert.ToDateTime(reader["FechaLlegadaIDA"]),
                                   Convert.ToBoolean(reader["IsVendido"]),
                                   Convert.ToSingle(reader["PesoEquipajePermitido"]),
                                   reader["ClaseBoleto"].ToString(),
                                   Convert.ToSingle(reader["Precio"]),
                                   Titulares.Find(x => x.DNI == reader["Titular"].ToString()),
                                   reader["NumeroAsiento"].ToString()
                               );
                                boletos.Add(boletoPagar);
                            }
                            else
                            {
                                Boleto boletoPagar = new BoletoIDAVUELTA(
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
                                    Titulares.Find(x => x.DNI == reader["Titular"].ToString()),
                                    reader["NumeroAsiento"].ToString()
                                );
                                boletos.Add(boletoPagar);
                            }
                        }
                    }
                }
            }
            return boletos;
        }

        public Boleto ObtenerBoletoConBeneficio(string ID)
        {
            using (SqlConnection cone = GestorConexion.DevolverConexion())
            {
                UsuarioDAL gestorUsuario = new UsuarioDAL();
                List<Usuario> Titulares = gestorUsuario.DevolverTodosLosUsuarios();
                cone.Open();
                string query = "SELECT * FROM Boleto WHERE ID = @ID";
                using (SqlCommand comando = new SqlCommand(query, cone))
                {
                    comando.Parameters.AddWithValue("@ID", ID);
                    using (SqlDataReader reader = comando.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            if (reader["FechaPartidaVUELTA"] == DBNull.Value || reader["FechaLlegadaVUELTA"] == DBNull.Value)
                            {
                                if (reader["BeneficioAplicado"] == DBNull.Value)
                                {

                                    return new BoletoIDA(
                                        reader["ID"].ToString(),
                                        reader["Origen"].ToString(),
                                        reader["Destino"].ToString(),
                                        Convert.ToDateTime(reader["FechaPartidaIDA"]),
                                        Convert.ToDateTime(reader["FechaLlegadaIDA"]),
                                        Convert.ToBoolean(reader["IsVendido"]),
                                        Convert.ToSingle(reader["PesoEquipajePermitido"]),
                                        reader["ClaseBoleto"].ToString(),
                                        Convert.ToSingle(reader["Precio"]),
                                        Titulares.Find(x => x.DNI == ID),
                                        reader["NumeroAsiento"].ToString()
                                    );
                                }
                                else
                                {
                                    return new BoletoIDA(
                                    reader["ID"].ToString(),
                                    reader["Origen"].ToString(),
                                    reader["Destino"].ToString(),
                                    Convert.ToDateTime(reader["FechaPartidaIDA"]),
                                    Convert.ToDateTime(reader["FechaLlegadaIDA"]),
                                    Convert.ToBoolean(reader["IsVendido"]),
                                    Convert.ToSingle(reader["PesoEquipajePermitido"]),
                                    reader["ClaseBoleto"].ToString(),
                                    Convert.ToSingle(reader["Precio"]),
                                    Titulares.Find(x => x.DNI == ID),
                                    reader["NumeroAsiento"].ToString(),
                                    reader["BeneficioAplicado"].ToString()
                                );
                                }
                            }
                            else
                            {
                                if (reader["BeneficioAplicado"] == DBNull.Value)
                                {
                                    return new BoletoIDAVUELTA(
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
                                    Titulares.Find(x => x.DNI == ID),
                                    reader["NumeroAsiento"].ToString()
                                );

                                }
                                else
                                {
                                    return new BoletoIDAVUELTA(
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
                                    Titulares.Find(x => x.DNI == ID),
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

        public List<string> ObtenerListaDVH()
        {
            List<string> listaDVH = new List<string>();
            using (SqlConnection cone = GestorConexion.DevolverConexion())
            {
                cone.Open();
                string query = "SELECT * FROM Boleto";
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

        public void ActualizarDVH(Boleto boleto, string dvh)
        {
            using (SqlConnection cone = GestorConexion.DevolverConexion())
            {
                cone.Open();
                using (SqlCommand comando = new SqlCommand("UPDATE Boleto SET DVH = @DVH WHERE ID = @ID", cone))
                {
                    comando.Parameters.AddWithValue("@DVH", dvh);
                    comando.Parameters.AddWithValue("@ID", boleto.IDBoleto);
                    comando.ExecuteNonQuery();
                }
            }
        }
        public string ObtenerDVH(Boleto boleto)
        {
            using (SqlConnection cone = GestorConexion.DevolverConexion())
            {
                cone.Open();
                string query = "SELECT DVH FROM Boleto WHERE ID = @ID";
                using (SqlCommand comando = new SqlCommand(query, cone))
                {
                    comando.Parameters.AddWithValue("@ID", boleto.IDBoleto);
                    return comando.ExecuteScalar()?.ToString();
                }
            }
        }

    }
}
