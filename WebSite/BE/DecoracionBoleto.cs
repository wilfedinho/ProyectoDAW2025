using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class DecoracionBoleto : Boleto
    {
        protected Boleto boletoDecorar;
        public DecoracionBoleto(Boleto nBoleto)
        {
            boletoDecorar = nBoleto;
        }
    }
}
