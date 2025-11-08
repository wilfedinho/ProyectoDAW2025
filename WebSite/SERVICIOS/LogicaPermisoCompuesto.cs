using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SERVICIOS
{
    public class LogicaPermisoCompuesto
    {
        DatosPermiso dp = new DatosPermiso();
        public bool VerificarPermisoIncluido(EntidadPermiso permisoActual, string permiso)
        {
            if (permisoActual.DevolverNombrePermiso() == permiso) { return true; }
            else
            {
                if (permisoActual.isComposite())
                {
                    List<EntidadPermiso> lista = (dp.DevolverPermsisosArbol().Find(x => x.DevolverNombrePermiso() == permisoActual.DevolverNombrePermiso()) as EntidadPermisoCompuesto).listaPermisos;
                    foreach (EntidadPermiso p in lista)
                    {
                        if (VerificarPermisoIncluido(p, permiso)) return true;
                    }
                }
            }
            return false;
        }

    }
}
