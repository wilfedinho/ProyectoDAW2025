using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SERVICIOS
{
    public class EntidadPermisoCompuesto : EntidadPermiso
    {
        public EntidadPermisoCompuesto(string pNombre) : base(pNombre) { }

        public List<EntidadPermiso> listaPermisos = new List<EntidadPermiso>();

        public List<EntidadPermiso> DevolverListaPermisos()
        {
            return listaPermisos;
        }

        public override bool isComposite()
        {
            return true;
        }
    }
}
