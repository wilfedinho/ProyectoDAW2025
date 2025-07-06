using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class BoletoIDA : Boleto
    {
        public BoletoIDA(string nIDBoleto, string nOrigen, string nDestino, DateTime nFechaPartida, DateTime nFechaLlegada, bool nIsVendido, float nEquipajePermitido, string nClaseBoleto, float nPrecio, Usuario nTitular, string numeroAsiento, string beneficioAplicado = "") : base(nIDBoleto, nOrigen, nDestino, nFechaPartida, nFechaLlegada, nIsVendido, nEquipajePermitido, nClaseBoleto, nPrecio, nTitular, numeroAsiento, beneficioAplicado)
        {
        }
    }
}
