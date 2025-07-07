using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class MenuWebMaster : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["usuario"] == null)
        {
            Response.Redirect("Login.aspx");
        }
        if (Session["rol"].ToString() == "Admin")
        {
            Response.Redirect("MenuAdministrador.aspx");
        }
        if (Session["rol"].ToString() == "Usuario")
        {
            Response.Redirect("Vuelos.aspx");
        }
    }

    protected void btnInicio_Click(object sender, EventArgs e)
    {
        //nada
    }

    protected void btnBackupRestore_Click(object sender, EventArgs e)
    {
        //Response.Redirect("Restore_BackUp.aspx");
    }

    protected void btnDigitosVerificadores_Click(object sender, EventArgs e)
    {
        //Response.Redirect("Restore_BackUp.aspx");
    }

    protected void btnBitacora_Click(object sender, EventArgs e)
    {
        Response.Redirect("Eventos.aspx");
    }

    protected void btnCambiarClave_Click(object sender, EventArgs e)
    {
        //nada
    }

    protected void btnVuelos_Click(object sender, EventArgs e)
    {
        Response.Redirect("Vuelos.aspx");
    }
    protected void btnCerrarSesion_Click(object sender, EventArgs e)
    {
        Session.Clear();
        Session.Abandon();
        Response.Redirect("Login.aspx");
    }
}