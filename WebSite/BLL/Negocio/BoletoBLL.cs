using BE;
using DAL;
using DAL.Negocio;
using SERVICIOS;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace BLL.Negocio
{
    public class BoletoBLL
    {
        #region Operaciones Boleto

        public void Alta(Boleto BoletoAgregar)
        {
            BoletoDAL gestorBoleto = new BoletoDAL();
            gestorBoleto.Alta(BoletoAgregar);
            DigitoVerificador digitoVerificador = new DigitoVerificador();
            digitoVerificador.ActualizarDVH(BoletoAgregar, "Boleto");
        }


        public void Baja(string IDBoleto)
        {
            BoletoDAL gestorBoleto = new BoletoDAL();
            gestorBoleto.Baja(IDBoleto);
            DigitoVerificador digitoVerificador = new DigitoVerificador();
            digitoVerificador.ActualizarDVV("Boleto");
        }

        public void Modificar(Boleto BoletoModificado)
        {
            BoletoDAL gestorBoleto = new BoletoDAL();
            gestorBoleto.Modificar(BoletoModificado);
            DigitoVerificador digitoVerificador = new DigitoVerificador();
            digitoVerificador.ActualizarDVH(BoletoModificado, "Boleto");
        }
        public bool ExisteBoletoAsignar(int idBoleto)
        {
            BoletoDAL gestorBoleto = new BoletoDAL();
            return gestorBoleto.ExisteBoletoAsignar(idBoleto);
        }

        public void AsignarBoletoCliente(Boleto boletoAsignar, Usuario clienteAsignar)
        {
            BoletoDAL gestorBoleto = new BoletoDAL();
            gestorBoleto.AsignarBoletoCliente(boletoAsignar, clienteAsignar);
        }

        public void AsignarBoletoClienteRegistrar(Boleto boletoAsignar, Usuario clienteAsignar)
        {
            BoletoDAL gestorBoleto = new BoletoDAL();
            gestorBoleto.AsignarBoletoClienteRegistrar(boletoAsignar, clienteAsignar);
        }

        public void GenerarBoletoCompra(Boleto boletoGenerar)
        {
            BoletoDAL gestorBoleto = new BoletoDAL();
            gestorBoleto.GenerarBoletoCompra(boletoGenerar);
        }

        public void LiberarBoletosVencidos()
        {
            BoletoDAL gestorBoleto = new BoletoDAL();
            gestorBoleto.LiberarBoletosVencidos();
        }
        public bool ExisteBoletoEnAsiento(Boleto boletoVerificarExistencia)
        {
            BoletoDAL gestorBoleto = new BoletoDAL();
            return gestorBoleto.ExisteBoletoEnAsiento(boletoVerificarExistencia);
        }

        public bool ExisteBoletoEnAsientoParaModificar(Boleto boletoVerificarExistencia)
        {
            BoletoDAL gestorBoleto = new BoletoDAL();
            return gestorBoleto.ExisteBoletoEnAsientoParaModificar(boletoVerificarExistencia);
        }



        public void CobrarBoleto(Boleto BoletoCobrado)
        {
            BoletoDAL gestorBoleto = new BoletoDAL();
            gestorBoleto.CobrarBoleto(BoletoCobrado);
        }



        #endregion

        #region Busqueda Boleto

        public List<Boleto> ObtenerBoletosPorModalidad(string Modalidad)
        {
            BoletoDAL gestorBoleto = new BoletoDAL();
            return gestorBoleto.ObtenerBoletosPorModalidad(Modalidad);
        }

        public Boleto ObtenerBoletoPorID(string ID)
        {
            BoletoDAL gestorBoleto = new BoletoDAL();
            return gestorBoleto.ObtenerBoletoPorID(ID);
        }

        public List<Boleto> ObtenerBoletosPorPagarCliente(Usuario cliente)
        {
            BoletoDAL gestorBoleto = new BoletoDAL();
            return gestorBoleto.ObtenerBoletosPorPagarCliente(cliente);
        }

        public List<Boleto> ObtenerBoletosPorCliente(Usuario cliente)
        {
            BoletoDAL gestorBoleto = new BoletoDAL();
            return gestorBoleto.ObtenerBoletosPorCliente(cliente);
        }

        public List<Boleto> ObtenerTodosLosBoletos()
        {
            BoletoDAL gestorBoleto = new BoletoDAL();
            return gestorBoleto.ObtenerTodosLosBoletos();
        }

        public bool VerificarFormatoAsiento(string FormatoAsiento)
        {
            Regex rgxFormatoAsiento = new Regex("^[A-Z]{1}[0-9]{3}$");
            if (rgxFormatoAsiento.IsMatch(FormatoAsiento))
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        public List<Boleto> ObtenerBoletosFiltrados(string origen = "", string destino = "", string claseBoleto = "", float? precioDesde = null, float? precioHasta = null, float? pesoPermitido = null, DateTime? fechaPartida = null, DateTime? fechaLlegada = null, DateTime? fechaPartidaVUELTA = null, DateTime? fechaLlegadaVUELTA = null)
        {
            BoletoDAL gestorBoleto = new BoletoDAL();
            return gestorBoleto.ObtenerBoletosFiltrados(origen, destino, claseBoleto, precioDesde, precioHasta, pesoPermitido, fechaPartida, fechaLlegada, fechaPartidaVUELTA, fechaLlegadaVUELTA);
        }

        public Boleto ObtenerBoletoConBeneficio(string ID)
        {
            BoletoDAL gestorBoleto = new BoletoDAL();
            return gestorBoleto.ObtenerBoletoConBeneficio(ID);
        }
        #endregion
    }
}
