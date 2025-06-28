using BE;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace DAL
{
    public class UsuarioDAL
    {
        #region Operaciones Usuario 490WC
        public void Alta(Usuario UsuarioAlta)
        {
            using (SqlConnection cone = GestorConexion490WC.DevolverConexion())
            {
                cone.Open();
                string query = "INSERT INTO Usuario490WC (Username,Nombre,Apellido,DNI,Contraseña,Email,Rol)" +
                                    " VALUES (@Username,@Nombre,@Apellido,@DNI,@Contraseña,@Email,@Rol)";
                using (SqlCommand comando = new SqlCommand(query, cone))
                {
                    comando.Parameters.AddWithValue("@Username", UsuarioAlta.Username);
                    comando.Parameters.AddWithValue("@Nombre", UsuarioAlta.Nombre);
                    comando.Parameters.AddWithValue("@Apellido", UsuarioAlta.Apellido);
                    comando.Parameters.AddWithValue("@DNI", UsuarioAlta.DNI);
                    comando.Parameters.AddWithValue("@Contraseña", UsuarioAlta.Contraseña);
                    comando.Parameters.AddWithValue("@Email", UsuarioAlta.Email);
                    comando.Parameters.AddWithValue("@Rol", UsuarioAlta.Rol);
                

                    comando.ExecuteNonQuery();
                }
            }
        }
        public void Baja(string username)
        {
            using (SqlConnection cone = GestorConexion490WC.DevolverConexion())
            {
                cone.Open();
                string query490WC = "DELETE FROM Usuario WHERE Username = @Username";
                using (SqlCommand comando490WC = new SqlCommand(query490WC, cone))
                {
                    comando490WC.Parameters.AddWithValue("@Username", username);
                    comando490WC.ExecuteNonQuery();
                }
            }
        }
        public void Modificar(Usuario UsuarioModificado)
        {
            using (SqlConnection cone = GestorConexion490WC.DevolverConexion())
            {
                cone.Open();
                string query490WC = "UPDATE Usuario SET Nombre = @Nombre, Apellido = @Apellido, DNI = @DNI, Contraseña = @Contraseña, Email = @Email, Rol = @Rol";

                using (SqlCommand comando490WC = new SqlCommand(query490WC, cone))
                {
                    comando490WC.Parameters.AddWithValue("@Username", UsuarioModificado.Username);
                    comando490WC.Parameters.AddWithValue("@Nombre", UsuarioModificado.Nombre);
                    comando490WC.Parameters.AddWithValue("@Apellido", UsuarioModificado.Apellido);
                    comando490WC.Parameters.AddWithValue("@DNI", UsuarioModificado.DNI);
                    comando490WC.Parameters.AddWithValue("@Contraseña", UsuarioModificado.Contraseña);
                    comando490WC.Parameters.AddWithValue("@Email", UsuarioModificado.Email);
                    comando490WC.Parameters.AddWithValue("@Rol", UsuarioModificado.Rol);
                    comando490WC.ExecuteNonQuery();
                }
            }
        }
        
        
        
        
        #endregion

        #region Busquedas De Usuarios 490WC
        public List<Usuario> DevolverTodosLosUsuarios()
        {
            List<Usuario> ListaUsuario = new List<Usuario>();
            using (SqlConnection cone = GestorConexion490WC.DevolverConexion())
            {
                using (SqlCommand comando = new SqlCommand("SELECT * FROM Usuario", cone))
                {
                    cone.Open();
                    using (SqlDataReader lector = comando.ExecuteReader())
                    {

                        while (lector.Read())
                        {
                            Usuario usuarioLectura = new Usuario(
                                                                             lector["Username490WC"].ToString(),
                                                                             lector["Nombre490WC"].ToString(),
                                                                             lector["Apellido490WC"].ToString(),
                                                                             lector["DNI490WC"].ToString(),
                                                                             lector["Contraseña490WC"].ToString(),
                                                                             lector["Email490WC"].ToString(),
                                                                             lector["Rol490WC"].ToString()
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
            using (SqlConnection cone = GestorConexion490WC.DevolverConexion())
            {
                using (SqlCommand comando = new SqlCommand(query, cone))
                {
                    cone.Open();
                    comando.Parameters.AddWithValue(parametro, valorBusqueda);
                    using (SqlDataReader lector490WC = comando.ExecuteReader())
                    {
                        if (lector490WC.Read())
                        {
                            Usuario usuarioLectura = new Usuario(
                                                                                lector490WC["Username490WC"].ToString(),
                                                                                lector490WC["Nombre490WC"].ToString(),
                                                                                lector490WC["Apellido490WC"].ToString(),
                                                                                lector490WC["DNI490WC"].ToString(),
                                                                                lector490WC["Contraseña490WC"].ToString(),
                                                                                lector490WC["Email490WC"].ToString(),
                                                                                lector490WC["Rol490WC"].ToString()
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
            return BuscarUsuario("SELECT * FROM Usuario490WC WHERE Email = @Email", "@Email", Email);
        }
        #endregion
    }
}
