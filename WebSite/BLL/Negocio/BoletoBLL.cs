using BE;
using DAL;
using DAL.Negocio;
using iTextSharp.text;
using iTextSharp.text.pdf;
using SERVICIOS;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
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

        public void GenerarBoleto490WC(Boleto boleto)
        {
            string carpeta = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "BoletosMDW");
            if (!Directory.Exists(carpeta)) Directory.CreateDirectory(carpeta);

            string nombreArchivo = $"Boleto_{boleto.Titular.DNI}_Cod{boleto.IDBoleto}.pdf";
            string ruta = Path.Combine(carpeta, nombreArchivo);

            float ancho = Utilities.MillimetersToPoints(80);
            float alto = Utilities.MillimetersToPoints(150);
            Document doc = new Document(new Rectangle(ancho, alto), 10f, 10f, 10f, 10f);

            using (FileStream fs = new FileStream(ruta, FileMode.Create))
            {
                PdfWriter writer = PdfWriter.GetInstance(doc, fs);
                doc.Open();

                var fontTitulo = FontFactory.GetFont(FontFactory.COURIER_BOLD, 14);
                var fontSeccion = FontFactory.GetFont(FontFactory.COURIER_BOLD, 10);
                var fontNormal = FontFactory.GetFont(FontFactory.COURIER, 9);


                Paragraph titulo = new Paragraph("BOLETO DE VIAJE", fontTitulo);
                titulo.Alignment = Element.ALIGN_CENTER;
                doc.Add(titulo);
                doc.Add(new Paragraph(" ", fontNormal));


                doc.Add(new Paragraph($"N° Boleto: {boleto.IDBoleto}", fontNormal));
                doc.Add(new Paragraph($"Emitido: {DateTime.Now:dd/MM/yyyy HH:mm}", fontNormal));
                doc.Add(new Paragraph("----------------------------------", fontNormal));


                doc.Add(new Paragraph("ITINERARIO", fontSeccion));
                doc.Add(new Paragraph($"Origen: {boleto.Origen}", fontNormal));
                doc.Add(new Paragraph($"Destino: {boleto.Destino}", fontNormal));
                doc.Add(new Paragraph($"Salida: {boleto.FechaPartida:dd/MM/yyyy}", fontNormal));
                doc.Add(new Paragraph($"Llegada: {boleto.FechaLlegada:dd/MM/yyyy}", fontNormal));

                if (boleto is BoletoIDAVUELTA boleIDAVUELTA)
                {
                    doc.Add(new Paragraph($"Regreso: {boleIDAVUELTA.FechaPartidaVUELTA:dd/MM/yyyy}", fontNormal));
                    doc.Add(new Paragraph($"Llegada Regreso: {boleIDAVUELTA.FechaLlegadaVUELTA:dd/MM/yyyy}", fontNormal));
                    doc.Add(new Paragraph($"Modalidad: IDA Y VUELTA", fontNormal));
                }
                else
                {
                    doc.Add(new Paragraph($"Modalidad: SOLO IDA", fontNormal));
                }

                doc.Add(new Paragraph("----------------------------------", fontNormal));


                doc.Add(new Paragraph("PASAJERO", fontSeccion));
                doc.Add(new Paragraph($"Nombre: {boleto.Titular.Nombre}", fontNormal));
                doc.Add(new Paragraph($"Apellido: {boleto.Titular.Apellido}", fontNormal));
                doc.Add(new Paragraph($"DNI: {boleto.Titular.DNI}", fontNormal));

                doc.Add(new Paragraph("----------------------------------", fontNormal));


                doc.Add(new Paragraph("DETALLES", fontSeccion));
                if (string.IsNullOrEmpty(boleto.BeneficioAplicado))
                {
                    doc.Add(new Paragraph($"Beneficio: No Se Aplico Ningun Beneficio", fontNormal));
                }
                else
                {
                    doc.Add(new Paragraph($"Beneficio Aplicado: {boleto.BeneficioAplicado}", fontNormal));
                }
                doc.Add(new Paragraph($"Asiento: {boleto.NumeroAsiento}", fontNormal));
                doc.Add(new Paragraph($"Clase: {boleto.ClaseBoleto}", fontNormal));
                doc.Add(new Paragraph($"Equipaje: {boleto.EquipajePermitido} kg", fontNormal));
                doc.Add(new Paragraph($"Precio: ${boleto.Precio:F2}", fontNormal));

                doc.Add(new Paragraph(" ", fontNormal));
                doc.Add(new Paragraph("----------------------------------", fontNormal));
                doc.Add(new Paragraph(" ", fontNormal));

                doc.Close();
            }


            System.Diagnostics.Process.Start(ruta);
            //Bitacora490WC GestorBitacora490WC = new Bitacora490WC();
            //GestorBitacora490WC.AltaEvento490WC("Gestión Boleto", "Generar Reporte Boleto", 2);
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
