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
        if (Session["usuario"] != null && Session["rol"].ToString() == "WebMaster")
        {
            if (!IsPostBack)
            {
                archivo.Attributes["accept"] = ".bak";
            }
            MostrarMensajeDV();
        }
        else
        {
            Response.Redirect("Vuelos.aspx");
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
                DigitoVerificador dv = new DigitoVerificador();
                dv.RecalcularDigitosVerificadores();
                lblResultadoDV.Text = "";
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

    protected void btnCalcularDV_Click(object sender, EventArgs e)
    {
        DigitoVerificador dv =  new DigitoVerificador();
        dv.RecalcularDigitosVerificadores();
        lblResultadoDV.Text = string.Empty;
        lblResultadoDV.Text = "✅ Se volvió a calcular el dígito verificador";
    }

    private void MostrarMensajeDV()
    {
        lblResultadoDV.Visible = true;
        lblResultadoDV.Text = string.Empty;
        DigitoVerificador dv = new DigitoVerificador();
        if (!dv.VerificarIntegridadTodasLasTablasBool())
        {
            lblResultadoDV.Text = $"❌ Inconsistencia en la base de datos\n" + dv.VerificarIntegridadTodasLasTablas();
        }
        else
        {
            lblResultadoDV.Text = "✅ La base de datos está íntegra";
        }
    }

    protected void btnInicio_Click(object sender, EventArgs e)
    {
        Response.Redirect("MenuWebMaster.aspx");
    }

    protected void btnBackupRestore_Click(object sender, EventArgs e)
    {
        //nada
    }

    protected void btnDigitosVerificadores_Click(object sender, EventArgs e)
    {
        //nada
    }

    protected void btnBitacora_Click(object sender, EventArgs e)
    {
        Response.Redirect("Eventos.aspx");
    }

    protected void btnCambiarClave_Click(object sender, EventArgs e)
    {
        Response.Redirect("CambiarClave.aspx");
    }

    protected void btnCerrarSesion_Click(object sender, EventArgs e)
    {
        Session.Clear();
        Session.Abandon();
        Response.Redirect("Login.aspx");
    }
}