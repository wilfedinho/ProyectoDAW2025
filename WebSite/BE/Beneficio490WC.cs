using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class Beneficio490WC
    {
        public int CodigoBeneficio490WC { get; set; }
        public string Nombre490WC { get; set; }
        public int PrecioEstrella490WC { get; set; }
        public int CantidadBeneficioReclamo490WC { get; set; }
        public float DescuentoAplicar490WC { get; set; }
        public Beneficio490WC(int nCodigoBeneficio490WC, string nNombre490WC, int nPrecioEstrella490WC, int nCantidadBeneficioReclamo490WC, float nDescuentoAplicar490WC)
        {
            CodigoBeneficio490WC = nCodigoBeneficio490WC;
            Nombre490WC = nNombre490WC;
            PrecioEstrella490WC = nPrecioEstrella490WC;
            CantidadBeneficioReclamo490WC = nCantidadBeneficioReclamo490WC;
            DescuentoAplicar490WC = nDescuentoAplicar490WC;
        }
    }
}
