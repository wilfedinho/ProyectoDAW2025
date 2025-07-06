using BE;
using DAL;
using DAL.Negocio;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Negocio
{
    public class BeneficioBLL
    {
        #region Operaciones Beneficio

        public void Alta(Beneficio BeneficioAlta)
        {
            BeneficioDAL gestorBeneficio = new BeneficioDAL();
            gestorBeneficio.Alta(BeneficioAlta);
        }


        public bool Baja(int ID)
        {
            BeneficioDAL gestorBeneficio = new BeneficioDAL();
            return gestorBeneficio.Baja(ID);
        }


        public void Modificacion(Beneficio BeneficioModificado)
        {
           BeneficioDAL gestorBeneficio = new BeneficioDAL();
            gestorBeneficio.Modificacion(BeneficioModificado);
        }

        public void AgregarBeneficioACliente(string DNICliente, int CodigoBeneficio)
        {
            BeneficioDAL gestorBeneficio = new BeneficioDAL();
            gestorBeneficio.AgregarBeneficioACliente(DNICliente, CodigoBeneficio);
        }

        public void EliminarBeneficioDeCliente(string DNICliente, int CodigoBeneficio)
        {
            BeneficioDAL gestorBeneficio = new BeneficioDAL();
            gestorBeneficio.EliminarBeneficioDeCliente(DNICliente, CodigoBeneficio);
        }

        public void ReducirSaldoEstrellas(string DNICliente, int cantidadEstrellas)
        {
            BeneficioDAL gestorBeneficio = new BeneficioDAL();
            gestorBeneficio.ReducirSaldoEstrellas(DNICliente, cantidadEstrellas);
        }

        public void AplicarBeneficio(string IDBoleto, float DescuentoAplicar, string nombreBeneficio)
        {
            BeneficioDAL gestorBeneficio = new BeneficioDAL();
            gestorBeneficio.AplicarBeneficio(IDBoleto, DescuentoAplicar, nombreBeneficio);
        }

        public bool ExisteNombreBeneficioAlta(string nombreBeneficio)
        {
            BeneficioDAL gestorBeneficio = new BeneficioDAL();
            return gestorBeneficio.ExisteNombreBeneficioAlta(nombreBeneficio);
        }

        public bool ExisteNombreBeneficioModificar(string nombreBeneficio, int idActual)
        {
            BeneficioDAL gestorBeneficio = new BeneficioDAL();
            return gestorBeneficio.ExisteNombreBeneficioModificar(nombreBeneficio, idActual);
        }


        #endregion

        #region Busquedas Beneficio
        public Beneficio ObtenerBeneficioPorCodigo(int CodigoBeneficio)
        {
            BeneficioDAL gestorBeneficio = new BeneficioDAL();
            return gestorBeneficio.ObtenerBeneficioPorCodigo(CodigoBeneficio);
        }

        public List<Beneficio> ObtenerTodosLosBeneficios()
        {
            BeneficioDAL gestorBeneficio = new BeneficioDAL();
            return gestorBeneficio.ObtenerTodosLosBeneficios();
        }

        public List<Beneficio> ObtenerBeneficiosPorCliente(string DNI)
        {
            BeneficioDAL gestorBeneficio = new BeneficioDAL();
            return gestorBeneficio.ObtenerBeneficiosPorCliente(DNI);
        }

        public List<Beneficio> ObtenerBeneficiosPorCantidadDeReclamados(int cantidadReclamados)
        {
            BeneficioDAL gestorBeneficio = new BeneficioDAL();
            return gestorBeneficio.ObtenerBeneficiosPorCantidadDeReclamados(cantidadReclamados);
        }

        #endregion
    }
}
