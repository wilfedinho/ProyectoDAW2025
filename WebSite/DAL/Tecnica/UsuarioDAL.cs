using BE;
using DAL.Negocio;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Net;

namespace DAL
{
    public class UsuarioDAL
    {
        #region Operaciones Usuario 
        public bool VerificarCredenciales(string username, string clave)
        {
            using (SqlConnection cone = GestorConexion.DevolverConexion())
            {
                cone.Open();
                string query = "SELECT COUNT(*) FROM Usuario WHERE Username = @Username AND Contraseña = @Contraseña";

                using (SqlCommand comando = new SqlCommand(query, cone))
                {
                    comando.Parameters.AddWithValue("@Username", username);
                    comando.Parameters.AddWithValue("@Contraseña", clave);
                    int cantidad = (int)comando.ExecuteScalar();
                    return cantidad > 0;
                }
            }
        }
        public void Alta(Usuario UsuarioAlta)
        {
            using (SqlConnection cone = GestorConexion.DevolverConexion())
            {
                cone.Open();
                string query = "INSERT INTO Usuario (Username,Nombre,Apellido,DNI,Contraseña,Email,Rol,EstrellasCliente)" +
                                    " VALUES (@Username,@Nombre,@Apellido,@DNI,@Contraseña,@Email,@Rol,@EstrellasCliente)";
                using (SqlCommand comando = new SqlCommand(query, cone))
                {
                    comando.Parameters.AddWithValue("@Username", UsuarioAlta.Username);
                    comando.Parameters.AddWithValue("@Nombre", UsuarioAlta.Nombre);
                    comando.Parameters.AddWithValue("@Apellido", UsuarioAlta.Apellido);
                    comando.Parameters.AddWithValue("@DNI", UsuarioAlta.DNI);
                    comando.Parameters.AddWithValue("@Contraseña", UsuarioAlta.Contraseña);
                    comando.Parameters.AddWithValue("@Email", UsuarioAlta.Email);
                    comando.Parameters.AddWithValue("@Rol", UsuarioAlta.Rol);
                    comando.Parameters.AddWithValue("@EstrellasCliente", UsuarioAlta.EstrellasCliente);

                    comando.ExecuteNonQuery();
                }
            }
        }
        public void Baja(string username)
        {
            using (SqlConnection cone = GestorConexion.DevolverConexion())
            {
                cone.Open();
                string query = "DELETE FROM Usuario WHERE Username = @Username";
                using (SqlCommand comando = new SqlCommand(query, cone))
                {
                    comando.Parameters.AddWithValue("@Username", username);
                    comando.ExecuteNonQuery();
                }
            }
        }
        public void Modificar(Usuario UsuarioModificado)
        {
            using (SqlConnection cone = GestorConexion.DevolverConexion())
            {
                cone.Open();
                string query = "UPDATE Usuario SET Nombre = @Nombre, Apellido = @Apellido, DNI = @DNI, Contraseña = @Contraseña, Email = @Email, Rol = @Rol, EstrellasCliente = @EstrellasCliente WHERE Username = @Username";

                using (SqlCommand comando = new SqlCommand(query, cone))
                {
                    comando.Parameters.AddWithValue("@Username", UsuarioModificado.Username);
                    comando.Parameters.AddWithValue("@Nombre", UsuarioModificado.Nombre);
                    comando.Parameters.AddWithValue("@Apellido", UsuarioModificado.Apellido);
                    comando.Parameters.AddWithValue("@DNI", UsuarioModificado.DNI);
                    comando.Parameters.AddWithValue("@Contraseña", UsuarioModificado.Contraseña);
                    comando.Parameters.AddWithValue("@Email", UsuarioModificado.Email);
                    comando.Parameters.AddWithValue("@Rol", UsuarioModificado.Rol);
                    comando.Parameters.AddWithValue("@EstrellasCliente", UsuarioModificado.EstrellasCliente);
                    comando.ExecuteNonQuery();
                }
            }
        }




        #endregion

        #region Busquedas De Usuarios 
        public List<Usuario> DevolverTodosLosUsuarios()
        {
            List<Usuario> ListaUsuario = new List<Usuario>();
            using (SqlConnection cone = GestorConexion.DevolverConexion())
            {
                using (SqlCommand comando = new SqlCommand("SELECT * FROM Usuario", cone))
                {
                    cone.Open();
                    using (SqlDataReader lector = comando.ExecuteReader())
                    {
                        while (lector.Read())
                        {
                            string dni = lector["DNI"].ToString();
                            BeneficioDAL gestorBeneficio = new BeneficioDAL();
                            List<Beneficio> beneficios = gestorBeneficio.ObtenerBeneficiosPorCliente(dni);
                            Usuario usuarioLectura = new Usuario(
                                lector["Username"].ToString(),
                                lector["Nombre"].ToString(),
                                lector["Apellido"].ToString(),
                                lector["DNI"].ToString(),
                                lector["Contraseña"].ToString(),
                                lector["Email"].ToString(),
                                lector["Rol"].ToString(),
                                beneficios,
                                int.Parse(lector["EstrellasCliente"].ToString())
                            );
                            ListaUsuario.Add(usuarioLectura);
                        }
                    }
                }
            }
            return ListaUsuario;
        }
        private Usuario BuscarUsuario(string query, string parametro, string valorBusqueda)
        {
            using (SqlConnection cone = GestorConexion.DevolverConexion())
            {
                using (SqlCommand comando = new SqlCommand(query, cone))
                {
                    cone.Open();
                    comando.Parameters.AddWithValue(parametro, valorBusqueda);
                    using (SqlDataReader lector = comando.ExecuteReader())
                    {
                        if (lector.Read())
                        {
                            string dni = lector["DNI"].ToString();
                            BeneficioDAL gestorBeneficio = new BeneficioDAL();
                            List<Beneficio> beneficios = gestorBeneficio.ObtenerBeneficiosPorCliente(dni);
                            Usuario usuarioLectura = new Usuario(
                                lector["Username"].ToString(),
                                lector["Nombre"].ToString(),
                                lector["Apellido"].ToString(),
                                lector["DNI"].ToString(),
                                lector["Contraseña"].ToString(),
                                lector["Email"].ToString(),
                                lector["Rol"].ToString(),
                                beneficios,
                                int.Parse(lector["EstrellasCliente"].ToString())
                            );
                            return usuarioLectura;
                        }
                    }
                }
            }
            return null;
        }
        public Usuario BuscarUsuarioPorUsername(string Username)
        {
            return BuscarUsuario("SELECT * FROM Usuario WHERE Username = @Username", "@Username", Username);
        }
        public Usuario BuscarUsuarioPorDNI(string DNI)
        {
            return BuscarUsuario("SELECT * FROM Usuario WHERE DNI = @DNI", "@DNI", DNI);
        }

