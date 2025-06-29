using BE;
using DAL;
using DAL.Tecnica;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Tecnica
{
    public class BitacoraBLL
    {
        public void Alta490WC(Bitacora bitacoraAlta)
        {
            BitacoraDAL gestorBitacora = new BitacoraDAL();
            gestorBitacora.Alta490WC(bitacoraAlta);
        }
        public List<Bitacora> ObtenerEventosPorConsulta490WC(string usuarioFiltrar = "", string moduloFiltrar = "", string descripcionFiltrar = "", string criticidadFiltrar = "", DateTime? fechaInicioFiltrar = null, DateTime? fechaFinFiltrar = null)
        {
            BitacoraDAL gestorBitacora = new BitacoraDAL();
            return gestorBitacora.ObtenerEventosPorConsulta490WC(usuarioFiltrar, moduloFiltrar, descripcionFiltrar, criticidadFiltrar, fechaInicioFiltrar, fechaFinFiltrar);
        }
    }
}
