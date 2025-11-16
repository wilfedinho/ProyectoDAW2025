using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SERVICIOS
{
    public abstract class EntidadPermiso
    {
        private string Nombre;

        public EntidadPermiso(string nombre)
        {
            Nombre = nombre;
        }

        public string DevolverNombrePermiso()
        {
            return Nombre;
        }

        public virtual bool isComposite()
        {
            return false;
        }
    }
}
