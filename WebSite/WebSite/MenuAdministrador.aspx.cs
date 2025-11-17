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

public partial class MenuAdministrador : System.Web.UI.Page
{
    GestorPermisos gp = new GestorPermisos();
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
        if (Session["idioma"] == null)
        {
            Session["idioma"] = "ES";
            Traductor.INSTANCIA("ES").ActualizarIdioma("ES");
        }
        string idioma = Session["idioma"].ToString();

        if (idioma == "ES")
        {
            btnES.CssClass = "nav-link idioma-btn activo";
            btnEN.CssClass = "nav-link idioma-btn";
        }
        else
        {
            btnEN.CssClass = "nav-link idioma-btn activo";
            btnES.CssClass = "nav-link idioma-btn";
        }
        if (!IsPostBack)
        {
            gp.ActualizarGeneral();
        }
        TraducirPagina(this, Traductor.INSTANCIA(idioma));
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

    protected void btnPermisos_Click(object sender, EventArgs e)
    {
        Response.Redirect("GestionRolesUsuarios.aspx");
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

         
            if (ctrl.ID == "navbarPrincipal")
            {
                TraducirNavbar(ctrl, traductor);
            }
            else
            {
             
                string dataKey = null;

                if (ctrl is WebControl wc)
                    dataKey = wc.Attributes["data-key"];
                else if (ctrl is HtmlControl hc)
                    dataKey = hc.Attributes["data-key"];

            
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
       
            if (ctrl.HasControls())
                TraducirPagina(ctrl, traductor);
        }
    }


    public void TraducirNavbar(Control navbar, Traductor traductor)
    {
        string idioma = Session["idioma"]?.ToString() ?? "ES";

        foreach (Control ctrl in navbar.Controls)
        {
           
            if (ctrl is HtmlAnchor anchor)
            {
                string key = anchor.Attributes["data-key"];
                if (!string.IsNullOrEmpty(key))
                {
                    anchor.InnerText = traductor.Traducir(key, idioma);
                }
            }

          
            else if (ctrl is LinkButton lb)
            {
                string key = lb.Attributes["data-key"];
                if (!string.IsNullOrEmpty(key))
                {
                    lb.Text = traductor.Traducir(key, idioma);
                }
            }

         
            if (ctrl.HasControls())
            {
                TraducirNavbar(ctrl, traductor);
            }
        }
    }

}