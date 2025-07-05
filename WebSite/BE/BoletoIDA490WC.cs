using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class BoletoIDA490WC : Boleto490WC
    {
        public BoletoIDA490WC(string nIDBoleto490WC, string nOrigen490WC, string nDestino490WC, DateTime nFechaPartida490WC, DateTime nFechaLlegada490WC, bool nIsVendido490WC, float nEquipajePermitido490WC, string nClaseBoleto490WC, float nPrecio490WC, Usuario nTitular490WC, string numeroAsiento490WC, string beneficioAplicado490WC = "") : base(nIDBoleto490WC, nOrigen490WC, nDestino490WC, nFechaPartida490WC, nFechaLlegada490WC, nIsVendido490WC, nEquipajePermitido490WC, nClaseBoleto490WC, nPrecio490WC, nTitular490WC, numeroAsiento490WC, beneficioAplicado490WC)
        {
        }
    }
}
