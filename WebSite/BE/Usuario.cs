using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class Usuario
    {
        public string Username { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string DNI { get; set; }
        public string Contraseña { get; set; }
        public string Email { get; set; }
        public string Rol { get; set; }
        public int EstrellasCliente { get; set; }
        public List<Beneficio> BeneficiosCliente { get; set; }


        public Usuario(string nUsername, string nNombre, string nApellido, string nDNI, string nContraseña, string nEmail, string rOL, List<Beneficio> beneficiosCliente = null, int estrellasCliente = 0)
        {
            Username = nUsername;
            Nombre = nNombre;
            Apellido = nApellido;
            DNI = nDNI;
            Contraseña = nContraseña;
            Email = nEmail;
            Rol = rOL;
            EstrellasCliente = estrellasCliente;
            if (beneficiosCliente != null)
            {
                BeneficiosCliente = beneficiosCliente;
            }
            else
            {
                BeneficiosCliente = new List<Beneficio>();
            }
            
        }
    }
}
