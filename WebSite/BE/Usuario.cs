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
        public int EstrellasCliente490WC { get; set; }
        public List<Beneficio490WC> BeneficiosCliente490WC { get; set; }

        public Usuario(string nUsername, string nNombre, string nApellido, string nDNI, string nContraseña, string nEmail, string rOL, List<Beneficio490WC> beneficiosCliente490WC = null, int estrellasCliente490WC = 0)
        {
            Username = nUsername;
            Nombre = nNombre;
            Apellido = nApellido;
            DNI = nDNI;
            Contraseña = nContraseña;
            Email = nEmail;
            Rol = rOL;
            EstrellasCliente490WC = estrellasCliente490WC;
            if (beneficiosCliente490WC != null)
            {
                BeneficiosCliente490WC = beneficiosCliente490WC;
            }
            else
            {
                BeneficiosCliente490WC = new List<Beneficio490WC>();
            }
            
        }
    }
}
