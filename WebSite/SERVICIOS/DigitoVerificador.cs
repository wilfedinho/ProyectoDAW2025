using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;
using DAL;

namespace SERVICIOS
{
    public class DigitoVerificador
    {


        public string CalcularDVH(object obj)
        {
            var sb = new StringBuilder();
            Encryptador cifrador = new Encryptador();
            if(obj is Usuario usu)
            {
                sb.Append(usu.Username);
                sb.Append(usu.Nombre);
                sb.Append(usu.Apellido);
                sb.Append(usu.DNI);
                sb.Append(usu.Contraseña);
                sb.Append(usu.Email);
                sb.Append(usu.Rol);
            }
            return cifrador.EncryptadorIrreversible(sb.ToString());
        }

        public string CalcularDVV(string nomTabla)
        {
            var sb = new StringBuilder();
            UsuarioDAL usuarioDAL = new UsuarioDAL();
            Encryptador cifrador = new Encryptador();
            if(nomTabla == "Usuario")
            {
                foreach (string DVH in usuarioDAL.ObtenerListaDVH())
                {
                    sb.Append(DVH);
                }
            }
            return cifrador.EncryptadorIrreversible(sb.ToString());
        }

        public void ActualizarDVH(Object obj, string nomTabla)
        {
            if(obj != null || !string.IsNullOrEmpty(nomTabla))
            {
                string dvh = CalcularDVH(obj);
                UsuarioDAL usuarioDAL = new UsuarioDAL();
                if(nomTabla == "Usuario" && obj is Usuario usuario)
                {
                    usuarioDAL.ActualizarDVH(usuario, dvh);
                    ActualizarDVV(nomTabla);
                }
            }
        }

        private void ActualizarDVV(string nomTabla)
        {
            string dvv = CalcularDVV(nomTabla);
            DigitoVerificadorDAL digitoVerificadorDAL = new DigitoVerificadorDAL();

            if (nomTabla.Equals("Usuario", StringComparison.OrdinalIgnoreCase))
            {
                digitoVerificadorDAL.ActualizarDVV(nomTabla ,dvv);
            }
        }

        List<string> tablas = new List<string>()
        {
            "Usuario",
            "Beneficio",
            "Boleto",
            "Usuario_Beneficio"
        };


        public bool VerificarIntegridadDVV(string nomTabla)
        {
            DigitoVerificadorDAL digitoVerificadorDAL = new DigitoVerificadorDAL();
            string dvvMemoria = CalcularDVV(nomTabla);
            string dvvBD = digitoVerificadorDAL.ObtenerDVV(nomTabla);
            return dvvMemoria == dvvBD;
        }

        public bool VerificarIntegridadDVH(object obj)
        {
            if(obj is Usuario usu)
            {
                UsuarioDAL usuarioDAL = new UsuarioDAL();
                string dvhMemoria = CalcularDVH(usu);
                string dvhBD = usuarioDAL.ObtenerDVH(usu);
                return dvhMemoria == dvhBD;
            }
            return false;
        }


        public string VerificarIntegridadTodasLasTablas()
        {
            bool esValido = true;
            string mensaje = string.Empty;
            DigitoVerificador dvServicio = new DigitoVerificador();
            foreach (var tabla in tablas)
            {
                if(tabla == "Usuario")
                {
                    UsuarioDAL usuarioDAL = new UsuarioDAL();
                    foreach (var usuario in usuarioDAL.DevolverTodosLosUsuarios())
                    {
                        if (!dvServicio.VerificarIntegridadDVH(usuario))
                        {
                            mensaje += $"El DVH del usuario {usuario.Username} es inconsistente.\n";
                            esValido = false;
                        }
                    }
                }
                if (!dvServicio.VerificarIntegridadDVV(tabla))
                {
                    mensaje += $"La tabla {tabla} ha sido alterada.\n";
                    esValido = false;
                }
            }
            if (esValido)
            {
                return "Los datos son consistentes y están íntegros.";
            }
            else
            {
                return mensaje;
            }
        }

    }
}
