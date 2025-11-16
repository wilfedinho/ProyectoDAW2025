using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    [Serializable]
    public class Beneficio
    {
        public int CodigoBeneficio { get; set; }
        public string Nombre { get; set; }
        public int PrecioEstrella { get; set; }
        public int CantidadBeneficioReclamo { get; set; }
        public float DescuentoAplicar { get; set; }
        public Beneficio(int nCodigoBeneficio, string nNombre, int nPrecioEstrella, int nCantidadBeneficioReclamo, float nDescuentoAplicar)
        {
            CodigoBeneficio = nCodigoBeneficio;
            Nombre = nNombre;
            PrecioEstrella = nPrecioEstrella;
            CantidadBeneficioReclamo = nCantidadBeneficioReclamo;
            DescuentoAplicar = nDescuentoAplicar;
        }
        public Beneficio() { }
    }
}
