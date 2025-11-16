using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using BE;
using DAL;
using SERVICIOS;

namespace BLL.Tecnica
{
    public class UsuarioBLL
    {
        #region Operaciones Usuario
        public void Alta(Usuario UsuarioAlta)
        {
            UsuarioDAL gestorUsuario = new UsuarioDAL();
            gestorUsuario.Alta(UsuarioAlta);
            DigitoVerificador digitoVerificador = new DigitoVerificador();
            digitoVerificador.ActualizarDVH(UsuarioAlta, "Usuario");

        }
        public void Baja(string username)
        {
            UsuarioDAL gestorUsuario = new UsuarioDAL();
            gestorUsuario.Baja(username);
            DigitoVerificador digitoVerificador = new DigitoVerificador();
            digitoVerificador.ActualizarDVV("Usuario");
        }
        public void Modificar(Usuario UsuarioModificado)
        {
            UsuarioDAL gestorUsuario = new UsuarioDAL();
            gestorUsuario.Modificar(UsuarioModificado);
            DigitoVerificador digitoVerificador = new DigitoVerificador();
            digitoVerificador.ActualizarDVH(UsuarioModificado, "Usuario");
        }

        public bool VerificarCredenciales(string username, string clave)
        {
            UsuarioDAL gestorUsuario = new UsuarioDAL();
            Encryptador cifrador = new Encryptador();
            clave = cifrador.EncryptadorIrreversible(clave);
            return gestorUsuario.VerificarCredenciales(username, clave);
        }

        #endregion

        public void FormateoContraseña(Usuario usuario)
        {
            string contraseñaFormateada = usuario.DNI + usuario.Apellido;
            Encryptador cifrador = new Encryptador();
            usuario.Contraseña = cifrador.EncryptadorIrreversible(contraseñaFormateada);
            Modificar(usuario);
        }

        public bool RolIsInUso(string pNombre)
        {
            foreach (Usuario usuario in DevolverTodosLosUsuarios())
            {
                if (usuario.Rol == pNombre) { return true; }
            }
            return false;
        }

        #region Busquedas De Usuarios 
        public List<Usuario> DevolverTodosLosUsuarios()
        {
            UsuarioDAL gestorUsuario = new UsuarioDAL();
            return gestorUsuario.DevolverTodosLosUsuarios();
        }

        public Usuario BuscarUsuarioPorUsername(string Username)
        {
            UsuarioDAL gestorUsuario = new UsuarioDAL();
            return gestorUsuario.BuscarUsuarioPorUsername(Username);
        }
        public Usuario BuscarUsuarioPorDNI(string DNI)
        {
            UsuarioDAL gestorUsuario = new UsuarioDAL();
            return gestorUsuario.BuscarUsuarioPorDNI(DNI);
        }

        public Usuario BuscarUsuarioPorEmail(string Email)
        {
            UsuarioDAL gestorUsuario = new UsuarioDAL();
            return gestorUsuario.BuscarUsuarioPorEmail(Email);
        }
        #endregion

        #region Verificaciones De Usuarios

        public bool VerificarDNI(string DNI)
        {
            Regex rgx490WC = new Regex("^[0-9]{2}[.]{1}[0-9]{3}[.]{1}[0-9]{3}$");

            if (rgx490WC.IsMatch(DNI))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool VerificarEmail(string email)
        {

            Regex rgx490WC = new Regex(@"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+.[a-zA-Z]{2,}$");
            if (rgx490WC.IsMatch(email))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool VerificarDNIDuplicado(string DNI)
        {
            Usuario usuario = BuscarUsuarioPorDNI(DNI);
            if (usuario != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool VerificarDNIDuplicadoModificar(string DNIviejo, string DNInuevo)
        {
            Usuario usuario = BuscarUsuarioPorDNI(DNInuevo);
            if (usuario != null && DNIviejo != DNInuevo)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool VerificarEmailDuplicado(string Email)
        {
            Usuario usuario = BuscarUsuarioPorEmail(Email);

            if (usuario != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool VerificarEmailDuplicadoModificar(string emailAntiguo, string emailNuevo)
        {
            Usuario usuario = BuscarUsuarioPorEmail(emailNuevo);
            if (usuario != null && emailAntiguo != emailNuevo)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool VerificarUsernameDuplicado(string username)
        {

            Usuario usuario = BuscarUsuarioPorUsername(username);
            if (usuario != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        public void VerificarCambioClave490WC(Usuario usuarioCambiarClave)
        {
            
            Encryptador cifrador = new Encryptador();
            usuarioCambiarClave.Contraseña = cifrador.EncryptadorIrreversible(usuarioCambiarClave.Contraseña);
            Modificar(usuarioCambiarClave);

        }

        #endregion
    }
}
