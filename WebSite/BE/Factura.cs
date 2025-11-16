using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class Factura
    {
        public int NumeroFactura { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string BeneficioAplicado { get; set; }
        public string DNI { get; set; }
        public string FechaEmision { get; set; }
        public string HoraEmision { get; set; }
        public string NumeroBoleto { get; set; }
        public float Subtotal { get; set; }
        public float Total { get; set; }
        public string CambiosRealizados { get; set; }
        public Factura(int numeroFactura, string nombreCliente, string apellidoCliente, string dniCliente, string fechaEmision, string horaEmision, string numeroBoleto, float subtotal, float total, string beneficioAplicado = null)
        {
            NumeroFactura = numeroFactura;
            Nombre = nombreCliente;
            Apellido = apellidoCliente;
            DNI = dniCliente;
            FechaEmision = fechaEmision;
            HoraEmision = horaEmision;
            NumeroBoleto = numeroBoleto;
            Subtotal = subtotal;
            Total = total;
            BeneficioAplicado = beneficioAplicado;
        }
    }
}
