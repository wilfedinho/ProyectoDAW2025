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

public partial class Vuelos : System.Web.UI.Page
{
    GestorPermisos gp = new GestorPermisos();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["usuario"] == null)
        {
            Response.Redirect("Login.aspx");
        }

        Page.UnobtrusiveValidationMode = UnobtrusiveValidationMode.None;
        CargarVuelos();
        ChequearAccesibilidadDeTodosLosControles();

        string target = Request["__EVENTTARGET"];
        string arg = Request["__EVENTARGUMENT"];

        if (target == "SelectVuelo")
        {
            int idVuelo = int.Parse(arg);
            SeleccionarVuelo(idVuelo);
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
        if (Session["usuario"] == null)
        {

            btnCambiarClave.Visible = false;
            btnCerrarSesion.Visible = false;
        }
        else
        {
            if (Session["Idioma"].ToString() == "ES")
            {
                lblMensaje.Text = $"Bienvenido {Session["usuario"]} a Sanza Flights";
            }
            else
            {
                lblMensaje.Text = $"Welcome {Session["usuario"]} to Sanza Flights";
            }
                btnCambiarClave.Visible = true;
            btnCerrarSesion.Visible = true;
        }
    }


    private void SeleccionarVuelo(int idVuelo)
    {
        Session["VueloSeleccionado"] = idVuelo;
        Response.Redirect("ReservarBoleto.aspx");
    }

    public void ChequearAccesibilidadDeTodosLosControles()
    {
        GestorPermisos gp = new GestorPermisos();
        ChequearAccesibilidadRecursiva(Page, gp);
        ChequearAccesibilidadNavbar(nav1, gp);
    }

    private void ChequearAccesibilidadNavbar(Control navbar, GestorPermisos gp)
    {
        try
        {
            foreach (Control ctrl in navbar.Controls)
            {
                if (ctrl is Button btn)
                {
                    string permiso = btn.CommandName;
                    if (permiso == "")
                    {
                        btn.Visible = true;
                        continue;
                    }
                    if (!gp.TienePermiso(permiso, gp.DevolverPermisoConHijos(Session["rol"].ToString()) as EntidadPermisoCompuesto))
                    {
                        btn.Visible = false;
                    }
   
                    else
                    {
                        btn.Visible = true;
                    }
                }
                else if (ctrl is LinkButton linkBtn)
                {
                    string permiso = linkBtn.CommandName;
                    if (permiso == "")
                    {
                        linkBtn.Visible = true;
                        continue;
                    }
                    if (!gp.TienePermiso(permiso, gp.DevolverPermisoConHijos(Session["rol"].ToString()) as EntidadPermisoCompuesto))
                    {
                        linkBtn.Visible = false;
                    }
                    else
                    {
                        linkBtn.Visible = true;
                    }
                }
                else if (ctrl.HasControls())
                {
                    ChequearAccesibilidadNavbar(ctrl, gp);
                }
            }

        }
        catch { }
    }

    public void ChequearAccesibilidadRecursiva(Control contenedor, GestorPermisos gp)
    {
        foreach (Control ctrl in contenedor.Controls)
        {
            if (ctrl is Button)
            {
                ChequearAccesibilidad(ctrl as Button, gp);
                if (ctrl.HasControls())
                {
                    ChequearAccesibilidadRecursiva(ctrl, gp);
                }
            }
        }
    }

    public void ChequearAccesibilidad(Button boton, GestorPermisos gp)
    {
        boton.Visible = gp.Configurar_Control(boton.CommandName.ToString(), Session["rol"].ToString(), gp.DevolverPermisoConHijos(Session["rol"].ToString()) as EntidadPermisoCompuesto);
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
        Response.Redirect("Login.aspx");
    }

    protected void btnMenuAdministrador_Click(object sender, EventArgs e)
    {
        Response.Redirect("MenuAdministrador.aspx");
    }

    protected void btnMenuWebMaster_Click(object sender, EventArgs e)
    {
        Response.Redirect("MenuWebMaster.aspx");
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

    #region CargarVuelos
    private void CargarVuelos()
    {
        string tit1Es = "Reservar Boletos";
        string tit2Es = "Canjear Beneficios";
        string tit3Es = "Pagar Boletos";
        string des1Es = "En Esta Opcion Tendras La Posibilidad De Reservar Los Boletos Disponibles...";
        string des2Es = "En Esta Opcion Tendras La Posibilidad de Canjear Los Beneficios...";
        string des3Es = "En Esta Opcion Tendras La Posibilidad De Realizar Los Pagos";
        string tit1En = "Book Tickets";
        string tit2En = "Redeem Benefits";
        string tit3En = "Pay for Tickets";
        string des1En = "In this option, you will have the possibility to book available tickets...";
        string des2En = "In this option, you will have the possibility to redeem benefits...";
        string des3En = "In this option, you will have the possibility to make payments.";
        string titulo1;
        string titulo2;
        string titulo3;
        string desc1;
        string desc2;
        string desc3;

        if (Session["Idioma"].ToString() == "ES")
        {
            titulo1 = tit1Es;
            titulo2 = tit2Es;
            titulo3 = tit3Es;
            desc1 = des1Es;
            desc2 = des2Es;
            desc3 = des3Es;
        }
        else
        {
            titulo1 = tit1En;
            titulo2 = tit2En;
            titulo3 = tit3En;
            desc1 = des1En;
            desc2 = des2En;
            desc3 = des3En;
        }
        var vuelos = new List<dynamic>
    {
        new { ID = 1, Imagen = "https://images.unsplash.com/photo-1506744038136-46273834b3fb?auto=format&fit=crop&w=400&q=80",
              Titulo = titulo1,
              Descripcion = desc1,
              Url = "ReservarBoleto.aspx"
        },

        new { ID = 2, Imagen = "https://images.unsplash.com/photo-1464983953574-0892a716854b?auto=format&fit=crop&w=400&q=80",
              Titulo = titulo2,
              Descripcion = desc2,
              Url = "CanjearBeneficio.aspx"
        },

        new { ID = 3, Imagen = "https://images.unsplash.com/photo-1502082553048-f009c37129b9?auto=format&fit=crop&w=400&q=80",
              Titulo = titulo3,
              Descripcion = desc3,
              Url = "PagarBoleto.aspx"
        }
    };

        repVuelos.DataSource = vuelos;
        repVuelos.DataBind();
    }
    #endregion
}