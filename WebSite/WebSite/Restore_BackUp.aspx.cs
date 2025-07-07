using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SERVICIOS;

public partial class Restore_BackUp : System.Web.UI.Page
{
    BackUp b = new BackUp();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            archivo.Attributes["accept"] = ".bak";
        }
    }

    protected void btnBackup_Click(object sender, EventArgs e)
    {
        string mensaje;
        bool exito = b.GenerarBackUp(out mensaje);

        Label1.Text = mensaje;
        Label1.CssClass = exito ? "mensaje-exito" : "mensaje-error";
        Label1.Visible = true;
    }

    protected void btnRestore_Click(object sender, EventArgs e)
    {
        if (archivo.HasFile)
        {
            try
            {
                string rutaServidor = Server.MapPath("~/TempBackups/");
                if (!Directory.Exists(rutaServidor))
                    Directory.CreateDirectory(rutaServidor);

                string nombreArchivo = Path.GetFileName(archivo.FileName);
                string rutaCompleta = Path.Combine(rutaServidor, nombreArchivo);

                archivo.SaveAs(rutaCompleta);

                bool exito = b.RestaurarBaseDeDatos(rutaCompleta, out string mensaje);
                Label2.Text = mensaje;
                Label2.CssClass = exito ? "mensaje-exito" : "mensaje-error";
                Label2.Visible = true;
            }
            catch (Exception ex)
            {
                Label2.Text = "❌ Error al subir archivo: " + ex.Message;
                Label2.CssClass = "mensaje-error";
                Label2.Visible = true;
            }
        }
        else
        {
            Label2.Text = "⚠️ Debés seleccionar un archivo .bak";
            Label2.CssClass = "mensaje-error";
            Label2.Visible = true;
        }
    }
}