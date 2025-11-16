using BE;
using DAL.Negocio;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace BLL.Negocio
{
    public class GestorFactura
    {
        public void Alta(Factura FacturaAlta)
        {
            FacturaDAL gestorFactura490WC = new FacturaDAL();
            gestorFactura490WC.Alta(FacturaAlta);
            //Bitacora490WC GestorBitacora490WC = new Bitacora490WC();
            //GestorBitacora490WC.AltaEvento490WC("Gestión Factura", "Crear Factura", 3);
            //DigitoVerificador490WC gestorDigitoVerificador490WC = new DigitoVerificador490WC();
            //gestorDigitoVerificador490WC.ActualizarIntegridadPorTabla490WC("Factura490WC");
        }

        public List<Factura> ObtenerTodasLasFacturas()
        {
            FacturaDAL gestorFactura490WC = new FacturaDAL();
            return gestorFactura490WC.ObtenerTodasLasFacturas();
        }
        public void GenerarFactura(Factura factura490WC)
        {
            string carpeta490WC = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "FacturasMDW");
            if (!Directory.Exists(carpeta490WC)) { Directory.CreateDirectory(carpeta490WC); }
            string nombreArchivo490WC = $"Factura_{factura490WC.DNI}_Cod{factura490WC.NumeroFactura}.pdf";
            string rutaFinal490WC = Path.Combine(carpeta490WC, nombreArchivo490WC);


            float ancho490WC = Utilities.MillimetersToPoints(80);
            float alto490WC = Utilities.MillimetersToPoints(150);
            Document doc490WC = new Document(new Rectangle(ancho490WC, alto490WC), 10f, 10f, 10f, 10f);
            using (FileStream fs490WC = new FileStream(rutaFinal490WC, FileMode.Create))
            {
                PdfWriter writer490WC = PdfWriter.GetInstance(doc490WC, fs490WC);
                doc490WC.Open();
                doc490WC.Add(new Paragraph(" "));
                doc490WC.Add(new Paragraph(" "));
                Paragraph titulo490WC = new Paragraph($"FACTURA", FontFactory.GetFont(FontFactory.COURIER_BOLD, 16));
                titulo490WC.Alignment = Element.ALIGN_CENTER;
                doc490WC.Add(titulo490WC);
                doc490WC.Add(new Paragraph(" "));
                doc490WC.Add(new Paragraph($"Fecha: {factura490WC.FechaEmision} {factura490WC.HoraEmision}", FontFactory.GetFont(FontFactory.COURIER, 10)));
                doc490WC.Add(new Paragraph($"Cliente: {factura490WC.Apellido}, {factura490WC.Nombre}", FontFactory.GetFont(FontFactory.COURIER, 10)));
                doc490WC.Add(new Paragraph($"DNI: {factura490WC.DNI}", FontFactory.GetFont(FontFactory.COURIER, 10)));
                doc490WC.Add(new Paragraph(" "));
                doc490WC.Add(new Paragraph("----------------------------------", FontFactory.GetFont(FontFactory.COURIER, 10)));
                doc490WC.Add(new Paragraph(" "));
                doc490WC.Add(new Paragraph($"Numero Boleto: {factura490WC.NumeroBoleto}", FontFactory.GetFont(FontFactory.COURIER, 10)));
                if (factura490WC.BeneficioAplicado != null)
                {
                    if (!string.IsNullOrEmpty(factura490WC.BeneficioAplicado))
                    {
                        doc490WC.Add(new Paragraph($"Beneficio Aplicado: {factura490WC.BeneficioAplicado}", FontFactory.GetFont(FontFactory.COURIER, 10)));
                    }
                    else
                    {
                        doc490WC.Add(new Paragraph($"Beneficio Aplicado: No se Aplico Ningun Beneficio", FontFactory.GetFont(FontFactory.COURIER, 10)));
                    }
                }
                else
                {
                    doc490WC.Add(new Paragraph($"Beneficio Aplicado: No se Aplico Ningun Beneficio", FontFactory.GetFont(FontFactory.COURIER, 10)));
                }
                doc490WC.Add(new Paragraph($"Subtotal: {factura490WC.Subtotal:F2}$", FontFactory.GetFont(FontFactory.COURIER, 10)));
                doc490WC.Add(new Paragraph(" "));
                doc490WC.Add(new Paragraph("----------------------------------", FontFactory.GetFont(FontFactory.COURIER, 10)));
                doc490WC.Add(new Paragraph(" "));
                doc490WC.Add(new Paragraph($"Impuestos Aplicados: IMPUESTO PAIS 60%", FontFactory.GetFont(FontFactory.COURIER, 10)));
                doc490WC.Add(new Paragraph($"Total pagado: {factura490WC.Total:F2}$", FontFactory.GetFont(FontFactory.COURIER_BOLD, 12)));
                doc490WC.Add(new Paragraph(" "));
                doc490WC.Add(new Paragraph(" "));
                doc490WC.Close();
            }
            System.Diagnostics.Process.Start(rutaFinal490WC);
            //Bitacora490WC GestorBitacora490WC = new Bitacora490WC();
            //GestorBitacora490WC.AltaEvento490WC("Gestión Factura", "Generar Reporte Factura", 2);
        }
    }
}
