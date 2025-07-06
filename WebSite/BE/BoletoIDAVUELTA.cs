using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class BoletoIDAVUELTA : Boleto
    {
        public DateTime FechaPartidaVUELTA { get; set; }
        public DateTime FechaLlegadaVUELTA { get; set; }
        public BoletoIDAVUELTA(string nIDBoleto, string nOrigen, string nDestino, DateTime nFechaPartidaIDA, DateTime nFechaLlegadaIDA, DateTime nFechaPartidaVUELTA, DateTime nFechaLlegadaVUELTA, bool nIsVendido, float nEquipajePermitido, string nClaseBoleto, float nPrecio, Usuario nTitular, string numeroAsiento, string beneficioAplicado = "") : base(nIDBoleto, nOrigen, nDestino, nFechaPartidaIDA, nFechaLlegadaIDA, nIsVendido, nEquipajePermitido, nClaseBoleto, nPrecio, nTitular, numeroAsiento, beneficioAplicado)
        {
            FechaPartidaVUELTA = nFechaPartidaVUELTA;
            FechaLlegadaVUELTA = nFechaLlegadaVUELTA;
        }
    }
}
