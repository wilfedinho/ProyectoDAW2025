using BE;
using DAL;
using SERVICIOS;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml.Serialization;

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

        /*public string SerializarCliente490WC(List<Cliente490WC> datosSerializar490WC)
        {
            XmlSerializer Serializador490WC = new XmlSerializer(typeof(List<Cliente490WC>));
            using (var memoria490WC = new MemoryStream())
            {
                using (var escritor490WC = new StreamWriter(memoria490WC, new UTF8Encoding(true)))
                {
                    Serializador490WC.Serialize(escritor490WC, datosSerializar490WC);
                    escritor490WC.Flush();
                    return Encoding.UTF8.GetString(memoria490WC.ToArray());
                }
            }
        }

        public List<Cliente490WC> DeserializarCliente490WC(string ruta490WC)
        {
            XmlSerializer serializador490WC = new XmlSerializer(typeof(List<Cliente490WC>), new XmlRootAttribute("ArrayOfCliente490WC"));
            using (FileStream FS490WC = new FileStream(ruta490WC, FileMode.Open, FileAccess.Read))
            {
                Bitacora490WC GestorBitacora490WC = new Bitacora490WC();
                GestorBitacora490WC.AltaEvento490WC("Gestión Cliente", "Deserializar Clientes", 1);


                var clientes = (List<Cliente490WC>)serializador490WC.Deserialize(FS490WC);

                return clientes;
            }
        }


        public void GuardarXML490WC(string datosXML490WC, string patron490WC)
        {
            using (StreamWriter escritor490WC = new StreamWriter(patron490WC))
            {
                escritor490WC.Write(datosXML490WC);
            }
            Bitacora490WC GestorBitacora490WC = new Bitacora490WC();
            GestorBitacora490WC.AltaEvento490WC("Gestión Cliente", "Serializar Clientes", 2);
        }*/

        public bool VerificarFormatoDNI(string DNI490WC)
        {
            Regex rgx490WC = new Regex("^[0-9]{2}[.]{1}[0-9]{3}[.]{1}[0-9]{3}$");

            if (rgx490WC.IsMatch(DNI490WC))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool VerificarFormatoFechaTarjeta(string FechaTarjeta490WC)
        {
            Regex rgx490WC = new Regex(@"^(0[1-9]|1[0-2])\/\d{2}$");

            return rgx490WC.IsMatch(FechaTarjeta490WC);
        }

        public bool VerificarFormatoFechaVencimientoTarjeta(string FechaTarjeta490WC)
        {

            Regex rgx490WC = new Regex(@"^(0[1-9]|1[0-2])\/\d{2}$");
            if (!rgx490WC.IsMatch(FechaTarjeta490WC))
                return false;
            string[] partes = FechaTarjeta490WC.Split('/');
            int mes = int.Parse(partes[0]);
            int anio = int.Parse(partes[1]);
            int anioActual = DateTime.Now.Year % 100;
            int mesActual = DateTime.Now.Month;


            if (anio > anioActual || (anio == anioActual && mes >= mesActual))
                return true;

            return false;
        }

        public bool VerificarRangoFechasTarjeta(string FechaEmision490WC, string FechaVencimiento490WC)
        {
            try
            {
                string[] partesEmision490WC = FechaEmision490WC.Split('/');
                string[] partesVencimiento490WC = FechaVencimiento490WC.Split('/');

                int mesEmision490WC = int.Parse(partesEmision490WC[0]);
                int anioEmision490WC = int.Parse(partesEmision490WC[1]);

                int mesVencimiento490WC = int.Parse(partesVencimiento490WC[0]);
                int anioVencimiento490WC = int.Parse(partesVencimiento490WC[1]);


                if (anioEmision490WC > anioVencimiento490WC)
                    return false;

                if (anioEmision490WC == anioVencimiento490WC && mesEmision490WC > mesVencimiento490WC)
                    return false;

                return true;
            }
            catch
            {
                return false;
            }
        }


        public bool VerificarFormatoNumeroTarjeta(string NumeroTarjeta490WC)
        {
            Regex rgx490WC = new Regex("^[0-9]{16}$");
            if (rgx490WC.IsMatch(NumeroTarjeta490WC))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool VerificarFormatoCVVTarjeta(string CVVTarjeta490WC)
        {
            Regex rgx490WC = new Regex("^[0-9]{3}$");
            if (rgx490WC.IsMatch(CVVTarjeta490WC))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool VerificarCelular(string Celular490WC)
        {
            Regex rgx490WC = new Regex("^[0-9]{10}$");
            if (rgx490WC.IsMatch(Celular490WC))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        

        public void ModificarEstrellasCliente(string DNI490WC, int EstrellasReducir490WC)
        {
            UsuarioDAL clienteDAL490WC = new UsuarioDAL();
            clienteDAL490WC.ModificarEstrellasCliente(DNI490WC, EstrellasReducir490WC);
            
        }



        public Usuario BuscarClientePorDNI(string DNI490WC)
        {
            UsuarioDAL clienteDAL490WC = new UsuarioDAL();
            return clienteDAL490WC.BuscarClientePorDNI(DNI490WC);
        }

        public List<Usuario> ObtenerTodosLosCliente()
        {
            UsuarioDAL clienteDAL490WC = new UsuarioDAL();
            return clienteDAL490WC.ObtenerTodosLosCliente();
        }

    }
}
