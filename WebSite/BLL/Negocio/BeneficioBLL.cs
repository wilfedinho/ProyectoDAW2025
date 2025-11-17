using BE;
using BLL.Tecnica;
using DAL;
using DAL.Negocio;
using SERVICIOS;
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
        UsuarioBLL bllUsuario = new UsuarioBLL();
        #region Operaciones Beneficio

        public void Alta(Beneficio BeneficioAlta)
        {
            BeneficioDAL gestorBeneficio = new BeneficioDAL();
            gestorBeneficio.Alta(BeneficioAlta);
            DigitoVerificador digitoVerificador = new DigitoVerificador();
            digitoVerificador.ActualizarDVH(BeneficioAlta, "Beneficio");
        }

        public bool Baja(int ID)
        {
            BeneficioDAL gestorBeneficio = new BeneficioDAL();
            bool a =  gestorBeneficio.Baja(ID);
            DigitoVerificador digitoVerificador = new DigitoVerificador();
            digitoVerificador.ActualizarDVV("Beneficio");
            return a;
        }


        public void Modificacion(Beneficio BeneficioModificado)
        {
            BeneficioDAL gestorBeneficio = new BeneficioDAL();
            gestorBeneficio.Modificacion(BeneficioModificado);
            DigitoVerificador digitoVerificador = new DigitoVerificador();
            digitoVerificador.ActualizarDVH(BeneficioModificado, "Beneficio");
        }

        public void AgregarBeneficioACliente(string DNICliente, int CodigoBeneficio)
        {
            BeneficioDAL gestorBeneficio = new BeneficioDAL();
            gestorBeneficio.AgregarBeneficioACliente(DNICliente, CodigoBeneficio);
            Beneficio BeneficioAlta = ObtenerBeneficioPorCodigo(CodigoBeneficio);
            DigitoVerificador digitoVerificador = new DigitoVerificador();
            digitoVerificador.ActualizarDVH(BeneficioAlta, "Usuario_Beneficio");
        }

        public void EliminarBeneficioDeCliente(string DNICliente, int CodigoBeneficio)
        {
            BeneficioDAL gestorBeneficio = new BeneficioDAL();
            gestorBeneficio.EliminarBeneficioDeCliente(DNICliente, CodigoBeneficio);
            DigitoVerificador digitoVerificador = new DigitoVerificador();
            digitoVerificador.ActualizarDVV("Usuario_Beneficio");
        }

        public void ReducirSaldoEstrellas(string DNICliente, int cantidadEstrellas)
        {
            BeneficioDAL gestorBeneficio = new BeneficioDAL();
            gestorBeneficio.ReducirSaldoEstrellas(DNICliente, cantidadEstrellas);
            DigitoVerificador digitoVerificador = new DigitoVerificador();
            Usuario usuario = bllUsuario.BuscarClientePorDNI(DNICliente);
            digitoVerificador.ActualizarDVH(usuario, "Usuario");
        }

        public void AplicarBeneficio(string IDBoleto, float DescuentoAplicar, string nombreBeneficio)
        {
            BeneficioDAL gestorBeneficio = new BeneficioDAL();
            gestorBeneficio.AplicarBeneficio(IDBoleto, DescuentoAplicar, nombreBeneficio);
            DigitoVerificador digitoVerificador = new DigitoVerificador();
            Boleto boleto = new BoletoBLL().ObtenerBoletoPorID(IDBoleto);
            digitoVerificador.ActualizarDVH(boleto, "Boleto");
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
