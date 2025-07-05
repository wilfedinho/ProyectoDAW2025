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
            UsuarioAlta.Contraseña = new Encryptador().EncryptadorIrreversible(UsuarioAlta.Contraseña);
            gestorUsuario.Alta(UsuarioAlta);
        }
        public void Baja(string username)
        {
            UsuarioDAL gestorUsuario = new UsuarioDAL();
            gestorUsuario.Baja(username);
        }
        public void Modificar(Usuario UsuarioModificado)
        {
            UsuarioDAL gestorUsuario = new UsuarioDAL();
            gestorUsuario.Modificar(UsuarioModificado);
        }
        
        public bool VerificarCredenciales(string username, string clave)
        {
            UsuarioDAL gestorUsuario = new UsuarioDAL();
            Encryptador cifrador = new Encryptador();
            clave = cifrador.EncryptadorIrreversible(clave);
            return gestorUsuario.VerificarCredenciales (username, clave);
        }

        #endregion

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
            Usuario usuario = BuscarUsuarioPorEmail(emailAntiguo);
            if (usuario != null && emailAntiguo != emailNuevo)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool VerificarUsernameDuplicado490WC(string username)
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


        /*public string VerificarCambioClave490WC(string ClaveNueva490WC, string ClaveConfirmacion490WC, string ClaveActual490WC)
        {
            if (!string.IsNullOrEmpty(ClaveNueva490WC) && !string.IsNullOrEmpty(ClaveConfirmacion490WC))
            {


                if (Cifrador490WC.GestorCifrador490WC.EncriptarIrreversible490WC(ClaveActual490WC) == SesionManager490WC.GestorSesion490WC.Usuario490WC.Contraseña490WC)
                {
                    if (Cifrador490WC.GestorCifrador490WC.EncriptarIrreversible490WC(ClaveNueva490WC) == Cifrador490WC.GestorCifrador490WC.EncriptarIrreversible490WC(ClaveConfirmacion490WC))
                    {

                        if (Cifrador490WC.GestorCifrador490WC.EncriptarIrreversible490WC(ClaveNueva490WC) != SesionManager490WC.GestorSesion490WC.Usuario490WC.Contraseña490WC)
                        {

                            if (Cifrador490WC.GestorCifrador490WC.EncriptarIrreversible490WC(ClaveConfirmacion490WC) != SesionManager490WC.GestorSesion490WC.Usuario490WC.Contraseña490WC)
                            {
                                SesionManager490WC.GestorSesion490WC.Usuario490WC.Contraseña490WC = Cifrador490WC.GestorCifrador490WC.EncriptarIrreversible490WC(ClaveNueva490WC);
                                Modificar490WC(SesionManager490WC.GestorSesion490WC.Usuario490WC);
                                return "Ninguno";
                            }
                            else
                            {
                                return "ClaveConfirmacionIgualActual";
                            }
                        }
                        else
                        {
                            return "ClaveNuevaIgualActual";
                        }
                    }
                    else
                    {
                        return "ClaveNuevaDistintaClaveConfirmacion";
                    }
                }
                else
                {
                    return "ClaveActualDistintaOriginal";
                }
            }
            else
            {
                return "Campos Vacios";
            }
        }*/

        #endregion
    }
}
