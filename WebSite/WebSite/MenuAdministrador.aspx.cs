using BE;
using BLL.Tecnica;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class MenuAdministrador : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["usuario"] == null)
        {
            Response.Redirect("Vuelos.aspx");
        }
        if (Session["rol"].ToString() == "WebMaster")
        {
            Response.Redirect("MenuWebMaster.aspx");
        }
        if (Session["rol"].ToString() == "Usuario")
        {
            Response.Redirect("Vuelos.aspx");
        }
    }

    protected void btnInicio_Click(object sender, EventArgs e)
    {
        Response.Redirect("MenuAdministrador.aspx");
    }

    protected void btnUsuarios_Click(object sender, EventArgs e)
    {
        Response.Redirect("GestionUsuarios.aspx");
    }

    protected void btnBeneficios_Click(object sender, EventArgs e)
    {
        Response.Redirect("GestionBeneficios.aspx");
    }

    protected void btnBoletos_Click(object sender, EventArgs e)
    {
        Response.Redirect("GestionBoletos.aspx");
    }

    protected void btnClave_Click(object sender, EventArgs e)
    {
        Response.Redirect("CambiarClave.aspx");
    }

    protected void btnVuelos_Click(object sender, EventArgs e)
    {
        Response.Redirect("Vuelos.aspx");
    }
    protected void btnCerrarSesion_Click(object sender, EventArgs e)
    {
        BitacoraBLL gestorBitacora = new BitacoraBLL();
        Bitacora eventoGenerado = new Bitacora(Session["usuario"].ToString(), DateTime.Parse(DateTime.Now.Date.ToString(@"yyyy-MM-dd")), TimeSpan.Parse(DateTime.Now.TimeOfDay.ToString(@"hh\:mm\:ss")), "Menu Administrador", "Salida del Sistema", 4);
        gestorBitacora.Alta(eventoGenerado);
        Session.Clear();
        Session.Abandon();
        Response.Redirect("Login.aspx");
    }
}