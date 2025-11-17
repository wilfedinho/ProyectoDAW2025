using BE;
using BLL.Tecnica;
using SERVICIOS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

public partial class CambiarClave : System.Web.UI.Page
{
    GestorPermisos gp = new GestorPermisos();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["usuario"] == null)
        {
            Response.Redirect("Login.aspx");
        }
        if (Session["idioma"] == null)
        {
            Session["idioma"] = "ES";
            Traductor.INSTANCIA("ES").ActualizarIdioma("ES");
        }
        string idioma = Session["idioma"].ToString();
        if (!IsPostBack)
        {
            gp.ActualizarGeneral();
        }

        TraducirPagina(this, Traductor.INSTANCIA(idioma));
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
                    if (Session["idioma"].ToString() == "ES")
                    {
                        lblMensaje.Text = "Las claves no coinciden.";
                    }
                    else
                    {
                        lblMensaje.Text = "The passwords do not match";
                    }
                }
            }
            else
            {
                if (Session["idioma"].ToString() == "ES")
                {
                    lblMensaje.Text = "La nueva clave no puede ser igual a una antigua!!";
                }
                else
                {
                    lblMensaje.Text = "The new password cannot be the same as an old one";
                }
            }
        }
    }

    protected void btnCancelar_Click(object sender, EventArgs e)
    {
        Response.Redirect("Vuelos.aspx");
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