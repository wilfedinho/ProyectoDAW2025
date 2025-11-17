using BE;
using BLL.Tecnica;
using SERVICIOS;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

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
        BitacoraBLL gestorBitacora = new BitacoraBLL();
        Bitacora eventoGenerado = new Bitacora(Session["usuario"].ToString(), DateTime.Parse(DateTime.Now.Date.ToString(@"yyyy-MM-dd")), TimeSpan.Parse(DateTime.Now.TimeOfDay.ToString(@"hh\:mm\:ss")), "BackUp y Restore", "Realizo un BackUp De La BD", 5);
        gestorBitacora.Alta(eventoGenerado);
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
                BitacoraBLL gestorBitacora = new BitacoraBLL();
                Bitacora eventoGenerado = new Bitacora(Session["usuario"].ToString(), DateTime.Parse(DateTime.Now.Date.ToString(@"yyyy-MM-dd")), TimeSpan.Parse(DateTime.Now.TimeOfDay.ToString(@"hh\:mm\:ss")), "BackUp y Restore", "Realizo un Restore De La BD", 5);
                gestorBitacora.Alta(eventoGenerado);
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
        DigitoVerificador dv = new DigitoVerificador();
        dv.RecalcularDigitosVerificadores();
        lblResultadoDV.Text = string.Empty;
        if (dv.VerificarIntegridadTodasLasTablasBool())
        {

            lblResultadoDV.Text = "✅ Se volvió a calcular el dígito verificador";
        BitacoraBLL gestorBitacora = new BitacoraBLL();
        Bitacora eventoGenerado = new Bitacora(Session["usuario"].ToString(), DateTime.Parse(DateTime.Now.Date.ToString(@"yyyy-MM-dd")), TimeSpan.Parse(DateTime.Now.TimeOfDay.ToString(@"hh\:mm\:ss")), "BackUp y Restore", "Se Recalculo el Digito Verificador De La BD", 5);
        gestorBitacora.Alta(eventoGenerado);
        }
        else
        {
            lblResultadoDV.Text = "❌ Error al recalcular el dígito verificador";
        }
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
        Response.Redirect("Restore_BackUp.aspx");
    }

    protected void btnDigitosVerificadores_Click(object sender, EventArgs e)
    {
        Response.Redirect("Restore_BackUp.aspx");
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
        BitacoraBLL gestorBitacora = new BitacoraBLL();
        Bitacora eventoGenerado = new Bitacora(Session["usuario"].ToString(), DateTime.Parse(DateTime.Now.Date.ToString(@"yyyy-MM-dd")), TimeSpan.Parse(DateTime.Now.TimeOfDay.ToString(@"hh\:mm\:ss")), "Menu WebMaster", "Salida del Sistema", 4);
        gestorBitacora.Alta(eventoGenerado);
        Session.Clear();
        Session.Abandon();
        Response.Redirect("Login.aspx");
    }
    protected void btnVuelos_Click(object sender, EventArgs e)
    {
        Response.Redirect("Vuelos.aspx");
    }

    protected void btnES_Click(object sender, EventArgs e)
    {
        Session["idioma"] = "ES";
        Traductor.INSTANCIA("ES").ActualizarIdioma("ES");
        Response.Redirect(Request.RawUrl);
    }

    protected void btnEN_Click(object sender, EventArgs e)
    {
        Session["idioma"] = "EN";
        Traductor.INSTANCIA("EN").ActualizarIdioma("EN");
        Response.Redirect(Request.RawUrl);
    }

    public void TraducirPagina(Control contenedor, Traductor traductor)
    {
        foreach (Control ctrl in contenedor.Controls)
        {
            string idioma = Session["idioma"]?.ToString() ?? "ES";

            // NAVBAR
            if (ctrl.ID == "navbarPrincipal")
            {
                TraducirNavbar(ctrl, traductor);
            }
            else
            {
                // 🔥 1. Obtener la data-key para CUALQUIER tipo de control
                string dataKey = null;

                if (ctrl is WebControl wc)
                    dataKey = wc.Attributes["data-key"];
                else if (ctrl is HtmlControl hc)
                    dataKey = hc.Attributes["data-key"];

                // 🔥 2. Si existe key, traducir según tipo
                if (!string.IsNullOrEmpty(dataKey))
                {
                    string traduccion = traductor.Traducir(dataKey, idioma);

                    if (ctrl is LinkButton lb)
                        lb.Text = traduccion;

                    else if (ctrl is Button btn)
                        btn.Text = traduccion;

                    else if (ctrl is Label lbl)
                        lbl.Text = traduccion;

                    else if (ctrl is HtmlAnchor anchor)
                        anchor.InnerText = traduccion;

                    else if (ctrl is HtmlGenericControl hgc)
                        hgc.InnerText = traduccion;

                    else if (ctrl is CheckBoxList cbl)
                    {
                        foreach (ListItem item in cbl.Items)
                        {
                            string key = item.Attributes["data-key"];
                            if (!string.IsNullOrEmpty(key))
                                item.Text = traductor.Traducir(key, idioma);
                        }
                    }
                }
            }
            // Recursividad
            if (ctrl.HasControls())
                TraducirPagina(ctrl, traductor);
        }
    }


    public void TraducirNavbar(Control navbar, Traductor traductor)
    {
        string idioma = Session["idioma"]?.ToString() ?? "ES";

        foreach (Control ctrl in navbar.Controls)
        {
            // Caso A: es un HtmlAnchor <a runat="server">
            if (ctrl is HtmlAnchor anchor)
            {
                string key = anchor.Attributes["data-key"];
                if (!string.IsNullOrEmpty(key))
                {
                    anchor.InnerText = traductor.Traducir(key, idioma);
                }
            }

            // Caso B: es un LinkButton (si lo usás más adelante)
            else if (ctrl is LinkButton lb)
            {
                string key = lb.Attributes["data-key"];
                if (!string.IsNullOrEmpty(key))
                {
                    lb.Text = traductor.Traducir(key, idioma);
                }
            }

            // Recursivo para <ul>, <li>, etc.
            if (ctrl.HasControls())
            {
                TraducirNavbar(ctrl, traductor);
            }
        }
    }
}