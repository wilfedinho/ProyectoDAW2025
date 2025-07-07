using BE;
using BLL.Tecnica;
using SERVICIOS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Vuelos : System.Web.UI.Page
{

    protected void Page_Load(object sender, EventArgs e)
    {
        Page.UnobtrusiveValidationMode = UnobtrusiveValidationMode.None;
        
        if (Session["usuario"] == null)
        {
            btnIniciarSesion.Visible = true;
            btnCambiarClave.Visible = false;
            btnCerrarSesion.Visible = false;
            btnMenuAdministrador.Visible = false;
            btnMenuWebMaster.Visible = false;
        }
        else
        {
            btnIniciarSesion.Visible = false;
            btnCambiarClave.Visible = true;
            btnCerrarSesion.Visible = true;
            if (Session["rol"].ToString() == "Admin")
            {
                btnMenuAdministrador.Visible = true;
            }
            else if (Session["rol"].ToString() == "WebMaster")
            {
                btnMenuWebMaster.Visible = true;
            }
            else
            {
                btnMenuAdministrador.Visible = false;
                btnMenuWebMaster.Visible = false;
            }
        }
    }

    protected void btnInicio_Click(object sender, EventArgs e)
    {
        Response.Redirect("Login.aspx");
    }

    protected void btnCambiarClave_Click(object sender, EventArgs e)
    {
        Response.Redirect("CambiarClave.aspx");
    }

    protected void btnCerrarSesion_Click(object sender, EventArgs e)
    {
        if (Session["usuario"] != null)
        {
            BitacoraBLL gestorBitacora = new BitacoraBLL();
            Bitacora eventoGenerado = new Bitacora(Session["usuario"].ToString(), DateTime.Parse(DateTime.Now.Date.ToString(@"yyyy-MM-dd")), TimeSpan.Parse(DateTime.Now.TimeOfDay.ToString(@"hh\:mm\:ss")), "Landing Page", "Salida del Sistema", 4);
            gestorBitacora.Alta(eventoGenerado);
        }

        Session.Clear();
        Session.Abandon();
        Response.Redirect("Vuelos.aspx");
    }

    protected void btnMenuAdministrador_Click(object sender, EventArgs e)
    {
        Response.Redirect("MenuAdministrador.aspx");
    }

    protected void btnMenuWebMaster_Click(object sender, EventArgs e)
    {
        Response.Redirect("MenuWebMaster.aspx");
    }
}