        public Usuario BuscarUsuarioPorEmail(string Email)
        {
            return BuscarUsuario("SELECT * FROM Usuario WHERE Email = @Email", "@Email", Email);
        }
        #endregion
    
    
       public List<string> ObtenerListaDVH()
       {
            List<string> listaDVH = new List<string>();
            using (SqlConnection cone = GestorConexion.DevolverConexion())
            {
                cone.Open();
                string query = "SELECT * FROM Usuario";
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

        public void ActualizarDVH(Usuario usuario, string dvh)
        {
            using (SqlConnection cone = GestorConexion.DevolverConexion())
            {
                cone.Open();
                using (SqlCommand comando = new SqlCommand("UPDATE Usuario SET DVH = @DVH WHERE Username = @Username", cone))
                {
                    comando.Parameters.AddWithValue("@DVH", dvh);
                    comando.Parameters.AddWithValue("@Username", usuario.Username);
                    comando.ExecuteNonQuery();
                }
            }
        }
        public string ObtenerDVH(Usuario usuario)
        {
            using (SqlConnection cone = GestorConexion.DevolverConexion())
            {
                cone.Open();
                string query = "SELECT DVH FROM Usuario WHERE Username = @Username";
                using (SqlCommand comando = new SqlCommand(query, cone))
                {
                    comando.Parameters.AddWithValue("@Username", usuario.Username);
                    return comando.ExecuteScalar()?.ToString();
                }
            }
        }

        public void ModificarEstrellasCliente(string DNI490WC, int EstrellasReducir490WC)
        {
            BeneficioDAL gestorBeneficioDAL490WC = new BeneficioDAL();
            gestorBeneficioDAL490WC.ReducirSaldoEstrellas(DNI490WC, EstrellasReducir490WC);
        }

        public Usuario BuscarClientePorDNI(string DNI490WC)
        {
            using (SqlConnection cone490WC = GestorConexion.DevolverConexion())
            {
                cone490WC.Open();

                string query490WC = "SELECT * FROM Usuario WHERE DNI = @DNI";

                using (SqlCommand comando490WC = new SqlCommand(query490WC, cone490WC))
                {
                    comando490WC.Parameters.AddWithValue("@DNI", DNI490WC);

                    using (SqlDataReader reader = comando490WC.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            BeneficioDAL gestorBeneficio490WC = new BeneficioDAL();
                            List<Beneficio> beneficiosCliente = gestorBeneficio490WC.ObtenerBeneficiosPorCliente(DNI490WC);

                            return new Usuario(
                                reader["Username"].ToString(),
                                reader["Nombre"].ToString(),
                                reader["Apellido"].ToString(),
                                reader["DNI"].ToString(),
                                reader["Contraseña"].ToString(),
                                reader["Email"].ToString(),
                                reader["Rol"].ToString(),
                                beneficiosCliente,
                                int.Parse(reader["EstrellasCliente"].ToString())
                            );
                        }
                    }
                }
            }

            return null;
        }

        public List<Usuario> ObtenerTodosLosCliente()
        {
            List<Usuario> listaClientes490WC = new List<Usuario>();

            using (SqlConnection cone490WC = GestorConexion.DevolverConexion())
            {
                cone490WC.Open();
                string query490WC = "SELECT * FROM Usuario";

                using (SqlCommand comando490WC = new SqlCommand(query490WC, cone490WC))
                {
                    BeneficioDAL gestorBeneficio490WC = new BeneficioDAL();

                    using (SqlDataReader reader = comando490WC.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string dni = reader["DNI"].ToString();
                           
                            List<Beneficio> beneficios = gestorBeneficio490WC.ObtenerBeneficiosPorCliente(dni);

                            listaClientes490WC.Add(new Usuario(
                                
                                reader["Username"].ToString(),
                                reader["Nombre"].ToString(),
                                reader["Apellido"].ToString(),
                                reader["DNI"].ToString(),
                                reader["Contraseña"].ToString(),
                                reader["Email"].ToString(),
                                reader["Rol"].ToString(),
                                beneficios,
                                int.Parse(reader["EstrellasCliente"].ToString()
                            )));
                        }
                    }
                }
            }

            return listaClientes490WC;
        }

    }



}
