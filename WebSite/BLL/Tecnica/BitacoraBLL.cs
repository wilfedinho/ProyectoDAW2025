using BE;
using DAL;
using DAL.Tecnica;
using SERVICIOS;
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
        public void Alta(Bitacora bitacoraAlta)
        {
            BitacoraDAL gestorBitacora = new BitacoraDAL();
            gestorBitacora.Alta(bitacoraAlta);
            DigitoVerificador digitoVerificador = new DigitoVerificador();
            digitoVerificador.ActualizarDVH(bitacoraAlta, "Bitacora");
        }
        public List<Bitacora> ObtenerEventosPorConsulta(string usuarioFiltrar = "", string moduloFiltrar = "", string descripcionFiltrar = "", string criticidadFiltrar = "", DateTime? fechaInicioFiltrar = null, DateTime? fechaFinFiltrar = null)
        {
            BitacoraDAL gestorBitacora = new BitacoraDAL();
            return gestorBitacora.ObtenerEventosPorConsulta(usuarioFiltrar, moduloFiltrar, descripcionFiltrar, criticidadFiltrar, fechaInicioFiltrar, fechaFinFiltrar);
        }
    }
}
