using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class BoletoIDAVUELTA490WC : Boleto490WC
    {
        public DateTime FechaPartidaVUELTA490WC { get; set; }
        public DateTime FechaLlegadaVUELTA490WC { get; set; }
        public BoletoIDAVUELTA490WC(string nIDBoleto490WC, string nOrigen490WC, string nDestino490WC, DateTime nFechaPartidaIDA490WC, DateTime nFechaLlegadaIDA490WC, DateTime nFechaPartidaVUELTA490WC, DateTime nFechaLlegadaVUELTA490WC, bool nIsVendido490WC, float nEquipajePermitido490WC, string nClaseBoleto490WC, float nPrecio490WC, Usuario nTitular490WC, string numeroAsiento490WC, string beneficioAplicado490WC = "") : base(nIDBoleto490WC, nOrigen490WC, nDestino490WC, nFechaPartidaIDA490WC, nFechaLlegadaIDA490WC, nIsVendido490WC, nEquipajePermitido490WC, nClaseBoleto490WC, nPrecio490WC, nTitular490WC, numeroAsiento490WC, beneficioAplicado490WC)
        {
            FechaPartidaVUELTA490WC = nFechaPartidaVUELTA490WC;
            FechaLlegadaVUELTA490WC = nFechaLlegadaVUELTA490WC;
        }
    }
}
