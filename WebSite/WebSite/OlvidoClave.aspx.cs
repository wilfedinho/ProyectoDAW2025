using BE;
using BLL.Tecnica;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class OlvidoClave : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btnCambiarClave_Click(object sender, EventArgs e)
    {
        UsuarioBLL gestorUsuario = new UsuarioBLL();
        Usuario usuarioUsername = gestorUsuario.BuscarUsuarioPorUsername(txtUsuario.Text);
        Usuario usuarioDNI = gestorUsuario.BuscarUsuarioPorDNI(txtDNI.Text);
        if (usuarioUsername != null && usuarioDNI != null && usuarioDNI.Username == usuarioUsername.Username)
        {
            gestorUsuario.FormateoContraseña(usuarioUsername);
            Response.Redirect("Login.aspx");
        }
        else
        {
            lblMensaje.Text = "El usuario o el DNI no son correctos!!";
        }
    }
    protected void btnCancelar_Click(object sender, EventArgs e)
    {
        Response.Redirect("Login.aspx");
    }
}