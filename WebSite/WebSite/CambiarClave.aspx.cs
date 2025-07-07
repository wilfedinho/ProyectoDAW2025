using BE;
using BLL.Tecnica;
using SERVICIOS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class CambiarClave : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["usuario"] == null)
        {
            Response.Redirect("Login.aspx");
        }
    }
    protected void btnCambiarClave_Click(object sender, EventArgs e)
    {
        UsuarioBLL gestorUsuario = new UsuarioBLL();
        Usuario usuarioCambiarClave = gestorUsuario.BuscarUsuarioPorUsername(Session["usuario"].ToString());
        Encryptador cifrador = new Encryptador();

        if (usuarioCambiarClave != null)
        {
            if (cifrador.EncryptadorIrreversible(txtNuevaClave.Text) != usuarioCambiarClave.Contraseña && cifrador.EncryptadorIrreversible(txtConfirmarClave.Text) != usuarioCambiarClave.Contraseña)
            {
                if (txtNuevaClave.Text == txtConfirmarClave.Text)
                {
                    BitacoraBLL gestorBitacora = new BitacoraBLL();
                    Bitacora eventoGenerado = new Bitacora(Session["usuario"].ToString(), DateTime.Parse(DateTime.Now.Date.ToString(@"yyyy-MM-dd")), TimeSpan.Parse(DateTime.Now.TimeOfDay.ToString(@"hh\:mm\:ss")), "Cambio de Clave","Cambiar Clave",1);
                    gestorBitacora.Alta(eventoGenerado);
                    usuarioCambiarClave.Contraseña = txtNuevaClave.Text;
                    gestorUsuario.VerificarCambioClave490WC(usuarioCambiarClave);
                    lblMensaje.Text = "Clave cambiada exitosamente.";
                    Session.Clear();
                    Session.Abandon();
                    Response.Redirect("Vuelos.aspx");
                }
                else
                {
                    lblMensaje.Text = "Las claves no coinciden.";
                }
            }
            else
            {
                lblMensaje.Text = "La nueva clave no puede ser igual a una antigua!!";
            }
        }
    }

    protected void btnCancelar_Click(object sender, EventArgs e)
    {
        Response.Redirect("Vuelos.aspx");
    }

}