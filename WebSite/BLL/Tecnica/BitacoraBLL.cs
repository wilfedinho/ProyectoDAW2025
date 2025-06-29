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
        public List<Bitacora> ObtenerEventosPorConsulta490WC(string usuarioFiltrar490WC = "", string moduloFiltrar490WC = "", string descripcionFiltrar490WC = "", string criticidadFiltrar490WC = "", DateTime? fechaInicioFiltrar490WC = null, DateTime? fechaFinFiltrar490WC = null)
        {
            BitacoraDAL gestorBitacora = new BitacoraDAL();
            return gestorBitacora.ObtenerEventosPorConsulta490WC(usuarioFiltrar490WC, moduloFiltrar490WC, descripcionFiltrar490WC, criticidadFiltrar490WC, fechaInicioFiltrar490WC, fechaFinFiltrar490WC);
        }
    }
}
