using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class DecoracionBeneficio : DecoracionBoleto
    {
        public DecoracionBeneficio(Boleto nBoleto) : base(nBoleto)
        {
            this.IDBoleto = boletoDecorar.IDBoleto;
            this.Origen = boletoDecorar.Origen;
            this.Destino = boletoDecorar.Destino;
            this.FechaPartida = boletoDecorar.FechaPartida;
            this.FechaLlegada = boletoDecorar.FechaLlegada;
            this.IsVendido = boletoDecorar.IsVendido;
            this.EquipajePermitido = boletoDecorar.EquipajePermitido;
            this.ClaseBoleto = boletoDecorar.ClaseBoleto;
            this.Precio = boletoDecorar.Precio;
            this.Titular = boletoDecorar.Titular;
            this.NumeroAsiento = boletoDecorar.NumeroAsiento;
            this.BeneficioAplicado = boletoDecorar.BeneficioAplicado;
        }

        public string MostrarBeneficio()
        {
            return this.BeneficioAplicado;
        }   
    }
}
