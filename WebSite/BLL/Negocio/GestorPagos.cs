using SERVICIOS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Negocio
{
    public class GestorPagos
    {
        public bool ValidarPago(string datosPago, float precioPagar)
        {
            return ProcesarPagoEntidadBancaria(datosPago, precioPagar);
        }

        private bool ProcesarPagoEntidadBancaria(string datosPago, float precioPagar)
        {
            bool pagoAceptado490WC = true;
            Encryptador encryptador = new Encryptador();
            datosPago = encryptador.DesencryptadorReversible(datosPago);
            string[] datos490WC = datosPago.Split(',');
            if (pagoAceptado490WC)
            {
                //Bitacora490WC gestorBitacora490WC = new Bitacora490WC();
                //gestorBitacora490WC.AltaEvento490WC("Gestión Factura", "Cobrar Factura", 3);
                return true;

            }
            else
            {
                return false;
            }
        }
    }
}
