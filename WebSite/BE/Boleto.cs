using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class Boleto
    {
        public string IDBoleto { get; set; }
        public string Origen { get; set; }
        public string Destino { get; set; }
        public DateTime FechaPartida { get; set; }
        public DateTime FechaLlegada { get; set; }
        public bool IsVendido { get; set; }
        public float EquipajePermitido { get; set; }
        public string ClaseBoleto { get; set; }
        public float Precio { get; set; }
        public Usuario Titular { get; set; }
        public string NumeroAsiento { get; set; }
        public string BeneficioAplicado { get; set; }

        public Boleto(string nIDBoleto, string nOrigen, string nDestino, DateTime nFechaPartida, DateTime nFechaLlegada, bool nIsVendido, float nEquipajePermitido, string nClaseBoleto, float nPrecio, Usuario nTitular, string numeroAsiento, string beneficioAplicado = "")
        {
            IDBoleto = nIDBoleto;
            Origen = nOrigen;
            Destino = nDestino;
            FechaPartida = nFechaPartida;
            FechaLlegada = nFechaLlegada;
            IsVendido = nIsVendido;
            EquipajePermitido = nEquipajePermitido;
            ClaseBoleto = nClaseBoleto;
            Precio = nPrecio;
            Titular = nTitular;
            NumeroAsiento = numeroAsiento;
            BeneficioAplicado = beneficioAplicado;
        }
    }
}
